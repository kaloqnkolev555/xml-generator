namespace KPMG.XmlGenerator.Business.CgMetaHelperTable
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KPMG.XmlGenerator.Core.Models;

    /// <summary>
    /// ICgMetaHelperTableService interface
    /// </summary>
    public interface ICgMetaHelperTableService
    {
        /// <summary>
        /// Gets all helper tables.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CgMetaHelperTable>> GetAllHelperTables();

        /// <summary>
        /// Gets the helper table by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<CgMetaHelperTable> GetHelperTableById(int id);
    }
}
