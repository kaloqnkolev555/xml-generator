namespace KPMG.XmlGenerator.Business.CgMetaAreaToObject
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KPMG.XmlGenerator.Core.Models;

    /// <summary>
    /// ICgMetaAreaToObjectService interface
    /// </summary>
    public interface ICgMetaAreaToObjectService
    {
        /// <summary>
        /// Gets all area to objects.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CgMetaAreaToObject>> GetAllAreaToObjects();

        /// <summary>
        /// Gets all area to object by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<CgMetaAreaToObject> GetAllAreaToObjectById(int id);

        /// <summary>
        /// Maps the area to object.
        /// </summary>
        /// <param name="cgMetaAreaToObject">The cg meta area to object.</param>
        /// <returns></returns>
        Task<int> MapAreaToObject(CgMetaAreaToObject cgMetaAreaToObject);
    }
}
