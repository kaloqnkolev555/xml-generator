namespace KPMG.XmlGenerator.Web.Controllers
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    using KPMG.XmlGenerator.Core.Common;
    using KPMG.XmlGenerator.Business.CgMetaTechnicalSetting;

    /// <summary>
    /// TechnicalSettingController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/[controller]")]
    [Authorize(Policy = "Admin")]
    public class TechnicalSettingController : Controller
    {
        private readonly ICgMetaTechnicalSettingService technicalSettingService;
        
        public TechnicalSettingController(ICgMetaTechnicalSettingService technicalSettingService)
        {
            this.technicalSettingService = technicalSettingService;
        }

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <returns></returns>
        [HttpGet("NrObjct")]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetNrobjcts([FromQuery]int pageSize = Constants.DEFAULT_PAGE_SIZE, 
            [FromQuery]int skip = Constants.DEFAULT_SKIP_SIZE, [FromQuery]string filter = null)
        {
            var result = await this.technicalSettingService.GetNrObjects(pageSize, skip, filter);
            if (result == null)
            {
                return this.Ok(Enumerable.Empty<string>());
            }

            return this.Ok(result);
        }

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <returns></returns>
        [HttpGet("NrField")]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetNrfields([FromQuery]int pageSize = Constants.DEFAULT_PAGE_SIZE,
            [FromQuery]int skip = Constants.DEFAULT_SKIP_SIZE, [FromQuery]string filter = null)
        {
            var result = await this.technicalSettingService.GetNrfields(pageSize, skip, filter);
            if (result == null)
            {
                return this.Ok(Enumerable.Empty<string>());
            }

            return this.Ok(result);
        }
    }
}
