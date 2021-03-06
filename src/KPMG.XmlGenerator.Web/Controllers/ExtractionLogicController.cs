namespace KPMG.XmlGenerator.Web.Controllers
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    using KPMG.XmlGenerator.Core.DTOs;
    using KPMG.XmlGenerator.Business.CgMetaExtractionLogic;

    using AutoMapper;

    /// <summary>
    /// ObjectController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/[controller]")]
    [Authorize(Policy = "Admin")]
    public class ExtractionLogicController : Controller
    {
        private readonly ICgMetaExtractionLogicService cgMetaExtractionLogicService;
        private readonly IMapper mapper;

        public ExtractionLogicController(ICgMetaExtractionLogicService cgMetaExtractionLogicService, 
            IMapper mapper)
        {
            this.cgMetaExtractionLogicService = cgMetaExtractionLogicService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CgMetaExtractionLogicDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await this.cgMetaExtractionLogicService.GetAll();
            if (result == null)
            {
                return this.Ok(Enumerable.Empty<CgMetaExtractionLogicDTO>());
            }

            return this.Ok(this.mapper.Map<IEnumerable<CgMetaExtractionLogicDTO>>(result));
        }

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CgMetaExtractionLogicDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await this.cgMetaExtractionLogicService.GetById(id);
            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(this.mapper.Map<CgMetaExtractionLogicDTO>(result));
        }
    }
}
