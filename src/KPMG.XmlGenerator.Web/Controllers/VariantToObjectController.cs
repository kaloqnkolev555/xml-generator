namespace KPMG.XmlGenerator.Web.Controllers
{
    using System.Threading.Tasks;
    using System.Linq;
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;

    using KPMG.XmlGenerator.Business;
    using KPMG.XmlGenerator.Business.CgMetaVariantToObject;
    using KPMG.XmlGenerator.Core.Models;
    using KPMG.XmlGenerator.Core.DTOs;

    using AutoMapper;
    using FluentValidation;
    using FluentValidation.Internal;

    /// <summary>
    /// VariantToObjectController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/[controller]")]
    [Authorize(Policy = "Admin")]
    public class VariantToObjectController : Controller
    {
        /// <summary>
        /// The cg meta variant to object service
        /// </summary>
        private readonly ICgMetaVariantToObjectService cgMetaVariantToObjectService;

        /// <summary>
        /// The cg meta variant service
        /// </summary>
        private readonly ICgMetaVariantService cgMetaVariantService;

        /// <summary>
        /// The cg meta Variant to object validator
        /// </summary>
        private readonly IValidator<CgMetaVariantToObjectDTO> cgMetaVariantToObjectValidator;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="VariantToObjectController"/> class.
        /// </summary>
        /// <param name="cgMetaVariantToObjectService">The cg meta Variant to object service.</param>
        /// <param name="mapper">The mapper.</param>
        public VariantToObjectController(
            ICgMetaVariantToObjectService cgMetaVariantToObjectService
            , IMapper mapper
            , IValidator<CgMetaVariantToObjectDTO> cgMetaVariantToObjectValidator
            , ICgMetaVariantService cgMetaVariantService)
        {
            this.cgMetaVariantToObjectService = cgMetaVariantToObjectService;
            this.cgMetaVariantToObjectValidator = cgMetaVariantToObjectValidator;
            this.cgMetaVariantService = cgMetaVariantService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(CgMetaVariantToObjectDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllVariantToObjects()
        {
            var result = await this.cgMetaVariantToObjectService.GetAllVariantToObjects();

            if (result == null)
            {
                return this.Ok(Enumerable.Empty<CgMetaVariantToObjectDTO>());
            }
            return this.Ok(this.mapper.Map<IEnumerable<CgMetaVariantToObjectDTO>>(result));
        }

        /// <summary>
        /// Gets all mapped objects for variant.
        /// </summary>
        /// <param name="id">The identifier of the variant.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CgMetaVariantToObjectDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllVariantToObjectById(int id)
        {
            var result = await this.cgMetaVariantToObjectService.GetAllVariantToObjectById(id);

            if (result == null)
            {
                return this.Ok(new CgMetaVariantToObjectDTO() { VariantColumnId = id, ObjectColumnId = new int[] { } });
            }
            return this.Ok(this.mapper.Map<CgMetaVariantToObjectDTO>(result));
        }

        /// <summary>
        /// Maps the Variant to object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(CgMetaVariantToObjectDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> MapVariantToObjects([FromBody]CgMetaVariantToObjectDTO model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var valResult = this.cgMetaVariantToObjectValidator.Validate(model, new RulesetValidatorSelector("MapVariantToObject"));

            if (!valResult.IsValid)
            {
                return this.BadRequest(string.Join(" ", valResult.Errors));
            }

            try
            {
                var state = await this.cgMetaVariantToObjectService.MapVariantToObject(this.mapper.Map<CgMetaVariantToObject>(model));
                return this.CreatedAtAction(nameof(this.GetAllVariantToObjects), new { result = state }, new CgMetaVariantToObjectDTO() { VariantColumnId = model.VariantColumnId, ObjectColumnId = model.ObjectColumnId });
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
    }
}
