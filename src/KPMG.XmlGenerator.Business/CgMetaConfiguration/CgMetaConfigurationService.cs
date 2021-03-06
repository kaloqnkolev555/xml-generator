namespace KPMG.XmlGenerator.Business.CgMetaConfiguration
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KPMG.XmlGenerator.Core.Common;
    using KPMG.XmlGenerator.Core.Models;
    using KPMG.XmlGenerator.Data.Commands;
    using KPMG.XmlGenerator.Data.Queries;

    /// <summary>
    /// CgMetaConfigurationService class
    /// </summary>
    /// <seealso cref="KPMG.XmlGenerator.Business.CgMetaConfiguration.ICgMetaConfigurationService" />
    public class CgMetaConfigurationService : ICgMetaConfigurationService
    {
        /// <summary>
        /// The command handler
        /// </summary>
        private readonly ICommandHandler<CgMetaConfiguration> commandHandler;

        /// <summary>
        /// The query handler
        /// </summary>
        private readonly IQueryHandler<CgMetaConfiguration> queryHandler;

        private readonly int versionId;

        /// <summary>
        /// Initializes a new instance of the <see cref="CgMetaAreaService" /> class.
        /// </summary>
        /// <param name="commandHandler">The command handler.</param>
        /// <param name="queryHandler">The query handler.</param>
        public CgMetaConfigurationService(
            ICommandHandler<CgMetaConfiguration> commandHandler,
            IQueryHandler<CgMetaConfiguration> queryHandler,
            VersionFromQueryService versionService
            )
        {
            this.commandHandler = commandHandler;
            this.queryHandler = queryHandler;
            this.versionId = versionService.VersionId;
        }

        /// <summary>
        /// Create new configuration
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public async Task<int> CreateNewConfiguration(CgMetaConfigurationCreate configuration) =>
            await this.commandHandler.Save(Constants.USP_CG_META_CONFIGURATION_INS, configuration);

        /// <summary>
        /// Gets all configurations.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CgMetaConfiguration>> GetAllConfigurations() =>
            await this.queryHandler.FetchAllForVersion(Constants.USP_CG_META_CONFIGURATION_SEL, this.versionId);

        /// <summary>
        /// Gets the configuration by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<CgMetaConfiguration> GetConfigurationById(int id) =>
            await this.queryHandler.FetchById(Constants.USP_CG_META_CONFIGURATION_SEL, id);

        /// <summary>
        /// Edits the configuration.
        /// </summary>
        /// <param name="cgMetaConfigurationEdit">The cg meta configuration edit.</param>
        /// <returns></returns>
        public async Task<int> EditConfiguration(CgMetaConfiguration cgMetaConfigurationEdit) =>
            await this.commandHandler.Save(Constants.USP_CG_META_CONFIGURATION_RENAME, cgMetaConfigurationEdit);

        /// <summary>
        /// Deletes the configuration.
        /// </summary>
        /// <param name="configurations">The configurations.</param>
        /// <returns></returns>
        public async Task<int> DeleteConfiguration(IEnumerable<int> configurations) =>
            await this.commandHandler.DeleteMany(Constants.USP_CG_META_CONFIGURATION_DEL, configurations);
    }
}
