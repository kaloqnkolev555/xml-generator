namespace KPMG.XmlGenerator.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AutoMapper;

    using KPMG.XmlGenerator.Business;
    using KPMG.XmlGenerator.Core.DTOs;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Version Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/[controller]")]
    [Authorize(Policy = "Admin")]
    public class VersionController : Controller
    {
        private readonly ICgMetaVersionService cgMetaVersionService;
        private readonly IMapper mapper;

        public VersionController(
            ICgMetaVersionService cgMetaVersionService,
            IMapper mapper)
        {
            this.cgMetaVersionService = cgMetaVersionService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Gets all versions.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(CgMetaVersionDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var result = await this.cgMetaVersionService.GetAll();
            return (result == null) ? this.NotFound() : (IActionResult)Ok(this.mapper.Map<IEnumerable<CgMetaVersionDTO>>(result));
        }
    }
}
