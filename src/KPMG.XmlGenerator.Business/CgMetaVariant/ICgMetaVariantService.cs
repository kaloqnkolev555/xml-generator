namespace KPMG.XmlGenerator.Business
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KPMG.XmlGenerator.Core.Models;

    /// <summary>
    /// ICgMetaAreaService interface
    /// </summary>
    public interface ICgMetaVariantService
    {
        /// <summary>
        /// Get all variants.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CgMetaVariant>> GetAll();

        /// <summary>
        /// Get all variants with configs.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CgMetaVariant>> GetAllWithConfigs();

        /// <summary>
        /// Get a variant by identifier (IdColumn).
        /// </summary>
        /// <param name="id">The identifier (IdColumn).</param>
        /// <returns></returns>
        Task<CgMetaVariant> GetById(int id);

        /// <summary>
        /// Delete one or more variants.
        /// </summary>
        /// <param name="ids">The identifiers of the entities to delete.</param>
        /// <returns></returns>
        Task<int> DeleteMany(IEnumerable<int> ids);

        /// <summary>
        /// Edit variant.
        /// </summary>
        /// <param name="variant">The entity to be edited.</param>
        /// <returns></returns>
        Task<int> Edit(CgMetaVariant variant);

        /// <summary>
        /// Create new variant.
        /// </summary>
        /// <param name="variant">The entity to be created.</param>
        /// <returns></returns>
        Task<int> Create(CgMetaVariant variant);
    }
}
