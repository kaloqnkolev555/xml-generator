namespace KPMG.XmlGenerator.Web.Security
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Security.Cryptography.X509Certificates;

    using KPMG.RefArc.Security.AspCore;
    using KPMG.RefArc.Security.AspCore.Configuration;
    using KPMG.RefArc.Security.AspCore.Spa;
    using KPMG.RefArc.Security.AspCore.Test;
    using KPMG.RefArc.Security.AspCore.Utilities;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Server.IISIntegration;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using Serilog;

    /// <summary>
    /// SecurityExtensions class
    /// </summary>
    public static class SecurityExtensions
    {
        private static IConfiguration Configuration { get; set; }

        /// <summary>
        /// Gets the configuration certificates.
        /// </summary>
        /// <value>
        /// The configuration certificates.
        /// </value>
        private static IEnumerable<X509Certificate2> ConfigurationCertificates
        {
            get
            {
                var certificateThumbrints =
                    Configuration.GetSection("Security:Bearer:CertificateThumbrints").Get<string[]>();

                var result = new List<X509Certificate2>();

                try
                {
                    result = Array.ConvertAll(
                        certificateThumbrints,
                        thumbprint => CertificateFinder.FindCertificate(
                            StoreName.Root,
                            StoreLocation.CurrentUser,
                            X509FindType.FindByThumbprint,
                            certificateThumbrints.First())).ToList();
                }
                catch
                {
                    // ignored
                }

                return result;
            }
        }

        /// <summary>
        /// Gets the bearer token authentication options.
        /// </summary>
        /// <value>
        /// The bearer token authentication options.
        /// </value>
        private static KPMGBearerTokenAuthenticationOptions BearerTokenAuthenticationOptions =>
            new KPMGBearerTokenAuthenticationOptions
                {
                    Audiences = Configuration.GetSection("Security:Bearer:Audiences").Get<string[]>(),
                    Issuer = Configuration.GetSection("Security:Bearer:Issuer").Get<string>(),
                    SignCertificates = ConfigurationCertificates,
                    RequireHttpsMetadata = Configuration.GetSection("Security:Bearer:RequireHttpsMetadata").Get<bool>(),
                };

        /// <summary>
        /// Gets the ws federation authentication options.
        /// </summary>
        /// <value>
        /// The ws federation authentication options.
        /// </value>
        private static KPMGWsFederationAuthenticationOptions WsFederationAuthenticationOptions =>
            new KPMGWsFederationAuthenticationOptions
                {
                    FederationMetadataAddress = Configuration.GetSection("Security:ADFS:MetadataAddress").Get<string>(),
                    FederationWtrealm = Configuration.GetSection("Security:ADFS:Wtrealm").Get<string>()
            };

        /// <summary>
        /// Gets the azure authentication options.
        /// </summary>
        /// <value>
        /// The azure authentication options.
        /// </value>
        private static KPMGAzureAdAuthenticationOptions AzureAuthenticationOptions =>
            new KPMGAzureAdAuthenticationOptions
                {
                    Instance = Configuration.GetSection("Security:AzureAd:Instance").Get<string>(),
                    CallbackPath = Configuration.GetSection("Security:AzureAd:CallbackPath").Get<string>(),
                    ClientId = Configuration.GetSection("Security:AzureAd:ClientId").Get<string>(),
                    TenantId = Configuration.GetSection("Security:AzureAd:TenantId").Get<string>(),
                    Domain = Configuration.GetSection("Security:AzureAd:Domain").Get<string>()
                };

        /// <summary>
        /// Gets the azure API authentication options.
        /// </summary>
        /// <value>
        /// The azure API authentication options.
        /// </value>
        private static KPMGAzureAdApiAuthenticationOptions AzureApiAuthenticationOptions =>
            new KPMGAzureAdApiAuthenticationOptions
                {
                    Authority = Configuration.GetSection("Security:AzureAdApi:Authority").Get<string>(),
                    AppIdUri = Configuration.GetSection("Security:AzureAdApi:AppIdUri").Get<string>(),
                    ClientId = Configuration.GetSection("Security:AzureAdApi:ClientId").Get<string>()
                };

        /// <summary>
        /// Uses the KPMG security.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="configuration">The configuration.</param>
        public static void UseKPMGSecurity(this IApplicationBuilder app, IConfiguration configuration)
        {
            Configuration = configuration;

            if (configuration.GetSection("Security:Enabled").Get<bool>())
            {
                Log.Information("Security Enabled");

                if (configuration.GetSection("Security:BearerTestUser:Enabled").Get<bool>())
                {
                    Log.Information("Security Test User Enabled");

                    app.UseKPMGTestUser(
                        "Developer",
                        new List<Claim> { new Claim(ClaimTypes.Role, "Admin"), new Claim(ClaimTypes.Role, "User") });
                }
                else
                {
                    Log.Information("Security Test User Disabled");
                }

                if (configuration.GetSection("Security:BearerTest:Enabled").Get<bool>())
                {
                    Log.Information("Security Bearer Test Mode Enabled");
                    app.UseKPMGTestAuthentication(BearerTokenAuthenticationOptions);
                }
                else
                {
                    Log.Information("Security Bearer Test Mode Disabled");
                }

                app.UseKPMGAuthentication(
                    new KPMGAuthenticationOptions()
                        {
                            DisableAuthenticateRequestPolicy = false,
                            DisableSignout = false
                        });
                if (configuration.GetSection("Security:BearerSpaEndpoint:Enabled").Get<bool>())
                {
                    Log.Information("Security Spa Endpoint Enabled");

                    app.UseKPMGSecurityUserTokenEndpoint(true, BearerTokenAuthenticationOptions);
                }
                else
                {
                    Log.Information("Security Spa Endpoint Disabled");
                }
            }
            else
            {
                Log.Information("Security Disabled");
            }
        }

        /// <summary>
        /// Adds the KPMG security.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        public static void AddKPMGSecurity(this IServiceCollection services, IConfiguration configuration)
        {
            Configuration = configuration;

            if (configuration.GetSection("Security:Enabled").Get<bool>())
            {
                // Method AddKPMGSearchServices provides default implementation of service ILdapService
                // If you need specific implementation of this interface, remove this line
                services.AddKPMGSearchServices();

                if (configuration.GetSection("Security:ADFS:Enabled").Get<bool>())
                {
                    Log.Information("Security ADFS Enabled");

                    services.AddKPMGWsFederationAuthentication(WsFederationAuthenticationOptions);
                }

                if (configuration.GetSection("Security:Bearer:Enabled").Get<bool>())
                {
                    Log.Information("Security Bearer Enabled");

                    services.AddKPMGBearerAuthentication(BearerTokenAuthenticationOptions);
                }

                if (configuration.GetSection("Security:AzureAd:Enabled").Get<bool>())
                {
                    Log.Information("Security Azure Ad Enabled");

                    services.AddKPMGAzureAdAuthentication(AzureAuthenticationOptions);
                }

                if (configuration.GetSection("Security:AzureAdApi:Enabled").Get<bool>())
                {
                    Log.Information("Security Azure Ad API Enabled");

                    services.AddKPMGAzureAdApiAuthentication(AzureApiAuthenticationOptions);
                }

                if (configuration.GetSection("Security:IISDefault:Enabled").Get<bool>())
                {
                    Log.Information("Security IIS Enabled");

                    services.AddAuthentication(
                        options =>
                        {
                            options.DefaultScheme = IISDefaults.AuthenticationScheme;
                            options.DefaultAuthenticateScheme = IISDefaults.AuthenticationScheme;
                            options.DefaultChallengeScheme = IISDefaults.AuthenticationScheme;
                        });
                }
            }
        }
    }
}
