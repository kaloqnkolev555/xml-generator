namespace KPMG.XmlGenerator.Web.Security
{
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authentication;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// UserClaimsTransformer class
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Authentication.IClaimsTransformation" />
    public class UserClaimsTransformer : IClaimsTransformation
    {
        private const string adminRoleName = "Admin";

        private const string userRoleName = "User";

        private readonly IConfiguration configuration;

        public UserClaimsTransformer(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// Provides a central transformation point to change the specified principal.
        /// Note: this will be run on each AuthenticateAsync call, so its safer to
        /// return a new ClaimsPrincipal if your transformation is not idempotent.
        /// </summary>
        /// <param name="principal">The <see cref="T:System.Security.Claims.ClaimsPrincipal" /> to transform.</param>
        /// <returns>
        /// The transformed principal.
        /// </returns>
        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var adminSecurityGroups = this.configuration.GetSection("SecurityGroups:AdminSecurityGroups").Get<string[]>();
            var userSecurityGroups = this.configuration.GetSection("SecurityGroups:UserSecurityGroups").Get<string[]>();

            if (adminSecurityGroups != null && userSecurityGroups != null)
            {
                var isAdmin = adminSecurityGroups.Any(principal.IsInRole);
                var isUser = userSecurityGroups.Any(principal.IsInRole);

                if (isAdmin && !principal.HasClaim(c => c.Type == ClaimTypes.Role && c.Value == adminRoleName))
                {
                    ((ClaimsIdentity)principal.Identity).AddClaim(new Claim(ClaimTypes.Role, adminRoleName));
                }

                if (isUser && !principal.HasClaim(c => c.Type == ClaimTypes.Role && c.Value == userRoleName))
                {
                    ((ClaimsIdentity)principal.Identity).AddClaim(new Claim(ClaimTypes.Role, userRoleName));
                }
            }

            return Task.FromResult(principal);
        }
    }
}
