namespace KPMG.XmlGenerator.Core.Models
{
    using System.Collections.Generic;

    using MediatR;

    public class ExecuteDbSqlScriptRequest : IRequest<IEnumerable<DbSqlScriptExecutionResult>>
    {
    }
}
