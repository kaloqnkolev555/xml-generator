namespace KPMG.XmlGenerator.Business.CgMetaConstraintToArea
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KPMG.XmlGenerator.Core.Common;

    /// <summary>
    /// ICgMetaConstraintToAreaService interface
    /// </summary>
    public interface ICgMetaConstraintToAreaService
    {
        /// <summary>
        /// Gets constraint to area options paged with filter or no filter.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<string>> GetConOptions(int pageSize = Constants.DEFAULT_PAGE_SIZE,
            int skip = Constants.DEFAULT_SKIP_SIZE, string filter = null);

        /// <summary>
        /// Gets constraint to area values paged with filter or no filter.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<string>> GetConValues(int pageSize = Constants.DEFAULT_PAGE_SIZE,
            int skip = Constants.DEFAULT_SKIP_SIZE, string filter = null);
    }
}
