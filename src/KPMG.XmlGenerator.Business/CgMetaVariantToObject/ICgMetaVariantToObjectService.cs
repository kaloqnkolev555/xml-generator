namespace KPMG.XmlGenerator.Business.CgMetaVariantToObject
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KPMG.XmlGenerator.Core.Models;

    /// <summary>
    /// ICgMetaVariantToObjectService interface
    /// </summary>
    public interface ICgMetaVariantToObjectService
    {
        /// <summary>
        /// Gets all Variant to objects.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CgMetaVariantToObject>> GetAllVariantToObjects();

        /// <summary>
        /// Gets all Variant to object by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<CgMetaVariantToObject> GetAllVariantToObjectById(int id);

        /// <summary>
        /// Maps the Variant to object.
        /// </summary>
        /// <param name="cgMetaVariantToObject">The cg meta Variant to object.</param>
        /// <returns></returns>
        Task<int> MapVariantToObject(CgMetaVariantToObject cgMetaVariantToObject);
    }
}
