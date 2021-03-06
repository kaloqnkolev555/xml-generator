namespace KPMG.XmlGenerator.Business.CgMetaExtractionLogic
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KPMG.XmlGenerator.Core.Models;

    /// <summary>
    /// ICgMetaExtractionLogicService interface
    /// </summary>
    public interface ICgMetaExtractionLogicService
    {
        /// <summary>
        /// Gets all extraction logics.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CgMetaExtractionLogic>> GetAll();

        /// <summary>
        /// Gets the extraction logic by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<CgMetaExtractionLogic> GetById(int id);
    }
}
