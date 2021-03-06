namespace KPMG.XmlGenerator.Business.CgMetaConfigurationToVariant
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KPMG.XmlGenerator.Core.Models;

    public interface ICgMetaConfigurationToVariantService
    {
        /// <summary>
        /// Gets all mappings between all configurations and variants.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CgMetaConfigurationToVariant>> GetAllConfigurationToVariants();

        /// <summary>
        /// Gets the variants mapped to a specific configuration.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<CgMetaConfigurationToVariant> GetAllConfigurationToVariantById(int id);

        /// <summary>
        /// Maps variants to a configuration
        /// </summary>
        /// <param name="cgMetaConfigurationToVariant">the mapping object</param>
        /// <returns></returns>
        Task<int> MapVariantToConfiguration(CgMetaConfigurationToVariant cgMetaConfigurationToVariant);
    }
}
