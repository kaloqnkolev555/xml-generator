namespace KPMG.XmlGenerator.Business.CgMetaConfigurationToVariant
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KPMG.XmlGenerator.Core.Common;
    using KPMG.XmlGenerator.Core.Models;
    using KPMG.XmlGenerator.Data.Commands;
    using KPMG.XmlGenerator.Data.Queries;

    public class CgMetaConfigurationToVariantService : ICgMetaConfigurationToVariantService
    {
        /// <summary>
        /// The command handler
        /// </summary>
        private readonly ICommandHandler<CgMetaConfigurationToVariant> commandHandler;

        /// <summary>
        /// The query handler
        /// </summary>
        private readonly IQueryHandler<CgMetaConfigurationToVariant> queryHandler;

        private readonly int versionId;

        /// <summary>
        /// Initializes a new instance of the <see cref="CgMetaConfigurationToVariantService" /> class.
        /// </summary>
        /// <param name="commandHandler">The command handler.</param>
        /// <param name="queryHandler">The query handler.</param>
        public CgMetaConfigurationToVariantService(
            ICommandHandler<CgMetaConfigurationToVariant> commandHandler,
            IQueryHandler<CgMetaConfigurationToVariant> queryHandler,
            VersionFromQueryService versionService)
        {
            this.commandHandler = commandHandler;
            this.queryHandler = queryHandler;
            this.versionId = versionService.VersionId;
        }

        /// <summary>
        /// Gets the variants mapped to a specific configuration.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<CgMetaConfigurationToVariant> GetAllConfigurationToVariantById(int id) =>
            await this.queryHandler.FetchById(Constants.USP_CG_META_CONFIGURATION_TO_VARIANT_SEL, id);

        /// <summary>
        /// Gets all mappings between all configurations and variants.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CgMetaConfigurationToVariant>> GetAllConfigurationToVariants() =>
            await this.queryHandler.FetchAllForVersion(Constants.USP_CG_META_CONFIGURATION_TO_VARIANT_SEL, this.versionId);

        /// <summary>
        /// Maps variants to a configuration
        /// </summary>
        /// <param name="cgMetaConfigurationToVariant">The mapping object</param>
        /// <returns></returns>
        public async Task<int> MapVariantToConfiguration(CgMetaConfigurationToVariant cgMetaConfigurationToVariant)
        {
            cgMetaConfigurationToVariant.VersionId = this.versionId;
            return await this.commandHandler.Save(Constants.USP_CG_META_CONFIGURATION_UPS, cgMetaConfigurationToVariant);
        }

    }
}
