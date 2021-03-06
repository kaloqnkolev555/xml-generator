namespace KPMG.XmlGenerator.Business
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KPMG.XmlGenerator.Core.Models;

    /// <summary>
    /// ICgMetaVersionService interface
    /// </summary>
    public interface ICgMetaVersionService
    {
        /// <summary>
        /// Gets all items.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CgMetaVersion>> GetAll();
    }
}
