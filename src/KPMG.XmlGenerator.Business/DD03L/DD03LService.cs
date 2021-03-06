namespace KPMG.XmlGenerator.Business
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using KPMG.XmlGenerator.Core.Common;
    using KPMG.XmlGenerator.Core.Models;
    using KPMG.XmlGenerator.Data.Queries;

    /// <summary>
    /// DD03LService class
    /// </summary>
    /// <seealso cref="KPMG.XmlGenerator.Business.IDD03LService" />
    public class DD03LService : IDD03LService
    {
        /// <summary>
        /// The query handler
        /// </summary>
        private readonly IQueryHandler<DD03L> queryHandler;

        public DD03LService(IQueryHandler<DD03L> queryHandler)
        {
            this.queryHandler = queryHandler;
        }

        public async Task<DD03L> GetField(string tableName, string fieldName)
        {
            return (await this.queryHandler.QueryAsync<DD03L>(Constants.USP_CG_DD03L_SEL, new { TABNAME = tableName, FIELDNAME = fieldName })).SingleOrDefault();
        }

        public async Task<IEnumerable<DD03L>> GetFieldsForTable(string tableName)
        {
            return await this.queryHandler.QueryAsync<DD03L>(Constants.USP_CG_DD03L_SEL, new { TABNAME = tableName });
        }
    }
}
