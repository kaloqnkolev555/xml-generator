namespace KPMG.XmlGenerator.Business.CgMetaHelperTable
{
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using KPMG.XmlGenerator.Core.Common;
    using KPMG.XmlGenerator.Data.Commands;
    using KPMG.XmlGenerator.Data.Queries;
    using KPMG.XmlGenerator.Core.Models;

    /// <summary>
    /// CgMetaHelperTableService class
    /// </summary>
    /// <seealso cref="Object" />
    /// <seealso cref="KPMG.XmlGenerator.Business.CgMetaHelperTable.ICgMetaHelperTableService" />
    public class CgMetaHelperTableService : ICgMetaHelperTableService
    {
        /// <summary>
        /// The command handler
        /// </summary>
        private readonly ICommandHandler<CgMetaHelperTable> commandHandler;

        /// <summary>
        /// The query handler
        /// </summary>
        private readonly IQueryHandler<CgMetaHelperTable> queryHandler;

        /// <summary>
        /// The version identifier
        /// </summary>
        private readonly int versionId;

        /// <summary>
        /// Initializes a new instance of the <see cref="CgMetaHelperTableService"/> class.
        /// </summary>
        /// <param name="commandHandler">The command handler.</param>
        /// <param name="queryHandler">The query handler.</param>
        /// <param name="versionService">The version service.</param>
        public CgMetaHelperTableService(ICommandHandler<CgMetaHelperTable> commandHandler
            , IQueryHandler<CgMetaHelperTable> queryHandler
            , VersionFromQueryService versionService)
        {
            this.commandHandler = commandHandler;
            this.queryHandler = queryHandler;
            this.versionId = versionService.VersionId;
        }

        /// <summary>
        /// Gets all helper tables.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CgMetaHelperTable>> GetAllHelperTables()
        {
            return await this.queryHandler.FetchAllForVersion(Constants.USP_CG_META_HELPER_TABLE_SEL, this.versionId);
        }

        /// <summary>
        /// Gets the helper table by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<CgMetaHelperTable> GetHelperTableById(int id)
        {
            return await this.queryHandler.FetchById(Constants.USP_CG_META_HELPER_TABLE_SEL, id);
        }
    }
}
