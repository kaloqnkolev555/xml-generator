namespace KPMG.XmlGenerator.Web.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.SqlClient;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    using KPMG.XmlGenerator.Business.CgMetaObject;
    using KPMG.XmlGenerator.Core.DTOs;

    using AutoMapper;
    using FluentValidation;
    using KPMG.XmlGenerator.Core.Models;

    /// <summary>
    /// ObjectController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/[controller]")]
    [Authorize(Policy = "Admin")]
    public class ObjectController : Controller
    {
        private readonly ICgMetaObjectService cgMetaObjectService;
        private readonly IMapper mapper;
        private readonly IValidator<CgMetaObjectDTO> metaObjectCollectionValidator;
        private readonly IValidator<CgMetaObjectNameValidationDTO> objectNameValidator;

        public ObjectController(ICgMetaObjectService cgMetaObjectService,
            IMapper mapper,
            IValidator<CgMetaObjectDTO> metaObjectCollectionValidator,
            IValidator<CgMetaObjectNameValidationDTO> objectNameValidator)
        {
            this.cgMetaObjectService = cgMetaObjectService;
            this.mapper = mapper;
            this.metaObjectCollectionValidator = metaObjectCollectionValidator;
            this.objectNameValidator = objectNameValidator;
        }

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(CgMetaObjectDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllObjects()
        {
            var result = await this.cgMetaObjectService.GetAllObjects();

            if (result == null)
            {
                return this.Ok(Enumerable.Empty<CgMetaObjectDTO>());
            }
            return this.Ok(this.mapper.Map<IEnumerable<CgMetaObjectDTO>>(result));
        }

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CgMetaObjectDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetObjectById(int id)
        {
            var result = await this.cgMetaObjectService.GetObjectById(id);
            if (result == null)
            {
                return this.NotFound();
            }
            return  this.Ok(this.mapper.Map<CgMetaObjectDTO>(result));
        }

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <param name="id">The object identifier.</param>
        /// <param name="name">The object name.</param>
        /// <returns></returns>
        [HttpGet("WithAllRelations")]
        [ProducesResponseType(typeof(CgMetaObjectCreateDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetObjectWithAllRelations([FromQuery]int? id, [FromQuery]string name)
        {
            if (!id.HasValue && string.IsNullOrEmpty(name))
            {
                return this.BadRequest("Please provide object id or name.");
            }

            try
            {
                CgMetaObjectLoad obj =
                    await this.cgMetaObjectService.GetObjectWithAllRelations(id, name);
                if (obj == null)
                {
                    return this.NotFound();
                }

                return this.Ok(this.mapper.Map<CgMetaObjectCreateDTO>(obj));
            }
            catch (SqlException ex)
            {
                return this.NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Creates the new object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(CgMetaObjectDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody]CgMetaObjectCreateDTO model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (model.HardCodedConstraints != null && model.HardCodedConstraints.FaHardConstraints != null && model.HardCodedConstraints.FaHardConstraints.Any())
            {
                if (model.HardCodedConstraints.FaHardConstraints.Select(hc => hc.Area).GroupBy(a => a.AreaName).Where(g => g.Count() > 1).Count() > 0)
                {
                    return this.BadRequest("Multiple hard constraints defined for the same area");
                }
            }

            try
            {
                int? id = await this.cgMetaObjectService.Create(model);

                if (!id.HasValue)
                {
                    return this.BadRequest("Object could not be created");
                }

                model.CgMetaObjectDTO.Id = id.Value;

                return this.CreatedAtAction(nameof(this.GetObjectWithAllRelations), new { result = id.Value }, model.CgMetaObjectDTO);
            }
            catch (SqlException ex)
            {
                return this.BadRequest(ex.Message);
            }
            catch (System.Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Deletes one or more objects by id.
        /// </summary>
        /// <param name="objIds">The object ids.</param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteObject([FromBody]IEnumerable<int> objIds)
        {
            if (!this.ModelState.IsValid || objIds.Count() == 0)
            {
                return this.BadRequest(this.ModelState);
            }

            try
            {
                var state = await this.cgMetaObjectService.DeleteObjects(objIds);
                return this.Ok(state);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        [HttpPost("ValidateName")]
        [ProducesResponseType(typeof(ServerValidationResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ValidateName([FromBody]CgMetaObjectNameValidationDTO objNameDto)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var valResult = this.objectNameValidator.Validate(objNameDto, new FluentValidation.Internal.RulesetValidatorSelector(nameof(ValidateName)));

            if (!valResult.IsValid)
            {
                return this.Ok(new ServerValidationResult() { ValidationErrors = valResult.Errors.Select(err => err.ErrorMessage) });
            }

            var isNameTaken = await this.cgMetaObjectService.IsObjectNameTaken(objNameDto.Name, objNameDto.Id);

            if (isNameTaken)
            {
                return Ok(new ServerValidationResult(false, "Another object with the same name exists."));
            }

            return Ok(new ServerValidationResult(true));
        }
    }
}
