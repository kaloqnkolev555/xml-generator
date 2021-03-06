namespace KPMG.XmlGenerator.Web.Test.IntegrationTest
{
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    using KPMG.RefArc.Security.AspCore.Test;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.TestHost;

    using NUnit.Framework;

    /// <summary>
    /// SampleDataTest class
    /// </summary>
    [TestFixture]
    internal class SampleDataTest
    {
        private TestServer server;
        private HttpClient client;
        private readonly IEnumerable<Claim> testAdminRoleClaims =
            new List<Claim> { new Claim(ClaimTypes.Role, "Admin") };

        /// <summary>
        /// APIs the set up.
        /// </summary>
        [SetUp]
        public void ApiSetUp()
        {
            this.server = new TestServer(new WebHostBuilder().UseStartup<Startup>().UseEnvironment("IntegrationTest"));
            this.client = this.server.CreateClient();
        }

    }
}
