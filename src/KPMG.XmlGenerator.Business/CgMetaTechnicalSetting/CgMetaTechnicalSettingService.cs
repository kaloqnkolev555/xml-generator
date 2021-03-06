namespace KPMG.XmlGenerator.Business.CgMetaTechnicalSetting
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KPMG.XmlGenerator.Core.Common;
    using KPMG.XmlGenerator.Data.Queries;

    /// <summary>
    /// CgMetaTechnicalSettingService class
    /// </summary>
    /// <seealso cref="KPMG.XmlGenerator.Business.CgMetaTechnicalSetting.ICgMetaTechnicalSettingService" />
    public class CgMetaTechnicalSettingService : ICgMetaTechnicalSettingService
    {
        private readonly IQueryHandler<string> queryHandler;

        private readonly int versionId;

        /// <summary>
        /// Initializes a new instance of the <see cref="CgMetaTechnicalSettingService" /> class.
        /// </summary>
        /// <param name="queryHandler">The query handler.</param>
        /// <param name="versionService">The version from query service.</param>
        public CgMetaTechnicalSettingService(IQueryHandler<string> queryHandler,
            VersionFromQueryService versionService)
        {
            this.queryHandler = queryHandler;
            this.versionId = versionService.VersionId;
        }

        /// <summary>
        /// Gets technical setting nrobjects paged with filter or no filter.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<string>> GetNrObjects(
            int pageSize = Constants.DEFAULT_PAGE_SIZE,
            int skip = Constants.DEFAULT_SKIP_SIZE, 
            string filter = null)
        {
            return await this.queryHandler.QueryAsync<string>(
                Constants.USP_CG_META_TECHNICAL_SETTING_FIND_NROBJCT,
                new
                {
                    ref_version_id = this.versionId,
                    page_size = pageSize,
                    skip = skip,
                    filter = filter
                });
        }

        /// <summary>
        /// Gets technical setting nrfields paged with filter or no filter.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<string>> GetNrfields(
            int pageSize = Constants.DEFAULT_PAGE_SIZE,
            int skip = Constants.DEFAULT_SKIP_SIZE,
            string filter = null)
        {
            return await this.queryHandler.QueryAsync<string>(
                Constants.USP_CG_META_TECHNICAL_SETTING_FIND_NRFIELD,
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
