namespace KPMG.XmlGenerator.Business
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using KPMG.XmlGenerator.Core.Models;
    using KPMG.XmlGenerator.Data;
    using KPMG.XmlGenerator.Data.Helpers;

    using MediatR;

    using Microsoft.EntityFrameworkCore;

    public class DbSqlScriptsHandler : IRequestHandler<ExecuteDbSqlScriptRequest, IEnumerable<DbSqlScriptExecutionResult>>
    {
        /// <summary>
        /// The db context
        /// </summary>
        private readonly XmlGeneratorDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbSqlScriptsHandler"/> class.
        /// </summary>
        /// <param name="context">The db context.</param>
        public DbSqlScriptsHandler(XmlGeneratorDbContext context)
        {
            this.context = context;
        }

        public Task<IEnumerable<DbSqlScriptExecutionResult>> Handle(ExecuteDbSqlScriptRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(DbSqlScriptsHelper.ApplyAllSqlScripts(this.context.Database.GetDbConnection().ConnectionString));
        }
    }
}
