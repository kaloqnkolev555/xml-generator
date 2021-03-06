namespace KPMG.XmlGenerator.Web.Controllers
{
    using System.Threading.Tasks;
    using System.Linq;
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;

    using KPMG.XmlGenerator.Business.CgMetaAreaToObject;
    using KPMG.XmlGenerator.Core.Models;
    using KPMG.XmlGenerator.Core.DTOs;
    using KPMG.XmlGenerator.Business.CgMetaArea;

    using AutoMapper;
    using FluentValidation;
    using FluentValidation.Internal;

    /// <summary>
    /// AreaToObjectController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/[controller]")]
    [Authorize(Policy = "Admin")]
    public class AreaToObjectController : Controller
    {
        /// <summary>
        /// The cg meta area to object service
        /// </summary>
        private readonly ICgMetaAreaToObjectService cgMetaAreaToObjectService;

        /// <summary>
        /// The cg meta area service
        /// </summary>
        private readonly ICgMetaAreaService cgMetaAreaService;

        /// <summary>
        /// The cg meta area to object validator
        /// </summary>
        private readonly IValidator<CgMetaAreaToObjectDTO> cgMetaAreaToObjectValidator;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="AreaToObjectController"/> class.
        /// </summary>
        /// <param name="cgMetaAreaToObjectService">The cg meta area to object service.</param>
        /// <param name="mapper">The mapper.</param>
        public AreaToObjectController(ICgMetaAreaToObjectService cgMetaAreaToObjectService
            , IMapper mapper
            , IValidator<CgMetaAreaToObjectDTO> cgMetaAreaToObjectValidator
            , ICgMetaAreaService cgMetaAreaService)
        {
            this.cgMetaAreaToObjectService = cgMetaAreaToObjectService;
            this.cgMetaAreaToObjectValidator = cgMetaAreaToObjectValidator;
            this.cgMetaAreaService = cgMetaAreaService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(CgMetaAreaToObjectDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllAreaToObjects()
        {
            var result = await this.cgMetaAreaToObjectService.GetAllAreaToObjects();

            if (result == null)
            {
                return Ok(Enumerable.Empty<CgMetaAreaToObjectDTO>());

            }
            return Ok(this.mapper.Map<IEnumerable<CgMetaAreaToObjectDTO>>(result));
        }

        /// <summary>
        /// Gets all area to object by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CgMetaAreaToObjectDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllAreaToObjectById(int id)
        {
            var result = await this.cgMetaAreaToObjectService.GetAllAreaToObjectById(id);

            if (result == null)
            {
                return this.Ok(new CgMetaAreaToObjectDTO() { AreaColumnId = id, ObjectColumnId = new int[] { } });
            }
            return Ok(this.mapper.Map<CgMetaAreaToObjectDTO>(result));
        }

        /// <summary>
        /// Maps the area to object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(CgMetaAreaToObjectDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> MapAreaToObject([FromBody]CgMetaAreaToObjectDTO model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var valResult = this.cgMetaAreaToObjectValidator.Validate(model, new RulesetValidatorSelector("MapAreaToObject"));

            if (!valResult.IsValid)
            {
                return this.BadRequest(string.Join(" ", valResult.Errors));
            }

            try
            {
                var state = await this.cgMetaAreaToObjectService.MapAreaToObject(this.mapper.Map<CgMetaAreaToObject>(model));
                return this.Ok(model);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
    }
}
