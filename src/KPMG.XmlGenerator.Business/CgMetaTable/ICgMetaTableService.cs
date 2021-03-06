namespace KPMG.XmlGenerator.Business.CgMetaTable
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KPMG.XmlGenerator.Core.Models;

    /// <summary>
    /// ICgMetaTableService interface
    /// </summary>
    public interface ICgMetaTableService
    {
        /// <summary>
        /// Gets all tables.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CgMetaTable>> GetAllTables();

        /// <summary>
        /// Gets the table by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<CgMetaTable> GetTableById(int id);
    }
}
