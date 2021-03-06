namespace KPMG.XmlGenerator.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using FluentValidation;
    using FluentValidation.Internal;

    using KPMG.XmlGenerator.Business;
    using KPMG.XmlGenerator.Business.CgMetaConfiguration;
    using KPMG.XmlGenerator.Core.DTOs;
    using KPMG.XmlGenerator.Core.Exceptions;
    using KPMG.XmlGenerator.Core.Models;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Configuration controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/[controller]")]
    [Authorize(Policy = "Admin")]
    public class ConfigurationController : Controller
    {
        /// <summary>
        /// The cg meta config service
        /// </summary>
        private readonly ICgMetaConfigurationService cgMetaConfigurationService;

        /// <summary>
        /// The cg meta variant service
        /// </summary>
        private readonly ICgMetaVariantService cgMetaVariantService;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// The validator
        /// </summary>
        private readonly IValidator<CgMetaConfigurationCreateDTO> cgMetaConfigurationCreateValidator;

        /// <summary>
        /// The cg meta configuration validator
        /// </summary>
        private readonly IValidator<CgMetaConfigurationDTO> cgMetaConfigurationValidator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationController"/> class.
        /// </summary>
        /// <param name="cgMetaConfigurationService">The cg meta configuration service.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="cgMetaConfigurationValidator">The configuration validator.</param>
        public ConfigurationController(ICgMetaConfigurationService cgMetaConfigurationService
            , ICgMetaVariantService cgMetaVariantService
            , IMapper mapper
            , IValidator<CgMetaConfigurationDTO> cgMetaConfigurationValidator
            , IValidator<CgMetaConfigurationCreateDTO> cgMetaConfigurationCreateValidator)
        {
            this.cgMetaConfigurationService = cgMetaConfigurationService;
            this.cgMetaVariantService = cgMetaVariantService;
            this.mapper = mapper;
            this.cgMetaConfigurationValidator = cgMetaConfigurationValidator;
            this.cgMetaConfigurationCreateValidator = cgMetaConfigurationCreateValidator;
        }

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [Description("Returns all configurations")]
        [ProducesResponseType(typeof(CgMetaConfigurationDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllConfigurations()
        {
            var result = await this.cgMetaConfigurationService.GetAllConfigurations();

            if (result == null)
            {
                return this.Ok(Enumerable.Empty<CgMetaConfigurationDTO>());
            }
            return this.Ok(this.mapper.Map<IEnumerable<CgMetaConfigurationDTO>>(result));
        }

        /// <summary>
        /// Creates the new configuration.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(CgMetaConfigurationDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateNewConfiguration([FromBody]CgMetaConfigurationCreateDTO model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var res = this.cgMetaConfigurationCreateValidator.Validate(model, new RulesetValidatorSelector("CreateNewConfiguration"));

            if (!res.IsValid)
            {
                return this.BadRequest(string.Join(" ", res.Errors));
            }

            var variants = await this.cgMetaVariantService.GetAll();
            var notFoundIds = model.MapMetaVariantIdColumns.Where(id => !variants.Any(v => v.Id == id));

            if (notFoundIds.Any())
            {
                return BadRequest("Ids of the following variants selected for mapping were not found: " + string.Join(", ", notFoundIds));
            }

            model.Configuration.Id = 0;

            try
            {
                model.Configuration.Id = await this.cgMetaConfigurationService.CreateNewConfiguration(this.mapper.Map<CgMetaConfigurationCreate>(model));
            }
            catch (DuplicateFieldValueException e)
            {
                return this.BadRequest(string.Format(e.Message, "configuration name"));
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }

            return this.CreatedAtAction(nameof(this.GetAllConfigurations), new { result = model.Configuration.Id }, model.Configuration);
        }

        /// <summary>
        /// Edits the configuration.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(CgMetaConfigurationDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EditConfiguration([FromBody]CgMetaConfigurationDTO model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var valResult = this.cgMetaConfigurationValidator.Validate(model, new RulesetValidatorSelector("EditConfiguration"));

            if (!valResult.IsValid)
            {
                return this.BadRequest(string.Join(" ", valResult.Errors));
            }

            try
            {
                model.Id = await this.cgMetaConfigurationService.EditConfiguration(this.mapper.Map<CgMetaConfiguration>(model));
                return this.Ok(model);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deletes the configuration.
        /// </summary>
        /// <param name="configurations">The configurations.</param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteConfiguration([FromBody]IEnumerable<int> configurations)
        {
            if (!this.ModelState.IsValid || configurations.Count() == 0)
            {
                return this.BadRequest(this.ModelState);
            }

            try
            {
                var state = await cgMetaConfigurationService.DeleteConfiguration(configurations);
                return this.Ok(state);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
    }
}
