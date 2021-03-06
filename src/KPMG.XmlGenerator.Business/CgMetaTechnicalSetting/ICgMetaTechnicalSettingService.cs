namespace KPMG.XmlGenerator.Business.CgMetaTechnicalSetting
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KPMG.XmlGenerator.Core.Common;

    /// <summary>
    /// ICgMetaTechnicalSettingService interface
    /// </summary>
    public interface ICgMetaTechnicalSettingService
    {
        /// <summary>
        /// Gets technical setting nrobjects paged with filter or no filter.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<string>> GetNrObjects(int pageSize = Constants.DEFAULT_PAGE_SIZE,
            int skip = Constants.DEFAULT_SKIP_SIZE, string filter = null);

        /// <summary>
        /// Gets technical setting nrfields paged with filter or no filter.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<string>> GetNrfields(int pageSize = Constants.DEFAULT_PAGE_SIZE,
            int skip = Constants.DEFAULT_SKIP_SIZE, string filter = null);
    }
}
