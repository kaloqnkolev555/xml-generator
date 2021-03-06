namespace KPMG.XmlGenerator.Business.CgMetaTable
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KPMG.XmlGenerator.Core.Common;
    using KPMG.XmlGenerator.Core.Models;
    using KPMG.XmlGenerator.Data.Commands;
    using KPMG.XmlGenerator.Data.Queries;

    /// <summary>
    /// CgMetaTableService class
    /// </summary>
    /// <seealso cref="ICgMetaTableService" />
    public class CgMetaTableService : ICgMetaTableService
    {
        /// <summary>
        /// The command handler
        /// </summary>
        private readonly ICommandHandler<CgMetaTable> commandHandler;

        /// <summary>
        /// The query handler
        /// </summary>
        private readonly IQueryHandler<CgMetaTable> queryHandler;

        /// <summary>
        /// The version identifier
        /// </summary>
        private readonly int versionId;

        /// <summary>
        /// Initializes a new instance of the <see cref="CgMetaTableService"/> class.
        /// </summary>
        /// <param name="commandHandler">The command handler.</param>
        /// <param name="queryHandler">The query handler.</param>
        public CgMetaTableService(
            ICommandHandler<CgMetaTable> commandHandler,
            IQueryHandler<CgMetaTable> queryHandler,
            VersionFromQueryService versionService)
        {
            this.commandHandler = commandHandler;
            this.queryHandler = queryHandler;
            this.versionId = versionService.VersionId;
        }

        /// <summary>
        /// Gets all tables.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CgMetaTable>> GetAllTables()
        {
            return await this.queryHandler.FetchAllForVersion(Constants.USP_CG_META_TABLE_SEL, this.versionId);
        }

        /// <summary>
        /// Gets the table by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<CgMetaTable> GetTableById(int id)
        {
            return await this.queryHandler.FetchById(Constants.USP_CG_META_TABLE_SEL, id);
        }
    }
}
