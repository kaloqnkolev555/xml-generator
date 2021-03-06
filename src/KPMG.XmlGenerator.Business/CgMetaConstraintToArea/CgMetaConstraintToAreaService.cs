namespace KPMG.XmlGenerator.Business.CgMetaConstraintToArea
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KPMG.XmlGenerator.Core.Common;
    using KPMG.XmlGenerator.Data.Queries;

    /// <summary>
    /// CgMetaConstraintToAreaService class
    /// </summary>
    /// <seealso cref="KPMG.XmlGenerator.Business.CgMetaConstraintToArea.ICgMetaConstraintToAreaService" />
    public class CgMetaConstraintToAreaService : ICgMetaConstraintToAreaService
    {
        private readonly IQueryHandler<string> queryHandler;

        private readonly int versionId;

        /// <summary>
        /// Initializes a new instance of the <see cref="CgMetaConstraintToAreaService" /> class.
        /// </summary>
        /// <param name="queryHandler">The query handler.</param>
        /// <param name="versionService">The version from query service.</param>
        public CgMetaConstraintToAreaService(IQueryHandler<string> queryHandler,
            VersionFromQueryService versionService)
        {
            this.queryHandler = queryHandler;
            this.versionId = versionService.VersionId;
        }

        public async Task<IEnumerable<string>> GetConOptions(int pageSize = Constants.DEFAULT_PAGE_SIZE,
            int skip = Constants.DEFAULT_SKIP_SIZE,
            string filter = null)
        {
            return await this.queryHandler.QueryAsync<string>(
                Constants.USP_CG_META_CONSTRAINT_TO_AREA_FIND_CONOPTION,
                new
                {
                    ref_version_id = this.versionId,
                    page_size = pageSize,
                    skip = skip,
                    filter = filter
                });
        }

        public async Task<IEnumerable<string>> GetConValues(int pageSize = Constants.DEFAULT_PAGE_SIZE,
            int skip = Constants.DEFAULT_SKIP_SIZE,
            string filter = null)
        {
            return await this.queryHandler.QueryAsync<string>(
                Constants.USP_CG_META_CONSTRAINT_TO_AREA_FIND_CONVALUE,
                new
                {
                    ref_version_id = this.versionId,
                    page_size = pageSize,
                    skip = skip,
                    filter = filter
                });
        }
    }
}
