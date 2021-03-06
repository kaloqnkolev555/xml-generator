namespace KPMG.XmlGenerator.Business
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KPMG.XmlGenerator.Core.Common;
    using KPMG.XmlGenerator.Core.Models;
    using KPMG.XmlGenerator.Data.Queries;

    public class CgMetaVersionService : ICgMetaVersionService
    {
        private readonly IQueryHandler<CgMetaVersion> queryHandler;

        public CgMetaVersionService(IQueryHandler<CgMetaVersion> queryHandler)
        {
            this.queryHandler = queryHandler;
        }

        public async Task<IEnumerable<CgMetaVersion>> GetAll()
        {
            return await this.queryHandler.FetchAllForVersion(Constants.USP_CG_META_VERSION_SEL, null);
        }
    }
}
