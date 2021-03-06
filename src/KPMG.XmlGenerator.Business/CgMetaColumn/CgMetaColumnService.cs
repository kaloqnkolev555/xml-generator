namespace KPMG.XmlGenerator.Business.CgMetaColumn
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KPMG.XmlGenerator.Core.Common;
    using KPMG.XmlGenerator.Core.Models;
    using KPMG.XmlGenerator.Data.Commands;
    using KPMG.XmlGenerator.Data.Queries;

    /// <summary>
    /// CgMetaColumnService class
    /// </summary>
    /// <seealso cref="KPMG.XmlGenerator.Business.CgMetaColumn.ICgMetaColumnService" />
    public class CgMetaColumnService : ICgMetaColumnService
    {
        /// <summary>
        /// The command handler
        /// </summary>
        private readonly ICommandHandler<CgMetaColumn> commandHandler;

        /// <summary>
        /// The query handler
        /// </summary>
        private readonly IQueryHandler<CgMetaColumn> queryHandler;

        private readonly int versionId;

        /// <summary>
        /// Initializes a new instance of the <see cref="CgMetaColumnService" /> class.
        /// </summary>
        /// <param name="commandHandler">The command handler.</param>
        /// <param name="queryHandler">The query handler.</param>
        /// <param name="mapper">The mapper.</param>
        public CgMetaColumnService(
            ICommandHandler<CgMetaColumn> commandHandler,
            IQueryHandler<CgMetaColumn> queryHandler,
            VersionFromQueryService versionService
            )
        {
            this.commandHandler = commandHandler;
            this.queryHandler = queryHandler;
            this.versionId = versionService.VersionId;
        }

        /// <summary>
        /// Gets all columns mapped to an object and area.
        /// </summary>
        /// <param name="cgMetaObjectName">The name of the object</param>
        /// <param name="cgMetaAreaName">The name of the area</param>
        /// <returns></returns>
        public async Task<IEnumerable<CgMetaColumn>> GetColumnsByObjectNameAreaName(string cgMetaObjectName, string cgMetaAreaName)
        {
            return await this.queryHandler.QueryAsync<CgMetaColumn>(
                Constants.USP_CG_META_COLUMN_BY_OBJ_AREA_SEL,
                new
                {
                    ref_version_id = this.versionId,
                    objct_name = cgMetaObjectName,
                    area_name = cgMetaAreaName
                });
        }
    }
}
