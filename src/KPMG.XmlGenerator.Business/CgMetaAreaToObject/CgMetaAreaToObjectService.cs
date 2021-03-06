namespace KPMG.XmlGenerator.Business.CgMetaAreaToObject
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KPMG.XmlGenerator.Core.Common;
    using KPMG.XmlGenerator.Core.Models;
    using KPMG.XmlGenerator.Data.Commands;
    using KPMG.XmlGenerator.Data.Queries;


    /// <summary>
    /// CgMetaAreaToObjectService class
    /// </summary>
    /// <seealso cref="KPMG.XmlGenerator.Business.CgMetaAreaToObject.ICgMetaAreaToObjectService" />
    public class CgMetaAreaToObjectService : ICgMetaAreaToObjectService
    {
        /// <summary>
        /// The command handler
        /// </summary>
        private readonly ICommandHandler<CgMetaAreaToObject> commandHandler;

        /// <summary>
        /// The query handler
        /// </summary>
        private readonly IQueryHandler<CgMetaAreaToObject> queryHandler;

        private readonly int versionId;

        /// <summary>
        /// Initializes a new instance of the <see cref="CgMetaAreaToObjectService" /> class.
        /// </summary>
        /// <param name="commandHandler">The command handler.</param>
        /// <param name="queryHandler">The query handler.</param>
        /// <param name="mapper">The mapper.</param>
        public CgMetaAreaToObjectService(
            ICommandHandler<CgMetaAreaToObject> commandHandler,
            IQueryHandler<CgMetaAreaToObject> queryHandler,
            VersionFromQueryService versionService
            )
        {
            this.commandHandler = commandHandler;
            this.queryHandler = queryHandler;
            this.versionId = versionService.VersionId;
        }

        /// <summary>
        /// Gets all area to objects.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CgMetaAreaToObject>> GetAllAreaToObjects()
        {
            // TODO: Change 1 to the user-chosen version in the connect screen when it's done
            return await this.queryHandler.FetchAllForVersion(Constants.USP_CG_META_AREA_TO_OBJECT_SEL, this.versionId);
        }

        /// <summary>
        /// Gets all area to object by area identifier.
        /// </summary>
        /// <param name="id">The area identifier.</param>
        /// <returns></returns>
        public async Task<CgMetaAreaToObject> GetAllAreaToObjectById(int id)
        {
            // TODO: Change 1 to the user-chosen version in the connect screen when it's done
            return await this.queryHandler.FetchById(Constants.USP_CG_META_AREA_TO_OBJECT_SEL, id);
        }

        /// <summary>
        /// Maps the area to object.
        /// </summary>
        /// <param name="cgMetaAreaToObject">The cg meta area to object.</param>
        /// <returns></returns>
        public async Task<int> MapAreaToObject(CgMetaAreaToObject cgMetaAreaToObject)
        {
            return await this.commandHandler.Save(Constants.USP_CG_META_AREA_UPS, cgMetaAreaToObject);
        }
    }
}
