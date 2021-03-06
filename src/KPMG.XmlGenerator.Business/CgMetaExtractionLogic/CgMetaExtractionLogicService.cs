namespace KPMG.XmlGenerator.Business.CgMetaExtractionLogic
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KPMG.XmlGenerator.Core.Common;
    using KPMG.XmlGenerator.Core.Models;
    using KPMG.XmlGenerator.Data.Queries;

    /// <summary>
    /// CgMetaExtractionLogicService class
    /// </summary>
    /// <seealso cref="KPMG.XmlGenerator.Business.CgMetaExtractionLogic.ICgMetaExtractionLogicService" />
    public class CgMetaExtractionLogicService : ICgMetaExtractionLogicService
    {
        /// <summary>
        /// The query handler
        /// </summary>
        private readonly IQueryHandler<CgMetaExtractionLogic> queryHandler;

        private readonly int versionId;

        /// <summary>
        /// Initializes a new instance of the <see cref="CgMetaExtractionLogicService" /> class.
        /// </summary>
        /// <param name="queryHandler">The query handler.</param>
        /// <param name="versionService">The version from query service.</param>
        public CgMetaExtractionLogicService(IQueryHandler<CgMetaExtractionLogic> queryHandler,
            VersionFromQueryService versionService)
        {
            this.queryHandler = queryHandler;
            this.versionId = versionService.VersionId;
        }

        /// <summary>
        /// Gets all extraction logics.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CgMetaExtractionLogic>> GetAll()
        {
            return await this.queryHandler.FetchAllForVersion(Constants.USP_CG_META_EXTRACTION_LOGIC_SEL, this.versionId);
        }

        /// <summary>
        /// Gets the extraction logic by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<CgMetaExtractionLogic> GetById(int id)
        {
            return await this.queryHandler.FetchById(Constants.USP_CG_META_EXTRACTION_LOGIC_SEL, id);
        }
    }
}
