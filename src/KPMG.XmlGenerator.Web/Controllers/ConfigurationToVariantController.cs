namespace KPMG.XmlGenerator.Web.Controllers
{
    using System.Threading.Tasks;
    using System.Linq;
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using KPMG.XmlGenerator.Core.Models;
    using KPMG.XmlGenerator.Core.DTOs;

    using AutoMapper;
    using FluentValidation;
    using FluentValidation.Internal;
    using KPMG.XmlGenerator.Business.CgMetaConfigurationToVariant;

    [Route("api/[controller]")]
    [Authorize(Policy = "Admin")]
    public class ConfigurationToVariantController : Controller
    {
        /// <summary>
        /// The cg meta configuration to variant service
        /// </summary>
        private readonly ICgMetaConfigurationToVariantService cgMetaConfigurationToVariantService;

        /// <summary>
        /// The cg meta area to object validator
        /// </summary>
        private readonly IValidator<CgMetaConfigurationToVariantDTO> cgMetaConfigurationToVariantValidator;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="AreaToObjectController"/> class.
        /// </summary>
        /// <param name="cgMetaAreaToObjectService">The cg meta area to object service.</param>
        /// <param name="mapper">The mapper.</param>
        public ConfigurationToVariantController(ICgMetaConfigurationToVariantService cgMetaConfigurationToVariantService
            , IMapper mapper
            , IValidator<CgMetaConfigurationToVariantDTO> cgMetaConfigurationToVariantValidator)
        {
            this.cgMetaConfigurationToVariantService = cgMetaConfigurationToVariantService;
            this.cgMetaConfigurationToVariantValidator = cgMetaConfigurationToVariantValidator;
            this.mapper = mapper;
        }

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(CgMetaConfigurationToVariantDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllConfigurationToVariants()
        {
            var result = await this.cgMetaConfigurationToVariantService.GetAllConfigurationToVariants();

            if (result == null)
            {
                return Ok(Enumerable.Empty<CgMetaConfigurationToVariantDTO>());

            }
            return Ok(this.mapper.Map<IEnumerable<CgMetaConfigurationToVariantDTO>>(result));
        }

        /// <summary>
        /// Gets all area to object by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CgMetaConfigurationToVariantDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllConfigurationToVariantById(int id)
        {
            var result = await this.cgMetaConfigurationToVariantService.GetAllConfigurationToVariantById(id);

            if (result == null)
            {
                return this.Ok(new CgMetaConfigurationToVariantDTO() { ConfigurationColumnId = id, VariantColumnId = new int[] { } });
            }
            return Ok(this.mapper.Map<CgMetaConfigurationToVariantDTO>(result));
        }

        /// <summary>
        /// Maps variants to a configuration
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(CgMetaConfigurationToVariantDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> MapConfigurationToVariant([FromBody]CgMetaConfigurationToVariantDTO model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var valResult = this.cgMetaConfigurationToVariantValidator.Validate(model, new RulesetValidatorSelector("MapConfigurationToVariant"));

            if (!valResult.IsValid)
            {
                return this.BadRequest(string.Join(" ", valResult.Errors));
            }

            try
            {
                var state = await this.cgMetaConfigurationToVariantService.MapVariantToConfiguration(this.mapper.Map<CgMetaConfigurationToVariant>(model));
                return this.Ok(model);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
    }
}
