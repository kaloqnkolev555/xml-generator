namespace KPMG.XmlGenerator.Business.CgMetaArea
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KPMG.XmlGenerator.Core.Common;
    using KPMG.XmlGenerator.Core.Models;
    using KPMG.XmlGenerator.Data.Commands;
    using KPMG.XmlGenerator.Data.Queries;

    /// <summary>
    /// CgMetaAreaService class
    /// </summary>
    /// <seealso cref="KPMG.XmlGenerator.Business.CgMetaArea.ICgMetaAreaService" />
    public class CgMetaAreaService : ICgMetaAreaService
    {
        /// <summary>
        /// The command handler
        /// </summary>
        private readonly ICommandHandler<CgMetaArea> commandHandler;

        /// <summary>
        /// The query handler
        /// </summary>
        private readonly IQueryHandler<CgMetaArea> queryHandler;

        private readonly int versionId;

        /// <summary>
        /// Initializes a new instance of the <see cref="CgMetaAreaService" /> class.
        /// </summary>
        /// <param name="commandHandler">The command handler.</param>
        /// <param name="queryHandler">The query handler.</param>
        /// <param name="mapper">The mapper.</param>
        public CgMetaAreaService(
            ICommandHandler<CgMetaArea> commandHandler,
            IQueryHandler<CgMetaArea> queryHandler,
            VersionFromQueryService versionService
            )
        {
            this.commandHandler = commandHandler;
            this.queryHandler = queryHandler;
            this.versionId = versionService.VersionId;
        }

        /// <summary>
        /// Gets all area names.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CgMetaArea>> GetAllAreas()
        {
            return await this.queryHandler.FetchAllForVersion(Constants.USP_CG_META_AREA_SEL, this.versionId);
        }

        /// <summary>
        /// Gets all areas with mappings to a specific reference table.
        /// </summary>
        /// <param name="refTableName">The name of the table.</param>
        /// <returns></returns>
        public async Task<IEnumerable<CgMetaAreaForTable>> GetAllAreasForReferenceTable(string refTableName)
        {
            return await this.queryHandler.QueryAsync<CgMetaAreaForTable>(
                Constants.USP_CG_META_AREA_BY_REFTABLE_SEL,
                new { ref_version_id = this.versionId, table_name = refTableName });
        }

        /// <summary>
        /// Gets the area by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<CgMetaArea> GetAreaById(int id)
        {
            return await this.queryHandler.FetchById(Constants.USP_CG_META_AREA_SEL, id);
        }

        /// <summary>
        /// Deletes onew ore more areas.
        /// </summary>
        /// <param name="ids">The ids of areas to delete.</param>
        /// <returns></returns>
        public async Task<int> DeleteArea(IEnumerable<int> ids)
        {
            return await this.commandHandler.DeleteMany(Constants.USP_CG_META_AREA_DEL, ids);
        }

        /// <summary>
        /// Creates the new area.
        /// </summary>
        /// <param name="cgMetaArea">The cg meta area.</param>
        /// <returns></returns>
        public async Task<int> CreateNewArea(CgMetaAreaCreate area)
        {
            return await this.commandHandler.Save(Constants.USP_CG_META_AREA_INS, area);
        }

        /// <summary>
        /// Edits the area.
        /// </summary>
        /// <param name="cgMetaArea">The cg meta area.</param>
        /// <returns></returns>
        public async Task<int> EditArea(CgMetaArea area)
        {
            return await this.commandHandler.Save(Constants.USP_CG_META_AREA_RENAME, area);
        }
    }
}
