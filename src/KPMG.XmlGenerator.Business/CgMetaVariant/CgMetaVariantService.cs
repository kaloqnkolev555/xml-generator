namespace KPMG.XmlGenerator.Business
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KPMG.XmlGenerator.Core.Common;
    using KPMG.XmlGenerator.Core.Models;
    using KPMG.XmlGenerator.Data.Commands;
    using KPMG.XmlGenerator.Data.Queries;

    /// <summary>
    /// CgMetaVariantService class
    /// </summary>
    /// <seealso cref="KPMG.XmlGenerator.Business.ICgMetaVariantService" />
    public class CgMetaVariantService : ICgMetaVariantService
    {
        /// <summary>
        /// The query handler
        /// </summary>
        private readonly IQueryHandler<CgMetaVariant> queryHandler;

        /// <summary>
        /// The command handler
        /// </summary>
        private readonly ICommandHandler<CgMetaVariant> commandHandler;

        private readonly int versionId;

        /// <summary>
        /// Initializes a new instance of the <see cref="CgMetaVariantService" /> class.
        /// </summary>
        /// <param name="commandHandler">The command handler.</param>
        /// <param name="queryHandler">The query handler.</param>
        /// <param name="mapper">The mapper.</param>
        public CgMetaVariantService(
            IQueryHandler<CgMetaVariant> queryHandler,
            ICommandHandler<CgMetaVariant> commandHandler,
            VersionFromQueryService versionService)
        {
            this.queryHandler = queryHandler;
            this.commandHandler = commandHandler;
            this.versionId = versionService.VersionId;
        }

        /// <summary>
        /// Get all variants.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CgMetaVariant>> GetAll()
        {
            return await this.queryHandler.FetchAllForVersion(Constants.USP_CG_META_VARIANT_SEL, this.versionId);
        }

        /// <summary>
        /// Get all variants with configs.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CgMetaVariant>> GetAllWithConfigs()
        {
            var variantsDictionary = new Dictionary<int, CgMetaVariant>();
            await this.queryHandler.QueryAsync<CgMetaVariant>(
                                                    Constants.USP_CG_META_VARIANTS_WITH_CONFIGS_SEL,
                                                    new Type[]
                                                   {
                                                      typeof(CgMetaVariant),
                                                      typeof(Core.Models.CgMetaConfiguration)
                                                   },
                                                    objects =>
                                                    {
                                                        CgMetaVariant variantEntry;

                                                        var variant = objects[0] as CgMetaVariant;
                                                        var config = objects[1] as Core.Models.CgMetaConfiguration;

                                                        if (!variantsDictionary.TryGetValue(variant.Id, out variantEntry))
                                                        {
                                                            variantEntry = variant;
                                                            variantsDictionary.Add(variantEntry.Id, variantEntry);
                                                        }

                                                        if (config != null)
                                                        {
                                                            variantEntry.MappedConfigurations.Add(config);
                                                        }

                                                        return variantEntry;
                                                    },
                                                    new { ref_version_id = this.versionId },
                                                    "VersionId,VariantName,ConfigurationName");

            return variantsDictionary.Values;
        }

        /// <summary>
        /// Get variant by identifier (IdColumn).
        /// </summary>
        /// <param name="id">The identifier (IdColumn).</param>
        /// <returns></returns>
        public async Task<CgMetaVariant> GetById(int id)
        {
            return await this.queryHandler.FetchById(Constants.USP_CG_META_VARIANT_SEL, id);
        }

        /// <summary>
        /// Delete one or more variants.
        /// </summary>
        /// <param name="ids">The identifiers of the entities to delete.</param>
        /// <returns></returns>
        public async Task<int> DeleteMany(IEnumerable<int> ids) => await this.commandHandler.DeleteMany(Constants.USP_CG_META_VARIANT_DEL, ids);

        /// <summary>
        /// Edit variant.
        /// </summary>
        /// <param name="variant">The entity to be edited.</param>
        /// <returns></returns>
        public async Task<int> Edit(CgMetaVariant variant) => await this.commandHandler.Save(Constants.USP_CG_META_VARIANT_RENAME, variant);

        /// <summary>
        /// Create new variant.
        /// </summary>
        /// <param name="variant">The entity to be created.</param>
        /// <returns></returns>
        public async Task<int> Create(CgMetaVariant variant) => await this.commandHandler.Save(Constants.USP_CG_META_VARIANT_INS, variant);
    }
}
