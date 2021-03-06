namespace KPMG.XmlGenerator.Business.CgMetaVariantToObject
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KPMG.XmlGenerator.Core.Common;
    using KPMG.XmlGenerator.Core.Models;
    using KPMG.XmlGenerator.Data.Commands;
    using KPMG.XmlGenerator.Data.Queries;


    /// <summary>
    /// CgMetaVariantToObjectService class
    /// </summary>
    /// <seealso cref="KPMG.XmlGenerator.Business.CgMetaVariantToObject.ICgMetaVariantToObjectService" />
    public class CgMetaVariantToObjectService : ICgMetaVariantToObjectService
    {
        /// <summary>
        /// The command handler
        /// </summary>
        private readonly ICommandHandler<CgMetaVariantToObject> commandHandler;

        /// <summary>
        /// The query handler
        /// </summary>
        private readonly IQueryHandler<CgMetaVariantToObject> queryHandler;

        private readonly int versionId;

        /// <summary>
        /// Initializes a new instance of the <see cref="CgMetaVariantToObjectService" /> class.
        /// </summary>
        /// <param name="commandHandler">The command handler.</param>
        /// <param name="queryHandler">The query handler.</param>
        public CgMetaVariantToObjectService(
            ICommandHandler<CgMetaVariantToObject> commandHandler,
            IQueryHandler<CgMetaVariantToObject> queryHandler,
            VersionFromQueryService versionService)
        {
            this.commandHandler = commandHandler;
            this.queryHandler = queryHandler;
            this.versionId = versionService.VersionId;
        }

        /// <summary>
        /// Gets all Variant to objects.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CgMetaVariantToObject>> GetAllVariantToObjects()
        {
            return await this.queryHandler.FetchAllForVersion(Constants.USP_CG_META_VARIANT_TO_OBJECT_SEL, this.versionId);
        }

        /// <summary>
        /// Gets mapped objects to a variant by variant identifier.
        /// </summary>
        /// <param name="id">The variant identifier.</param>
        /// <returns></returns>
        public async Task<CgMetaVariantToObject> GetAllVariantToObjectById(int id)
        {
            // TODO: Change 1 to the user-chosen version in the connect screen when it's done
            return await this.queryHandler.FetchById(Constants.USP_CG_META_VARIANT_TO_OBJECT_SEL, id);
        }

        /// <summary>
        /// Maps the Variant to object.
        /// </summary>
        /// <param name="cgMetaVariantToObject">The cg meta Variant to object.</param>
        /// <returns></returns>
        public async Task<int> MapVariantToObject(CgMetaVariantToObject cgMetaVariantToObject)
        {
            return await this.commandHandler.Save(Constants.USP_CG_META_VARIANT_UPS, cgMetaVariantToObject);
        }
    }
}
