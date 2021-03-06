namespace KPMG.XmlGenerator.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System;
    using System.Threading.Tasks;

    using AutoMapper;
    using FluentValidation;
    using FluentValidation.Internal;

    using KPMG.XmlGenerator.Business.CgMetaArea;
    using KPMG.XmlGenerator.Business.CgMetaObject;
    using KPMG.XmlGenerator.Core.DTOs;
    using KPMG.XmlGenerator.Core.Models;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// AreaController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/[controller]")]
    [Authorize(Policy = "Admin")]
    public class AreaController : Controller
    {
        /// <summary>
        /// The cg meta area service
        /// </summary>
        private readonly ICgMetaAreaService cgMetaAreaService;

         /// <summary>
        /// The cg meta area service
        /// </summary>
        private readonly ICgMetaObjectService cgMetaObjectService;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// The validator
        /// </summary>
        private readonly IValidator<CgMetaAreaCreateDTO> metaAreaCreateValidator;

        /// <summary>
        /// The cg meta area validator
        /// </summary>
        private readonly IValidator<CgMetaAreaDTO> cgMetaAreaValidator;

        /// <summary>
        /// Initializes a new instance of the <see cref="AreaController"/> class.
        /// </summary>
        /// <param name="cgMetaAreaService">The cg meta area service.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="validator">The validator.</param>
        /// <param name="collectionValidator">The collection validator.</param>
        public AreaController(ICgMetaAreaService cgMetaAreaService
            , ICgMetaObjectService cgMetaObjectService
            , IMapper mapper
            , IValidator<CgMetaAreaDTO> cgMetaAreaValidator
            , IValidator<CgMetaAreaCreateDTO> metaAreaCreateValidator)
        {
            this.cgMetaAreaService = cgMetaAreaService;
            this.cgMetaObjectService = cgMetaObjectService;
            this.mapper = mapper;
            this.cgMetaAreaValidator = cgMetaAreaValidator;
            this.metaAreaCreateValidator = metaAreaCreateValidator;
    }

        /// <summary>
        /// Gets an area by IdColumn.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CgMetaAreaDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAreaById(int id)
        {
            var result = await this.cgMetaAreaService.GetAreaById(id);

            if (result == null)
            {
                return this.NotFound();
            }
            return this.Ok(this.mapper.Map<CgMetaAreaDTO>(result));
        }

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(CgMetaAreaDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllAreas()
        {
            var result = await this.cgMetaAreaService.GetAllAreas();

            if (result == null)
            {
                return this.Ok(Enumerable.Empty<CgMetaAreaDTO>());
            }
            return this.Ok(this.mapper.Map<IEnumerable<CgMetaAreaDTO>>(result));
        }

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAreasForRefTable")]
        [ProducesResponseType(typeof(CgMetaAreaForTableDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAreasForRefTable([FromQuery(Name = "tableName")]string tableName)
        {
            if (string.IsNullOrWhiteSpace(tableName))
            {
                return this.BadRequest();
            }

            var result = await this.cgMetaAreaService.GetAllAreasForReferenceTable(tableName);

            if (result == null)
            {
                return this.Ok(Enumerable.Empty<CgMetaAreaForTableDTO>());
            }

            return this.Ok(this.mapper.Map<IEnumerable<CgMetaAreaForTableDTO>>(result));
        }

        /// <summary>
        /// Deletes the area.
        /// </summary>
        /// <param name="areas">The areas.</param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteArea([FromBody]IEnumerable<int> areas)
        {
            if (!this.ModelState.IsValid || areas.Count() == 0)
            {
                return this.BadRequest(this.ModelState);
            }

            try
            {
                var state = await cgMetaAreaService.DeleteArea(areas);
                return this.Ok(state);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Creates the new area.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(CgMetaAreaDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateNewArea([FromBody]CgMetaAreaCreateDTO model)
        {
            // TODO: change this validation to be in a new SP:
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var valResult = this.metaAreaCreateValidator.Validate(model, new RulesetValidatorSelector("CreateNewArea"));

            if (!valResult.IsValid)
            {
                return this.BadRequest(string.Join(" ", valResult.Errors));
            }

            if (model.TemplateCgMetaAreaIdColumn.HasValue)
            {
                var templateArea = this.cgMetaAreaService.GetAreaById(model.TemplateCgMetaAreaIdColumn.Value);
                if (templateArea == null)
                {
                    return this.BadRequest($"Template area with IdColumn={model.TemplateCgMetaAreaIdColumn.Value} not found.");
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
                model.Area.Id = 0;
                model.Area.Id = await this.cgMetaAreaService.CreateNewArea(this.mapper.Map<CgMetaAreaCreate>(model));
                return this.CreatedAtAction(nameof(this.GetAllAreas), new { result = model.Area.Id }, model.Area);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Edits the area.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(CgMetaAreaDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EditArea([FromBody]CgMetaAreaDTO model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var area = this.cgMetaAreaService.GetAreaById(model.Id);

            if (area == null)
            {
                return this.NotFound();
            }

            var valResult = this.cgMetaAreaValidator.Validate(model, new RulesetValidatorSelector("EditArea"));

            if (!valResult.IsValid)
            {
                return this.BadRequest(string.Join(" ", valResult.Errors));
            }

            try
            {
                model.Id = await this.cgMetaAreaService.EditArea(this.mapper.Map<CgMetaArea>(model));
                return this.Ok(model);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
    }
}
