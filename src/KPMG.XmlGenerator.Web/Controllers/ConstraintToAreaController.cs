namespace KPMG.XmlGenerator.Web.Controllers
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    using KPMG.XmlGenerator.Core.Common;
    using KPMG.XmlGenerator.Business.CgMetaConstraintToArea;

    /// <summary>
    /// TechnicalSettingController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/[controller]")]
    [Authorize(Policy = "Admin")]
    public class ConstraintToAreaController : Controller
    {
        private readonly ICgMetaConstraintToAreaService constraintToAreaService;

        public ConstraintToAreaController(ICgMetaConstraintToAreaService constraintToAreaService)
        {
            this.constraintToAreaService = constraintToAreaService;
        }

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <returns></returns>
        [HttpGet("ConOption")]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetConOptions([FromQuery]int pageSize = Constants.DEFAULT_PAGE_SIZE,
            [FromQuery]int skip = Constants.DEFAULT_SKIP_SIZE, [FromQuery]string filter = null)
        {
            var result = await this.constraintToAreaService.GetConOptions(pageSize, skip, filter);
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
        [HttpGet("ConValue")]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetConValues([FromQuery]int pageSize = Constants.DEFAULT_PAGE_SIZE,
            [FromQuery]int skip = Constants.DEFAULT_SKIP_SIZE, [FromQuery]string filter = null)
        {
            var result = await this.constraintToAreaService.GetConValues(pageSize, skip, filter);
            if (result == null)
            {
                return this.Ok(Enumerable.Empty<string>());
            }

            return this.Ok(result);
        }
    }
}
