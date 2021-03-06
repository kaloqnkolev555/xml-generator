namespace KPMG.XmlGenerator.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;

    using KPMG.XmlGenerator.Business.CgMetaTable;
    using KPMG.XmlGenerator.Core.DTOs;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// TableController class
    /// </summary>
    /// <seealso cref="Controller" />
    [Route("api/[controller]")]
    [Authorize(Policy = "Admin")]
    public class TableController : Controller
    {
        /// <summary>
        /// The cg meta table service
        /// </summary>
        private readonly ICgMetaTableService cgMetaTableService;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper mapper;

        public TableController(ICgMetaTableService cgMetaTableService
            , IMapper mapper)
        {
            this.cgMetaTableService = cgMetaTableService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Gets the table by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CgMetaTableDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTableById(int id)
        {
            var result = await this.cgMetaTableService.GetTableById(id);

            if (result == null)
            {
                return this.NotFound();
            }
            return this.Ok(this.mapper.Map<CgMetaTableDTO>(result));
        }

        /// <summary>
        /// Gets all tables.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(CgMetaTableDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllTables()
        {
            var result = await this.cgMetaTableService.GetAllTables();

            if (result == null)
            {
                return this.Ok(Enumerable.Empty<CgMetaTableDTO>());
            }
            return this.Ok(this.mapper.Map<IEnumerable<CgMetaTableDTO>>(result));
        }
    }
}
