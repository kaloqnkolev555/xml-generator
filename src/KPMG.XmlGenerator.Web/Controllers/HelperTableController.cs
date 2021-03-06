namespace KPMG.XmlGenerator.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;

    using KPMG.XmlGenerator.Business.CgMetaHelperTable;
    using KPMG.XmlGenerator.Core.DTOs;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// HelperTableController class
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/[controller]")]
    [Authorize(Policy = "Admin")]
    public class HelperTableController : Controller
    {
        /// <summary>
        /// The cg meta helper table service
        /// </summary>
        private readonly ICgMetaHelperTableService cgMetaHelperTableService;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="HelperTableController"/> class.
        /// </summary>
        /// <param name="cgMetaHelperTableService">The cg meta helper table service.</param>
        /// <param name="mapper">The mapper.</param>
        public HelperTableController(ICgMetaHelperTableService cgMetaHelperTableService
            , IMapper mapper)
        {
            this.cgMetaHelperTableService = cgMetaHelperTableService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Gets the helper table by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CgMetaHelperTableDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetHelperTableById(int id)
        {
            var result = await this.cgMetaHelperTableService.GetHelperTableById(id);

            if (result == null)
            {
                return this.NotFound();
            }
            return this.Ok(this.mapper.Map<CgMetaHelperTableDTO>(result));
        }

        /// <summary>
        /// Gets all helper tables.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(CgMetaHelperTableDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllHelperTables()
        {
            var result = await this.cgMetaHelperTableService.GetAllHelperTables();

            if (result == null)
            {
                return this.Ok(Enumerable.Empty<CgMetaHelperTableDTO>());
            }
            return this.Ok(this.mapper.Map<IEnumerable<CgMetaHelperTableDTO>>(result));
        }

    }
}
