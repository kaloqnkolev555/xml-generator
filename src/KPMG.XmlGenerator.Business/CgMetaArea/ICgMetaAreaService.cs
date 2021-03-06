namespace KPMG.XmlGenerator.Business.CgMetaArea
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KPMG.XmlGenerator.Core.Models;

    /// <summary>
    /// ICgMetaAreaService interface
    /// </summary>
    public interface ICgMetaAreaService
    {
        /// <summary>
        /// Gets all areas.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CgMetaArea>> GetAllAreas();

        /// <summary>
        /// Gets the area by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<CgMetaArea> GetAreaById(int id);

        /// <summary>
        /// Deletes the area.
        /// </summary>
        /// <param name="cgMetaObject">The cg meta object.</param>
        /// <returns></returns>
        Task<int> DeleteArea(IEnumerable<int> areas);

        /// <summary>
        /// Edits the area.
        /// </summary>
        /// <param name="cgMetaObject">The cg meta object.</param>
        /// <returns></returns>
        Task<int> EditArea(CgMetaArea area);

        /// <summary>
        /// Creates the new area.
        /// </summary>
        /// <param name="cgMetaObject">The cg meta object.</param>
        /// <returns></returns>
        Task<int> CreateNewArea(CgMetaAreaCreate area);

        /// <summary>
        /// Gets all areas with mappings to a specific reference table.
        /// </summary>
        /// <param name="refTableName">The name of the table.</param>
        /// <returns></returns>
        Task<IEnumerable<CgMetaAreaForTable>> GetAllAreasForReferenceTable(string refTableName);
    }
}
