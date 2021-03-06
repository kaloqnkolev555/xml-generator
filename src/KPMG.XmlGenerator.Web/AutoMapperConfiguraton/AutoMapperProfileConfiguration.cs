namespace KPMG.XmlGenerator.Web.AutoMapperConfiguraton
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using KPMG.XmlGenerator.Core;
    using KPMG.XmlGenerator.Core.DTOs;
    using KPMG.XmlGenerator.Core.Models;

    /// <summary>
    /// AutoMapperProfileConfiguration class
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        {
            this.CreateMap<CgMetaArea, CgMetaAreaDTO>().ReverseMap();

            this.CreateMap<CgMetaAreaCreateDTO, CgMetaAreaCreate>()
                .ForMember(dto => dto.VersionId, x => x.MapFrom(a => a.Area.VersionId))
                .ForMember(dto => dto.AreaName, x => x.MapFrom(a => a.Area.AreaName))
                .ForMember(dto => dto.Id, x => x.MapFrom(a => a.Area.Id))
                .ForMember(dto => dto.MapMetaObjctIdColumns, x => x.MapFrom((a, b) => a.MapMetaObjctIdColumns != null && a.MapMetaObjctIdColumns.Length > 0 ? string.Join(',', a.MapMetaObjctIdColumns) : null));

            this.CreateMap<CgMetaAreaForTable, CgMetaAreaForTableDTO>()
                .ForPath(dto => dto.Area.VersionId, x => x.MapFrom(a => a.VersionId))
                .ForPath(dto => dto.Area.AreaName, x => x.MapFrom(a => a.AreaName))
                .ForPath(dto => dto.Area.Id, x => x.MapFrom(a => a.Id))
                .ForMember(dto => dto.CgMetaObjectName, x => x.MapFrom(a => a.CgMetaObjectName))
                .ForMember(dto => dto.ObjectIdColumn, x => x.MapFrom(a => a.ObjectIdColumn))
                .ForMember(dto => dto.DisplayName, x => x.MapFrom(a => string.Format("{0} - {1}", a.AreaName, a.CgMetaObjectName)));

            this.CreateMap<CgMetaObject, CgMetaObjectDTO>()
                .ForMember(dto => dto.MapCgMetaGroupName, x => x.MapFrom(y => y.CgMetaGroupName))
                .ForMember(dto => dto.MapCgMetaTableName, x => x.MapFrom(y => y.CgMetaTableName))
                .ForMember(dto => dto.IsDefault, x => x.MapFrom((a, b) => a.IsDefault == "1"))
                .ReverseMap()
                .ForMember(dto => dto.IsDefault, x => x.MapFrom(a => a.IsDefault ? "1" : null));

            this.CreateMap<CgMetaVersion, CgMetaVersionDTO>();

            this.CreateMap<CgMetaAreaToObjectDTO, CgMetaAreaToObject>()
                .ForMember(dto => dto.ObjctIdColumns, x => x.MapFrom((a, b) => a.ObjectColumnId != null && a.ObjectColumnId.Length > 0 ? string.Join(',', a.ObjectColumnId) : null));

            this.CreateMap<CgMetaAreaToObject, CgMetaAreaToObjectDTO>()
                .ForMember(dto => dto.ObjectColumnId, x => x.MapFrom((a, b) => a.ObjctIdColumns != null && a.ObjctIdColumns.Length > 0 ? a.ObjctIdColumns.Split(',').Select(s => Convert.ToInt32(s)).ToArray() : null));

            this.CreateMap<CgMetaConfiguration, CgMetaConfigurationDTO>().ReverseMap();

            this.CreateMap<CgMetaConfigurationCreateDTO, CgMetaConfigurationCreate>()
                .ForMember(dto => dto.VersionId, c => c.MapFrom(a => a.Configuration.VersionId))
                .ForMember(dto => dto.ConfigurationName, c => c.MapFrom(a => a.Configuration.ConfigurationName))
                .ForMember(dto => dto.Id, c => c.MapFrom(a => a.Configuration.Id))
                .ForMember(dto => dto.MapMetaVariantIdColumns, c =>
                            c.MapFrom((a, b) => a.MapMetaVariantIdColumns != null && a.MapMetaVariantIdColumns.Any() ? string.Join(',', a.MapMetaVariantIdColumns) : null));

            this.CreateMap<CgMetaVariant, CgMetaVariantDTO>().ReverseMap();

            this.CreateMap<CgMetaVariantCreateDTO, CgMetaVariantCreate>()
                .ForMember(dto => dto.VersionId, x => x.MapFrom(a => a.Variant.VersionId))
                .ForMember(dto => dto.VariantName, x => x.MapFrom(a => a.Variant.VariantName))
                .ForMember(dto => dto.Id, x => x.MapFrom(a => a.Variant.Id))
                .ForMember(dto => dto.MapMetaObjctIdColumns, x => x.MapFrom((a, b) => a.MapMetaObjctIdColumns != null && a.MapMetaObjctIdColumns.Length > 0 ? string.Join(',', a.MapMetaObjctIdColumns) : null));

            this.CreateMap<CgMetaVariantToObjectDTO, CgMetaVariantToObject>()
                .ForMember(dto => dto.ObjctIdColumns, x => x.MapFrom((a, b) => a.ObjectColumnId != null && a.ObjectColumnId.Length > 0 ? string.Join(',', a.ObjectColumnId) : null));

            this.CreateMap<CgMetaVariantToObject, CgMetaVariantToObjectDTO>()
                .ForMember(dto => dto.ObjectColumnId, x => x.MapFrom((a, b) => a.ObjctIdColumns != null && a.ObjctIdColumns.Length > 0 ? a.ObjctIdColumns.Split(',').Select(s => Convert.ToInt32(s)).ToArray() : null));

            this.CreateMap<CgMetaConfigurationToVariantDTO, CgMetaConfigurationToVariant>()
                .ForMember(dto => dto.VariantIdColumns, x => x.MapFrom((a, b) =>
                                                            a.VariantColumnId != null && a.VariantColumnId.Length > 0 ? string.Join(',', a.VariantColumnId) : null));

            this.CreateMap<CgMetaConfigurationToVariant, CgMetaConfigurationToVariantDTO>()
                .ForMember(dto => dto.VariantColumnId, x => x.MapFrom((a, b) =>
                                                            a.VariantIdColumns != null && a.VariantIdColumns.Length > 0 ? a.VariantIdColumns.Split(',').Select(s => Convert.ToInt32(s)).ToArray() : null));

            this.CreateMap<CgMetaGroup, CgMetaGroupDTO>()
                .ForMember(dto => dto.GroupIdAndLabel, x => x.MapFrom(g => $"{g.GroupId} - {g.GroupLabel}"))
                .ReverseMap();

            this.CreateMap<CgMetaTable, CgMetaTableDTO>().ReverseMap();

            this.CreateMap<CgMetaHelperTable, CgMetaHelperTableDTO>().ReverseMap();

            this.CreateMap<KeyValuePair<string, DbConnectionAppSettingsConfiguration>, DbConnectionPresentationDTO>()
                .ForMember(dto => dto.Id, x => x.MapFrom(kvp => kvp.Key))
                .ForMember(dto => dto.Name, x => x.MapFrom(kvp => kvp.Value.Name))
                .ForMember(dto => dto.Server, x => x.MapFrom(kvp => kvp.Value.Server))
                .ForMember(dto => dto.Database, x => x.MapFrom(kvp => kvp.Value.Database))
                .ForMember(dto => dto.IsActive, x => x.MapFrom(kvp => kvp.Value.IsActive))
                .ForMember(dto => dto.IsDefault, x => x.MapFrom(kvp => kvp.Value.IsDefault));

            this.CreateMap<CgMetaExtractionLogic, CgMetaExtractionLogicDTO>()
                .ForMember(dto => dto.CgMetaExtractionLogicName, x => x.MapFrom((el, y) => string.IsNullOrWhiteSpace(el.Name) ? el.Description : $"{el.Name} - {el.Description}"))
                .ReverseMap();

            this.CreateMap<DD03L, DD03LDTO>()
                .ForMember(dto => dto.TableName, x => x.MapFrom(o => o.TABNAME))
                .ForMember(dto => dto.FieldName, x => x.MapFrom(o => o.FIELDNAME))
                .ForMember(dto => dto.IsKeyField, x => x.MapFrom((o, y) => !string.IsNullOrWhiteSpace(o.KEYFLAG)));

            this.CreateMap<CgMetaColumn, DD03LDTO>()
                .ForMember(dto => dto.Id, x => x.MapFrom(o => o.Id))
                .ForMember(dto => dto.TableName, x => x.MapFrom(o => o.TableName))
                .ForMember(dto => dto.FieldName, x => x.MapFrom(o => o.ColumnName))
                .ForMember(dto => dto.IsKeyField, x => x.MapFrom((o, y) => !string.IsNullOrWhiteSpace(o.KeyFlag)));

            this.CreateMap<CgMetaTechnicalSetting, CgMetaTechnicalSettingDTO>()
                .ForMember(dto => dto.CgMetaObjectName, x => x.MapFrom(o => o.SettingObjectName))
                .ForMember(dto => dto.MapCgMetaHelperTableName, x => x.MapFrom(o => o.HelperTableName))
                .ForMember(dto => dto.MapNrObject, x => x.MapFrom(o => o.NrObject))
                .ForMember(dto => dto.MapNrField, x => x.MapFrom(o => o.NrField))
                .ForMember(dto => dto.UseNrMinMax, x => x.MapFrom(o => o.NrMin))
                .ForMember(dto => dto.UseNrMinMax, x => x.MapFrom(o => o.NrMax))
                .ForMember(dto => dto.IsParallel, x => x.MapFrom(o => o.Parallel))
                .ForMember(dto => dto.IsDefault, x => x.MapFrom(o => o.IsDefaultSetting))
                .ForPath(dto => dto.CgMetaExtractionLogic.Name, x => x.MapFrom(o => o.ExtractionLogicName))
                .ForPath(dto => dto.CgMetaExtractionLogic.Description, x => x.MapFrom(o => o.ExtractionLogicDescription))
                .ForPath(dto => dto.CgMetaExtractionLogic.Id, x => x.MapFrom(o => o.ExtractionLogicIdColumn))
                .ForPath(dto => dto.CgMetaExtractionLogic.CgMetaExtractionLogicName, x => x.MapFrom(o => string.IsNullOrWhiteSpace(o.ExtractionLogicName) ? o.ExtractionLogicDescription : $"{o.ExtractionLogicName} - {o.ExtractionLogicDescription}"))
                .ReverseMap();

            this.CreateMap<CgMetaConstraintToArea, CgMetaConstraintToAreaDTO>()
                .ForMember(dto => dto.ConstraintField, x => x.MapFrom(o => o.ConField))
                .ForMember(dto => dto.ConstraintOption, x => x.MapFrom(o => o.ConOption))
                .ForMember(dto => dto.ConstraintValue, x => x.MapFrom(o => o.ConValue))
                .ForPath(dto => dto.Area.VersionId, x => x.MapFrom(o => o.VersionId))
                .ForPath(dto => dto.Area.AreaName, x => x.MapFrom(o => o.AreaName))
                .ForPath(dto => dto.Area.Id, x => x.MapFrom(o => o.AreaIdColumn))
                .ForPath(dto => dto.Area.Description, x => x.MapFrom(o => o.AreaDescription))
               .ReverseMap();

            this.CreateMap<CgMetaHConstraintToArea, CgMetaHConstraintToAreaDTO>()
                .ForPath(dto => dto.Area.AreaName, x => x.MapFrom(o => o.AreaName))
                .ForPath(dto => dto.Area.VersionId, x => x.MapFrom(o => o.VersionId))
                .ForPath(dto => dto.Area.Id, x => x.MapFrom(o => o.AreaIdColumn))
                .ForPath(dto => dto.Area.Description, x => x.MapFrom(o => o.AreaDescription))
                .ReverseMap();

            this.CreateMap<CgMetaColumn, CgMetaColumnDTO>()
                .ForMember(dto => dto.KeyFlag, x => x.MapFrom((o, y) => !string.IsNullOrWhiteSpace(o.KeyFlag)));

            this.CreateMap<CgMetaColumnDTO, CgMetaColumn>()
                .ForMember(o => o.KeyFlag, x => x.Ignore());

            this.CreateMap<CgMetaObjectLoad, CgMetaObjectCreateDTO>()
                .ForPath(dto => dto.CgMetaObjectDTO.VersionId, x => x.MapFrom(a => a.VersionId))
                .ForPath(dto => dto.CgMetaObjectDTO.CgMetaObjectName, x => x.MapFrom(a => a.CgMetaObjectName))
                .ForPath(dto => dto.CgMetaObjectDTO.MapCgMetaGroupName, x => x.MapFrom(a => a.GroupId))
                .ForPath(dto => dto.CgMetaObjectDTO.MapCgMetaTableName, x => x.MapFrom(a => a.CgMetaTableName))
                .ForPath(dto => dto.CgMetaObjectDTO.IsFooter, x => x.MapFrom(a => a.IsFooter))
                .ForPath(dto => dto.CgMetaObjectDTO.Description, x => x.MapFrom(a => a.Description))
                .ForPath(dto => dto.CgMetaObjectDTO.IsDefault, x => x.MapFrom(a => a.IsDefault == "1"))
                .ForPath(dto => dto.CgMetaObjectDTO.Id, x => x.MapFrom(a => a.Id))
                .ForPath(dto => dto.CgMetaObjectDTO.FileName, x => x.MapFrom(a => a.FooterFileName))
                .ForPath(dto => dto.CgMetaObjectDTO.CgMetaHeaderObjectId, x => x.MapFrom(a => a.HeaderObjectId))
                .ForPath(dto => dto.CgMetaObjectDTO.HeaderObjectName, x => x.MapFrom(a => a.HeaderObjectName))
                .ForPath(dto => dto.CgMetaObjectDTO.HashTotalField, x => x.MapFrom(a => a.FooterHashTotalField))

                .ForPath(dto => dto.CgMetaObjectDTO.MapCgMetaGroup.VersionId, x => x.MapFrom(a => a.VersionId))
                .ForPath(dto => dto.CgMetaObjectDTO.MapCgMetaGroup.GroupId, x => x.MapFrom(a => a.GroupId))
                .ForPath(dto => dto.CgMetaObjectDTO.MapCgMetaGroup.GroupLabel, x => x.MapFrom(a => a.GroupLabel))
                .ForPath(dto => dto.CgMetaObjectDTO.MapCgMetaGroup.ReportId, x => x.MapFrom(a => a.GroupReportId))
                .ForPath(dto => dto.CgMetaObjectDTO.MapCgMetaGroup.IsExtract, x => x.MapFrom(a => a.GroupIsExtract))
                .ForPath(dto => dto.CgMetaObjectDTO.MapCgMetaGroup.IdColumn, x => x.MapFrom(a => a.GroupIdColumn))
                .ForPath(dto => dto.CgMetaObjectDTO.MapCgMetaGroup.GroupIdAndLabel, x => x.MapFrom(a => $"{a.GroupId} - {a.GroupLabel}"))

                .ForPath(dto => dto.CgMetaObjectTechnicalSettings, x => x.MapFrom(a => a.CgMetaObjectTechnicalSettings))
                .ForPath(dto => dto.CgMetaObjectTechnicalSettings.IsDefault, x => x.MapFrom(a => a.CgMetaObjectTechnicalSettings.IsDefaultSetting))
                .ForPath(dto => dto.CgMetaObjectTechnicalSettings.CgMetaExtractionLogic.VersionId, x => x.MapFrom(a => a.VersionId))
                .ForPath(dto => dto.CgMetaObjectTechnicalSettings.CgMetaExtractionLogic.Name, x => x.MapFrom(a => a.CgMetaObjectTechnicalSettings.ExtractionLogicName))
                .ForPath(dto => dto.CgMetaObjectTechnicalSettings.CgMetaExtractionLogic.Description, x => x.MapFrom(a => a.CgMetaObjectTechnicalSettings.ExtractionLogicDescription))
                .ForPath(dto => dto.CgMetaObjectTechnicalSettings.CgMetaExtractionLogic.Id, x => x.MapFrom(a => a.CgMetaObjectTechnicalSettings.ExtractionLogicIdColumn))
                .ForPath(dto => dto.CgMetaObjectTechnicalSettings.CgMetaExtractionLogic.CgMetaExtractionLogicName, x => x.MapFrom(a => string.IsNullOrWhiteSpace(a.CgMetaObjectTechnicalSettings.ExtractionLogicName) ? a.CgMetaObjectTechnicalSettings.ExtractionLogicDescription : $"{a.CgMetaObjectTechnicalSettings.ExtractionLogicName} - {a.CgMetaObjectTechnicalSettings.ExtractionLogicDescription}"))

                .ForPath(dto => dto.MappedAreas.MappedAreas, x => x.MapFrom(a => a.Areas))
                .ForPath(dto => dto.MappedColumns, x => x.MapFrom(a => a.Columns))
                .ForPath(dto => dto.CgMetaConstraintsArea.Constraints, x => x.MapFrom(a => a.Constraints))
                .ForPath(dto => dto.HardCodedConstraints.FaHardConstraints, x => x.MapFrom(a => a.HConstraints))
                .ForPath(dto => dto.CgMetaVariantToObject.Variants, x => x.MapFrom(a => a.Variants))
                .ForPath(dto => dto.CgMetaObjectTechnicalSettings.Dd03lFields, x => x.MapFrom(a => a.Dd03lFields.Select(f => f.FIELDNAME).ToArray()));
        }
    }
}
