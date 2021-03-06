namespace KPMG.XmlGenerator.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using FluentValidation;
    using FluentValidation.Internal;

    using KPMG.XmlGenerator.Business;
    using KPMG.XmlGenerator.Business.CgMetaObject;
    using KPMG.XmlGenerator.Core.Exceptions;
    using KPMG.XmlGenerator.Core.DTOs;
    using KPMG.XmlGenerator.Core.Models;


    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Variant Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/[controller]")]
    [Authorize(Policy = "Admin")]
    public class VariantController : Controller
    {
        /// <summary>
        /// The cg meta variant service
        /// </summary>
        private readonly ICgMetaVariantService cgMetaVariantService;

        /// <summary>
        /// The cg meta object service
        /// </summary>
        private readonly ICgMetaObjectService cgMetaObjectService;

        /// <summary>
        /// The validator
        /// </summary>
        private readonly IValidator<CgMetaVariantCreateDTO> cgMetaVariantCreateDTO;

        /// <summary>
        /// The cg meta variant dto
        /// </summary>
        private readonly IValidator<CgMetaVariantDTO> cgMetaVariantDTO;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="VariantController"/> class.
        /// </summary>
        /// <param name="cgMetaVariantService">The cg meta variant service.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="validator">The validator.</param>
        public VariantController(
            ICgMetaVariantService cgMetaVariantService
            , IMapper mapper
            , IValidator<CgMetaVariantCreateDTO> cgMetaVariantCreateDTO
            , ICgMetaObjectService cgMetaObjectService
            , IValidator<CgMetaVariantDTO> cgMetaVariantDTO
            )
        {
            this.cgMetaVariantService = cgMetaVariantService;
            this.mapper = mapper;
            this.cgMetaVariantCreateDTO = cgMetaVariantCreateDTO;
            this.cgMetaObjectService = cgMetaObjectService;
            this.cgMetaVariantDTO = cgMetaVariantDTO;
        }

        /// <summary>
        /// Get variant by id (IdColumn).
        /// </summary>
        /// <param name="id">The identifier (IdColumn).</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CgMetaVariantDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await this.cgMetaVariantService.GetById(id);

            if (result == null)
            {
                return this.NotFound();
            }
            return this.Ok(this.mapper.Map<CgMetaVariantDTO>(result));
        }

        /// <summary>
        /// Get all variants.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CgMetaVariantDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var result = await this.cgMetaVariantService.GetAll();

            if (result == null)
            {
                return this.Ok(Enumerable.Empty<CgMetaVariantDTO>());
            }
            return Ok(this.mapper.Map<IEnumerable<CgMetaVariantDTO>>(result));
        }

        /// <summary>
        /// Get all variants with corresponding configurations.
        /// </summary>
        /// <returns></returns>
        [HttpGet("WithConfigs")]
        [ProducesResponseType(typeof(IEnumerable<CgMetaVariantDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllWithConfigs()
        {
            var result = await this.cgMetaVariantService.GetAllWithConfigs();

            if (result == null)
            {
                return this.Ok(Enumerable.Empty<CgMetaVariantDTO>());
            }

            return Ok(this.mapper.Map<IEnumerable<CgMetaVariantDTO>>(result));
        }

        /// <summary>
        /// Delete one or multiple variants.
        /// </summary>
        /// <param name="ids">The identifiers (IdColumn) of variant(s) to delete.</param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromBody]IEnumerable<int> ids)
        {
            if (!this.ModelState.IsValid || ids.Count() == 0)
            {
                return this.BadRequest(this.ModelState);
            }

            try
            {
                var state = await cgMetaVariantService.DeleteMany(ids);
                return this.Ok(state);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Create new variant.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(CgMetaVariantDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateNewVariant([FromBody]CgMetaVariantCreateDTO model)
        {
            // TODO: change this validation to be in a new SP:

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var valResult = this.cgMetaVariantCreateDTO.Validate(model, new RulesetValidatorSelector("CreateNewVariant"));

            if (!valResult.IsValid)
            {
                return this.BadRequest(string.Join(" ", valResult.Errors));
            }

            if (model.TemplateCgMetaVariantIdColumn.HasValue)
            {
                var templateArea = this.cgMetaVariantService.GetById(model.TemplateCgMetaVariantIdColumn.Value);
                if (templateArea == null)
                {
                    return this.BadRequest($"Template area with IdColumn={model.TemplateCgMetaVariantIdColumn.Value} not found.");
                }
            }

            if (model.MapMetaObjctIdColumns != null && model.MapMetaObjctIdColumns.Length > 0)
            {
                var objects = await this.cgMetaObjectService.GetAllObjects();
                var notFoundIds = model.MapMetaObjctIdColumns.Where(id => !objects.Any(o => o.Id == id));

                if (notFoundIds.Any())
                {
                    return this.BadRequest("Ids of the following objects requested for direct mapping not found: " + string.Join(", ", notFoundIds));
                }
            }

            try
            {
                model.Variant.Id = 0;
                model.Variant.Id = await this.cgMetaVariantService.Create(this.mapper.Map<CgMetaVariantCreate>(model));
                return this.CreatedAtAction(nameof(this.Get), new { result = model.Variant.Id }, model.Variant);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Edit variant.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(CgMetaVariantDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Edit([FromBody]CgMetaVariantDTO model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var valResult = this.cgMetaVariantDTO.Validate(model, new RulesetValidatorSelector("EditVariant"));

            if (!valResult.IsValid)
            {
                return this.BadRequest(string.Join(" ", valResult.Errors));
            }

            var variant = this.cgMetaVariantService.GetById(model.Id);

            if (variant == null)
            {
                return NotFound();
            }

            try
            {
                model.Id = await this.cgMetaVariantService.Edit(this.mapper.Map<CgMetaVariant>(model));
                return this.Ok(model);
            }
            catch (ArgumentIdMissingException ex)
            {
                return this.BadRequest(ex.Message);
            }
            catch (ArgumentNameMissingException ex)
            {
                return this.BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
    }
}
