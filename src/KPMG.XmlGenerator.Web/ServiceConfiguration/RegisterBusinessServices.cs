namespace KPMG.XmlGenerator.Web.ServiceConfiguration
{
    using System.Linq;

    using KPMG.XmlGenerator.Business;
    using KPMG.XmlGenerator.Business.CgMetaArea;
    using KPMG.XmlGenerator.Business.CgMetaAreaToObject;
    using KPMG.XmlGenerator.Business.CgMetaColumn;
    using KPMG.XmlGenerator.Business.CgMetaConfiguration;
    using KPMG.XmlGenerator.Business.CgMetaConfigurationToVariant;
    using KPMG.XmlGenerator.Business.CgMetaConstraintToArea;
    using KPMG.XmlGenerator.Business.CgMetaExtractionLogic;
    using KPMG.XmlGenerator.Business.CgMetaGroup;
    using KPMG.XmlGenerator.Business.CgMetaHelperTable;
    using KPMG.XmlGenerator.Business.CgMetaObject;
    using KPMG.XmlGenerator.Business.CgMetaTable;
    using KPMG.XmlGenerator.Business.CgMetaTechnicalSetting;
    using KPMG.XmlGenerator.Business.CgMetaVariantToObject;

    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// RegisterBusinessServices class
    /// </summary>
    public static class RegisterBusinessServices
    {
        /// <summary>
        /// Registers the business service extension.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void RegisterBusinessServiceExtension(this IServiceCollection services)
        {
            services.AddScoped<VersionFromQueryService>(sp =>
            {
                var httpContext = sp.GetService<IHttpContextAccessor>().HttpContext;
                var versionString = httpContext.Request.Query["V"].FirstOrDefault() ?? "";
                int.TryParse(versionString, out int versionId);
                return new VersionFromQueryService() { VersionId = versionId };
            });
            services.AddScoped<ICgMetaObjectService, CgMetaObjectService>();
            services.AddScoped<ICgMetaAreaService, CgMetaAreaService>();
            services.AddScoped<ICgMetaAreaToObjectService, CgMetaAreaToObjectService>();
            services.AddScoped<ICgMetaConfigurationService, CgMetaConfigurationService>();
            services.AddScoped<ICgMetaVariantService, CgMetaVariantService>();
            services.AddScoped<ICgMetaVariantToObjectService, CgMetaVariantToObjectService>();
            services.AddScoped<ICgMetaConfigurationToVariantService, CgMetaConfigurationToVariantService>();
            services.AddScoped<ICgMetaGroupService, CgMetaGroupService>();
            services.AddScoped<ICgMetaTableService, CgMetaTableService>();
            services.AddScoped<ICgMetaVersionService, CgMetaVersionService>();
            services.AddScoped<ICgMetaHelperTableService, CgMetaHelperTableService>();
            services.AddScoped<ICgMetaExtractionLogicService, CgMetaExtractionLogicService>();
            services.AddScoped<IDD03LService, DD03LService>();
            services.AddScoped<ICgMetaTechnicalSettingService, CgMetaTechnicalSettingService>();
            services.AddScoped<ICgMetaConstraintToAreaService, CgMetaConstraintToAreaService>();
            services.AddScoped<ICgMetaColumnService, CgMetaColumnService>();
        }
    }
}
