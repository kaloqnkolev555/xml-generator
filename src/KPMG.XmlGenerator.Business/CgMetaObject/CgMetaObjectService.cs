namespace KPMG.XmlGenerator.Business.CgMetaObject
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;

    using Dapper;

    using KPMG.XmlGenerator.Core.Common;
    using KPMG.XmlGenerator.Core.DTOs;
    using KPMG.XmlGenerator.Core.Models;
    using KPMG.XmlGenerator.Data.Commands;
    using KPMG.XmlGenerator.Data.Queries;

    using static Dapper.SqlMapper;

    /// <summary>
    /// CgMetaObjectService class
    /// </summary>
    /// <seealso cref="KPMG.XmlGenerator.Business.CgMetaObject.ICgMetaObjectService" />
    public class CgMetaObjectService : ICgMetaObjectService
    {
        /// <summary>
        /// The command handler
        /// </summary>
        private readonly ICommandHandler<CgMetaObject> commandHandler;

        /// <summary>
        /// The query handler
        /// </summary>
        private readonly IQueryHandler<CgMetaObject> queryHandler;

        /// <summary>
        /// The version id
        /// </summary>
        private readonly int versionId;

        /// <summary>
        /// Initializes a new instance of the <see cref="CgMetaObjectService" /> class.
        /// </summary>
        /// <param name="commandHandler">The command handler.</param>
        /// <param name="queryHandler">The query handler.</param>
        /// <param name="versionService">The version service.</param>
        /// d
        public CgMetaObjectService(
            ICommandHandler<CgMetaObject> commandHandler,
            IQueryHandler<CgMetaObject> queryHandler,
            VersionFromQueryService versionService)
        {
            this.commandHandler = commandHandler;
            this.queryHandler = queryHandler;
            this.versionId = versionService.VersionId;
        }

        /// <summary>
        /// Gets all objects.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CgMetaObject>> GetAllObjects()
        {
            return await this.queryHandler.FetchAllForVersion(Constants.USP_CG_META_OBJCT_SEL, this.versionId);
        }

        /// <summary>
        /// Gets the object by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<CgMetaObject> GetObjectById(int id)
        {
            return await this.queryHandler.FetchById(Constants.USP_CG_META_OBJCT_SEL, id);
        }

        /// <summary>
        /// Gets the object by identifier or name.
        /// </summary>
        /// <param name="id">The object identifier.</param>
        /// /// <param name="name">The object name.</param>
        /// <returns>The object by identifier or name</returns>
        public async Task<CgMetaObjectLoad> GetObjectWithAllRelations(int? id, string name)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ErrorCode", DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@objct_name", name, DbType.String);
            parameters.Add("@ref_version_id", this.versionId, DbType.Int32);
            parameters.Add("@IdColumn", id, DbType.Int32);

            GridReader result = await this.queryHandler.QueryMultipleAsync(Constants.USP_CG_META_OBJCT_LOAD, parameters);

            var obj = await result.ReadFirstOrDefaultAsync<CgMetaObjectLoad>();

            if (obj == null)
            {
                return null;
            }

            obj.CgMetaObjectTechnicalSettings = await result.ReadFirstOrDefaultAsync<CgMetaTechnicalSetting>();

            obj.Areas = result.Read<CgMetaArea>();

            IEnumerable<CgMetaVariantWithConfigs> variants = await result.ReadAsync<CgMetaVariantWithConfigs>();
            obj.Variants = variants
                .GroupBy(x => x.VariantName)
                .Select(x => new CgMetaVariantDTO()
                {
                    VariantName = x.Key,
                    VersionId = x.FirstOrDefault().VersionId,
                    Id = x.FirstOrDefault().Id,
                    MappedConfigurations = x
                        .Select(v => new CgMetaConfigurationDTO()
                        {
                            VersionId = v.VersionId,
                            VariantName = v.VariantName,
                            ConfigurationName = v.ConfigurationName,
                            Id = v.ConfigurationIdColumn
                        })
                });

            obj.Constraints = await result.ReadAsync<CgMetaConstraintToArea>();

            IEnumerable<CgMetaColumn> columns = await result.ReadAsync<CgMetaColumn>();
            obj.Columns = columns
                .GroupBy(x => x.AreaName)
                .Select(x => new CgMetaObjectAreaToColumnDTO()
                {
                    AreaName = x.Key,
                    VersionId = x.FirstOrDefault().VersionId,
                    Description = x.FirstOrDefault().AreaDescription,
                    Id = x.FirstOrDefault().AreaIdColumn,
                    MappedColumns = x
                        .Select(v => new CgMetaColumnDTO()
                        {
                            KeyFlag = !string.IsNullOrWhiteSpace(v.KeyFlag),
                            ColumnName = v.ColumnName,
                            AreaName = v.AreaName
                        })
                });

            obj.HConstraints = await result.ReadAsync<CgMetaHConstraintToArea>();

            obj.Dd03lFields = await result.ReadAsync<DD03L>();

            return obj;
        }

        /// <summary>
        /// Creates the new object.
        /// </summary>
        /// <param name="obj">The cg meta object.</param>
        /// <param name="step1Changed">Has step 1 changed.</param>
        /// <param name="step2Changed">Has step 2 changed.</param>
        /// <param name="step3Changed">Has step 3 changed.</param>
        /// <param name="step4Changed">Has step 4 changed.</param>
        /// <param name="step5Changed">Has step 5 changed.</param>
        /// <param name="step6Changed">Has step 6 changed.</param>
        /// <param name="step7Changed">Has step 7 changed.</param>
        /// <returns>The ID of the new object</returns>
        public async Task<int?> Create(
            CgMetaObjectCreateDTO obj,
            bool? step1Changed = null,
            bool? step2Changed = null,
            bool? step3Changed = null,
            bool? step4Changed = null,
            bool? step5Changed= null,
            bool? step6Changed = null,
            bool? step7Changed = null)
        {
            var parameters = new DynamicParameters();

            if (obj.CgMetaObjectDTO == null || obj.CgMetaObjectTechnicalSettings == null)
            {
                throw new ArgumentNullException();
            }

            parameters.Add("@ref_version_id", this.versionId, DbType.Int32);
            parameters.Add("@objct_name", obj.CgMetaObjectDTO.CgMetaObjectName, DbType.String);
            parameters.Add("@ref_group_name", obj.CgMetaObjectDTO.MapCgMetaGroup?.GroupId, DbType.String);
            parameters.Add("@ref_table_name", obj.CgMetaObjectDTO.MapCgMetaTableName, DbType.String);
            parameters.Add("@is_footer", obj.CgMetaObjectDTO.IsFooter, DbType.Boolean);
            parameters.Add("@Description", obj.CgMetaObjectDTO.Description, DbType.String);
            parameters.Add("@is_default", obj.CgMetaObjectDTO.IsDefault ? "1" : null, DbType.String);
            parameters.Add("@header_obct_name", obj.CgMetaObjectDTO.HeaderObjectName, DbType.String);
            parameters.Add("@footerFileName", obj.CgMetaObjectDTO.FileName, DbType.String);
            parameters.Add("@footerHashTotalField", obj.CgMetaObjectDTO.HashTotalField, DbType.String);
            parameters.Add("@ObjectIdColumn", obj.CgMetaObjectDTO.Id, DbType.Int32);

            parameters.Add("@extraction_logic_name", obj.CgMetaObjectTechnicalSettings.CgMetaExtractionLogic?.Name, DbType.String);
            parameters.Add("@helperTable_name", obj.CgMetaObjectTechnicalSettings.MapCgMetaHelperTableName, DbType.String);
            parameters.Add("@dayByDay", obj.CgMetaObjectTechnicalSettings.DayByDay, DbType.String);
            parameters.Add("@daysPerLoop", obj.CgMetaObjectTechnicalSettings.DaysPerLoop, DbType.Int32);
            parameters.Add("@nrobjct", obj.CgMetaObjectTechnicalSettings.MapNrObject, DbType.String);
            parameters.Add("@nrfield", obj.CgMetaObjectTechnicalSettings.MapNrField, DbType.String);
            parameters.Add("@nrMin", obj.CgMetaObjectTechnicalSettings.UseNrMinMax, DbType.Boolean);
            parameters.Add("@nrMax", obj.CgMetaObjectTechnicalSettings.UseNrMinMax, DbType.Boolean);
            parameters.Add("@parallel", obj.CgMetaObjectTechnicalSettings.IsParallel.HasValue && obj.CgMetaObjectTechnicalSettings.IsParallel.Value ? 1 : 0, DbType.Int32);
            parameters.Add("@pkgSize", obj.CgMetaObjectTechnicalSettings.PkgSize, DbType.Int32);
            parameters.Add("@pkgSize2", obj.CgMetaObjectTechnicalSettings.PkgSize2, DbType.Int32);
            parameters.Add("@xFilename", obj.CgMetaObjectTechnicalSettings.XFilename, DbType.String);
            parameters.Add("@hashtotalField", obj.CgMetaObjectTechnicalSettings.HashTotalField, DbType.String);
            parameters.Add("@ts_is_default", obj.CgMetaObjectTechnicalSettings.IsDefault, DbType.Boolean);
            parameters.Add("@docNbr", obj.CgMetaObjectTechnicalSettings.DocNbr, DbType.String);
            parameters.Add("@loopAt", obj.CgMetaObjectTechnicalSettings.LoopAt, DbType.String);

            if (obj.MappedAreas != null && obj.MappedAreas.MappedAreas.Any())
            {
                string mappedAreaIds = string.Join(",", obj.MappedAreas.MappedAreas.Select(x => x.Id.ToString()));
                parameters.Add("@MappedAreaIds", mappedAreaIds, DbType.String);
            }

            var constraintsDataTable = this.GetConstraintsDataTable();

            if (obj.CgMetaConstraintsArea != null && obj.CgMetaConstraintsArea.Constraints.Any())
            {
                foreach (var constraint in obj.CgMetaConstraintsArea.Constraints)
                {
                    constraintsDataTable.Rows.Add(constraint.ConstraintField, constraint.ConstraintOption,
                        constraint.ConstraintValue, constraint.Area?.AreaName, constraint.InSQL,
                        constraint.Priority);
                }
            }

            parameters.Add("@MappedConstraints",
                constraintsDataTable.AsTableValuedParameter(
                    Constants.TABLE_TYPE_CG_META_CONSTRAINT));

            var hConstraintsDataTable = this.GetHardConstraintsDataTable();

            if (obj.HardCodedConstraints != null && obj.HardCodedConstraints.FaHardConstraints.Any())
            {
                foreach (var hConstraint in obj.HardCodedConstraints.FaHardConstraints)
                {
                    var lines = hConstraint.ConstraintContent
                        .Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                        .Where(l => !string.IsNullOrWhiteSpace(l))
                        .ToArray();

                    if (lines.Length > 0)
                    {
                        var conLine = 1;

                        for (int i = 0; i < lines.Length; i++)
                        {
                            string isComplexLine = null;
                            if (lines.Length > 1)
                            {
                                isComplexLine = Constants.HConComplexityEnum.M.ToString();
                                if (i == 0)
                                {
                                    isComplexLine = Constants.HConComplexityEnum.S.ToString();
                                }
                                else if (i == lines.Length - 1)
                                {
                                    isComplexLine = Constants.HConComplexityEnum.L.ToString();
                                }
                            }

                            hConstraintsDataTable.Rows.Add(
                                hConstraint.HConstraintName,
                                conLine++,
                                lines[i],
                                hConstraint.Area?.AreaName,
                                hConstraint.Priority,
                                isComplexLine,
                                hConstraint.IsDefaultNoConstraint ? "X" : null);
                        }
                    }
                }
            }

            parameters.Add("@MappedHConstraints",
                hConstraintsDataTable.AsTableValuedParameter(
                    Constants.TABLE_TYPE_CG_META_HCONSTRAINT));

            var columnsDataTable = this.GetColumnsDataTable();

            if (obj.MappedColumns != null && obj.MappedColumns.Any())
            {
                foreach (var areaToCol in obj.MappedColumns)
                {
                    foreach (var col in areaToCol.MappedColumns)
                    {
                        columnsDataTable.Rows.Add(areaToCol.AreaName, col.ColumnName);
                    }
                }
            }

            parameters.Add("@MappedColumns", columnsDataTable.AsTableValuedParameter(Constants.TABLE_TYPE_CG_META_COLUMN));

            if (obj.CgMetaVariantToObject != null && obj.CgMetaVariantToObject.Variants.Any())
            {
                string mappedVariantIds = string.Join(",", obj.CgMetaVariantToObject.Variants.Select(x => x.Id.ToString()));
                parameters.Add("@MappedVariantIds", mappedVariantIds, DbType.String);
            }

            parameters.Add("@Step1CgMetaObjChanged", step1Changed, DbType.Boolean);
            parameters.Add("@Step2ObjTechSettingsChanged", step2Changed, DbType.Boolean);
            parameters.Add("@Step3ObjAreasChanged", step3Changed, DbType.Boolean);
            parameters.Add("@Step4ObjAreasColumnsChanged", step4Changed, DbType.Boolean);
            parameters.Add("@Step5ObjConstraintsChanged", step5Changed, DbType.Boolean);
            parameters.Add("@Step6ObjHardConstraintsChanged", step6Changed, DbType.Boolean);
            parameters.Add("@Step7ObjVariantsChanged", step7Changed, DbType.Boolean);
            parameters.Add("@NewObjctIdColumn", DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@ErrorCode", DbType.Int32, direction: ParameterDirection.Output);

            await this.queryHandler.QueryAsync<CgMetaObject>(
                Constants.USP_CG_META_OBJCT_MASTER_UPS,
                parameters);

            var newObjctIdColumn = parameters.Get<int?>("@NewObjctIdColumn");

            return newObjctIdColumn;
        }

        private DataTable GetConstraintsDataTable()
        {
            var constraintsDataTable = new DataTable(Constants.TABLE_TYPE_CG_META_CONSTRAINT);
            constraintsDataTable.Columns.Add("constraintField", typeof(string));
            constraintsDataTable.Columns.Add("constraintOption", typeof(string));
            constraintsDataTable.Columns.Add("constraintValue", typeof(string));
            constraintsDataTable.Columns.Add("area_name", typeof(string));
            constraintsDataTable.Columns.Add("InSQL", typeof(bool));
            constraintsDataTable.Columns.Add("priority", typeof(int));

            return constraintsDataTable;
        }

        private DataTable GetHardConstraintsDataTable()
        {
            var hConstraintsDataTable = new DataTable(Constants.TABLE_TYPE_CG_META_HCONSTRAINT);
            hConstraintsDataTable.Columns.Add("hconstraint_name", typeof(string));
            hConstraintsDataTable.Columns.Add("conLine", typeof(int));
            hConstraintsDataTable.Columns.Add("conContent", typeof(string));
            hConstraintsDataTable.Columns.Add("area_name", typeof(string));
            hConstraintsDataTable.Columns.Add("priority", typeof(int));
            hConstraintsDataTable.Columns.Add("is_complex_line", typeof(string));
            hConstraintsDataTable.Columns.Add("is_default_no_constraint", typeof(string));

            return hConstraintsDataTable;
        }

        private DataTable GetColumnsDataTable()
        {
            var columnsDataTable = new DataTable(Constants.TABLE_TYPE_CG_META_COLUMN);
            columnsDataTable.Columns.Add("area_name", typeof(string));
            columnsDataTable.Columns.Add("column_name", typeof(string));

            return columnsDataTable;
        }

        /// <summary>
        /// Deletes one ore more objects.
        /// </summary>
        /// <param name="ids">The ids of the objects to delete.</param>
        /// <returns></returns>
        public async Task<int> DeleteObjects(IEnumerable<int> ids)
        {
            return await this.commandHandler.DeleteMany(Constants.USP_CG_META_OBJCT_DEL_MANY, ids);
        }

        /// <summary>
        /// Checks if an object name is already in use for the current version.
        /// </summary>
        /// <param name="objct_name">Object name to check.</param>
        /// <param name="idColumn">The IdColumn value when an object is being edited.</param>
        /// <returns><c>true</c> if the name is already in use; otherwise, <c>false</c></returns>
        public async Task<bool> IsObjectNameTaken(string objct_name, int? idColumn)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdColumn", idColumn, DbType.Int32);
            parameters.Add("@ref_version_id", this.versionId, DbType.Int32);
            parameters.Add("@objct_name", objct_name, DbType.String);
            parameters.Add("@objct_name_taken", DbType.Boolean, direction: ParameterDirection.Output);

            await this.queryHandler.QueryAsync<CgMetaObject>(
                Constants.USP_CG_META_OBJCT_NAME_VALIDATE,
                parameters);

            return parameters.Get<int>("@objct_name_taken") == 1;
        }
    }
}
