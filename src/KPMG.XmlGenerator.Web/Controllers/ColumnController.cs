namespace KPMG.XmlGenerator.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;

    using KPMG.XmlGenerator.Business.CgMetaColumn;
    using KPMG.XmlGenerator.Core.DTOs;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// ColumnController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/[controller]")]
    [Authorize(Policy = "Admin")]
    public class ColumnController : Controller
    {
        /// <summary>
        /// The cg meta column service
        /// </summary>
        private readonly ICgMetaColumnService cgMetaColumnService;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnController"/> class.
        /// </summary>
        /// <param name="cgMetaColumnService"></param>
        /// <param name="mapper"></param>
        public ColumnController(ICgMetaColumnService cgMetaColumnService
            , IMapper mapper)
        {
            this.cgMetaColumnService = cgMetaColumnService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Gets all columns mapped to an object and area
        /// </summary>
        /// <param name="objectName"></param>
        /// <param name="areaName"></param>
        /// <returns></returns>
        [HttpGet("GetColumnsByObjectNameAreaName")]
        [ProducesResponseType(typeof(CgMetaColumnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetColumnsByObjectNameAreaName([FromQuery(Name = "objectName")]string objectName,
            [FromQuery(Name = "areaName")]string areaName)
        {
            if (string.IsNullOrWhiteSpace(objectName) || string.IsNullOrWhiteSpace(areaName))
            {
                return this.BadRequest();
            }

            var result = await this.cgMetaColumnService.GetColumnsByObjectNameAreaName(objectName, areaName);

            if (result == null)
            {
                return this.Ok(Enumerable.Empty<CgMetaColumnDTO>());
            }

            return this.Ok(this.mapper.Map<IEnumerable<CgMetaColumnDTO>>(result));

        }
    }
}
