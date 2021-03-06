namespace KPMG.XmlGenerator.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;

    using KPMG.XmlGenerator.Business.CgMetaGroup;
    using KPMG.XmlGenerator.Core.DTOs;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// GroupController class
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/[controller]")]
    [Authorize(Policy = "Admin")]
    public class GroupController : Controller
    {
        /// <summary>
        /// The cg meta group service
        /// </summary>
        private readonly ICgMetaGroupService cgMetaGroupService;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupController"/> class.
        /// </summary>
        /// <param name="cgMetaGroupService">The cg meta group service.</param>
        /// <param name="mapper">The mapper.</param>
        public GroupController(ICgMetaGroupService cgMetaGroupService
            , IMapper mapper)
        {
            this.cgMetaGroupService = cgMetaGroupService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Gets the group by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CgMetaGroupDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetGroupById(int id)
        {
            var result = await this.cgMetaGroupService.GetGroupById(id);

            if (result == null)
            {
                return this.NotFound();
            }
            return this.Ok(this.mapper.Map<CgMetaGroupDTO>(result));
        }

        /// <summary>
        /// Gets all groups.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(CgMetaGroupDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllGroups()
        {
            var result = await this.cgMetaGroupService.GetAllGroups();

            if (result == null)
            {
                return this.Ok(Enumerable.Empty<CgMetaGroupDTO>());
            }
            return this.Ok(this.mapper.Map<IEnumerable<CgMetaGroupDTO>>(result));
        }
    }
}
