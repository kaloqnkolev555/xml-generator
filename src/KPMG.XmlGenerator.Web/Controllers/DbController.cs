namespace KPMG.XmlGenerator.Web.Controllers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;

    using KPMG.XmlGenerator.Business;
    using KPMG.XmlGenerator.Core;
    using KPMG.XmlGenerator.Core.Models;

    using MediatR;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    using Microsoft.SqlServer.TransactSql.ScriptDom;

    [Route("api/[controller]")]
    [Authorize(Policy = "Admin")]
    public class DbController : Controller
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        private readonly IDictionary<string, DbConnectionAppSettingsConfiguration> dbConnectionAppSettingsConfiguration;

        public DbController(
            IMediator mediator, 
            IMapper mapper, 
            IDictionary<string, DbConnectionAppSettingsConfiguration> dbConnectionAppSettingsConfiguration,
            DbConnectionsConfigurationService dbConnectionsConfigurationService)
        {
            this.mediator = mediator;
            this.mapper = mapper;
            this.dbConnectionAppSettingsConfiguration = dbConnectionAppSettingsConfiguration;
        }

        /// <summary>
        /// Gets all configured databases
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DbConnectionPresentationDTO>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(this.dbConnectionAppSettingsConfiguration.Select(kvp => this.mapper.Map<DbConnectionPresentationDTO>(kvp)));
        }

        /// <summary>
        /// Applies all SQL scripts to the current database
        /// </summary>
        /// <returns></returns>
        [HttpGet("ApplyAllSqlScripts")]
        [ProducesResponseType(typeof(IEnumerable<DbSqlScriptExecutionResult>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ApplyAllSqlScripts()
        {
            var request = new ExecuteDbSqlScriptRequest();
            var result = await mediator.Send(request);

            return Ok(result);
        }

        [HttpPost("ValidateSqlWhereClause")]
        [ProducesResponseType(typeof(IEnumerable<ParseError>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ValidateSqlWhereClause()
        {
            string sqlWhereClause;
            using (StreamReader reader = new StreamReader(Request.Body, System.Text.Encoding.UTF8))
            {
                sqlWhereClause = await reader.ReadToEndAsync();
            }
            if (string.IsNullOrWhiteSpace(sqlWhereClause))
            {
                return BadRequest("Cannot validate empty WHERE clause!");
            }

            string selectStatement = "SELECT * FROM SomeTableName WHERE ";
            TSql150Parser parser = new TSql150Parser(false);
            var fragment = parser.Parse(new System.IO.StringReader($@"{selectStatement}
{sqlWhereClause.Replace(" GE ", " >= ").Replace(" LE ", " <= ")}"), out IList<ParseError> errors);
            return Ok(errors);
        }
    }
}
