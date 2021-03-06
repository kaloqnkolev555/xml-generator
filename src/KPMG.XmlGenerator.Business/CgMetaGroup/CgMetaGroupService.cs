namespace KPMG.XmlGenerator.Business.CgMetaGroup
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KPMG.XmlGenerator.Core.Common;
    using KPMG.XmlGenerator.Core.Models;
    using KPMG.XmlGenerator.Data.Commands;
    using KPMG.XmlGenerator.Data.Queries;

    /// <summary>
    /// CgMetaGroupService class
    /// </summary>
    /// <seealso cref="ICgMetaGroupService" />
    public class CgMetaGroupService : ICgMetaGroupService
    {
        /// <summary>
        /// The command handler
        /// </summary>
        private readonly ICommandHandler<CgMetaGroup> commandHandler;

        /// <summary>
        /// The query handler
        /// </summary>
        private readonly IQueryHandler<CgMetaGroup> queryHandler;

        private readonly int versionId;

        /// <summary>
        /// Initializes a new instance of the <see cref="CgMetaGroupService"/> class.
        /// </summary>
        /// <param name="commandHandler">The command handler.</param>
        /// <param name="queryHandler">The query handler.</param>
        public CgMetaGroupService(ICommandHandler<CgMetaGroup> commandHandler,
            IQueryHandler<CgMetaGroup> queryHandler,
            VersionFromQueryService versionService)
        {
            this.commandHandler = commandHandler;
            this.queryHandler = queryHandler;
            this.versionId = versionService.VersionId;
        }

        /// <summary>
        /// Gets all groups.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CgMetaGroup>> GetAllGroups()
        {
            return await this.queryHandler.FetchAllForVersion(Constants.USP_CG_META_GROUP_SEL, this.versionId);
        }

        /// <summary>
        /// Gets the group identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<CgMetaGroup> GetGroupById(int id)
        {
            return await this.queryHandler.FetchById(Constants.USP_CG_META_GROUP_SEL, id);
        }
    }
}
