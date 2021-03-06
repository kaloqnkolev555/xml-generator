namespace KPMG.XmlGenerator.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using KPMG.XmlGenerator.Business;
    using KPMG.XmlGenerator.Core.DTOs;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// DD03LController class
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/[controller]")]
    [Authorize(Policy = "Admin")]
    public class DD03LController : Controller
    {
        /// <summary>
        /// The DD03L service
        /// </summary>
        private readonly IDD03LService dd03lService;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="DD03LController"/> class.
        /// </summary>
        /// <param name="dd03lService">The cg meta group service.</param>
        /// <param name="mapper">The mapper.</param>
        public DD03LController(
            IDD03LService dd03lService,
            IMapper mapper)
        {
            this.dd03lService = dd03lService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Gets all fields for a table.
        /// </summary>
        /// <param name="tabName">The table name.</param>
        /// <returns></returns>
        [HttpGet("GetFieldsForTable")]
        [ProducesResponseType(typeof(IEnumerable<DD03LDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFieldsForTable([FromQuery(Name = "tableName")]string tableName)
        {
            var result = await this.dd03lService.GetFieldsForTable(tableName);

            if (result == null)
            {
                return this.Ok(Enumerable.Empty<DD03LDTO>());
            }
            return this.Ok(result.Select(this.mapper.Map<DD03LDTO>));
        }

        /// <summary>
        /// Gets a single field by table and field name.
        /// </summary>
        /// <param name="tabName">The table name.</param>
        /// <param name="fieldName">The field name.</param>
        /// <returns></returns>
        [HttpGet("GetField")]
        [ProducesResponseType(typeof(DD03LDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetField([FromQuery(Name = "tableName")]string tableName, [FromQuery(Name = "fieldName")]string fieldName)
        {
            var result = await this.dd03lService.GetField(tableName, fieldName);

            if (result == null)
            {
                return this.NotFound();
            }
            return this.Ok(this.mapper.Map<DD03LDTO>(result));
        }
    }
}
