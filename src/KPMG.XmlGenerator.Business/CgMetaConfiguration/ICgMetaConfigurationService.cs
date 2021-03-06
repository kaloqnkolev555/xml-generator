namespace KPMG.XmlGenerator.Business.CgMetaConfiguration
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KPMG.XmlGenerator.Core.Models;

    /// <summary>
    /// ICgMetaConfigurationService interface
    /// </summary>
    public interface ICgMetaConfigurationService
    {
        /// <summary>
        /// Gets all configurations.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CgMetaConfiguration>> GetAllConfigurations();

        /// <summary>
        /// Gets the configuration by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<CgMetaConfiguration> GetConfigurationById(int id);

        /// <summary>
        /// Create new configuratino.
        /// </summary>
        /// <param name="cgMetaConfigurationCreate">The new configuration.</param>
        /// <returns></returns>
        Task<int> CreateNewConfiguration(CgMetaConfigurationCreate cgMetaConfigurationCreate);

        /// <summary>
        /// Creates the new configuration.
        /// </summary>
        /// <param name="cgMetaConfigurationCreate">The cg meta configuration create.</param>
        /// <returns></returns>
        Task<int> EditConfiguration(CgMetaConfiguration cgMetaConfigurationCreate);

        /// <summary>
        /// Deletes the configuration.
        /// </summary>
        /// <param name="configurations">The configurations.</param>
        /// <returns></returns>
        Task<int> DeleteConfiguration(IEnumerable<int> configurations);
    }
}
