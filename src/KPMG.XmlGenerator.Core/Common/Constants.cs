namespace KPMG.XmlGenerator.Core.Common
{
    /// <summary>
    /// Constants class
    /// </summary>
    public class Constants
    {
        /// <summary>
        /// Number of entries to fetch when quering
        /// </summary>
        public const int DEFAULT_PAGE_SIZE = 50;

        /// <summary>
        /// Number of entries to skip when quering
        /// </summary>
        public const int DEFAULT_SKIP_SIZE = 0;

        /// <summary>
        /// The complexity of the hard constraint
        /// </summary>
        public enum HConComplexityEnum
        {
            S,
            M,
            L
        }

        /// <summary>
        /// The user stored procedure for selecting from cg_meta_area
        /// </summary>
        public const string USP_CG_META_AREA_SEL = "[usp_cg_meta_area_sel]";

        /// <summary>
        /// The user stored procedure for selecting all areas from cg_meta_area for the same reference table
        /// </summary>
        public const string USP_CG_META_AREA_BY_REFTABLE_SEL = "[usp_cg_meta_area_by_reftable_sel]";

        /// <summary>
        /// The user stored procedure for selecting all columns from cg_meta_column mapped to an object and area
        /// </summary>
        public const string USP_CG_META_COLUMN_BY_OBJ_AREA_SEL = "[usp_cg_meta_column_by_obj_area_sel]";

        /// <summary>
        /// The user stored procedure for selecting from cg_meta_variant
        /// </summary>
        public const string USP_CG_META_VARIANT_SEL = "[usp_cg_meta_variant_sel]";

        /// <summary>
        /// The user stored procedure for selecting from cg_meta_variant along with corresponding records in cg_meta_variant_config
        /// </summary>
        public const string USP_CG_META_VARIANTS_WITH_CONFIGS_SEL = "[usp_cg_meta_variants_with_configs_sel]";

        /// <summary>
        /// The usp cg meta variant rename
        /// </summary>
        public const string USP_CG_META_VARIANT_RENAME = "[usp_cg_meta_variant_rename]";

        /// <summary>
        /// The user stored procedure for selecting from cg_meta_objct
        /// </summary>
        public const string USP_CG_META_OBJCT_SEL = "[usp_cg_meta_objct_sel]";

        /// <summary>
        /// The user stored procedure for selecting from cg_meta_objct with all related records
        /// </summary>
        public const string USP_CG_META_OBJCT_LOAD = "[usp_cg_meta_objct_load]";

        /// <summary>
        /// The user stored procedure for creating an object
        /// </summary>
        public const string USP_CG_META_OBJCT_MASTER_UPS = "[usp_cg_meta_objct_master_ups]";

        /// <summary>
        /// The user stored procedure for deleting multiple objects and their relations
        /// </summary>
        public const string USP_CG_META_OBJCT_DEL_MANY = "[usp_cg_meta_objct_del_many]";

        /// <summary>
        /// The user stored procedure for verifying if an object name is in use
        /// </summary>
        public const string USP_CG_META_OBJCT_NAME_VALIDATE = "[usp_cg_meta_objct_name_validate]";

        /// <summary>
        /// The user stored procedure for selecting from cg_meta_area_to_objct
        /// </summary>
        public const string USP_CG_META_AREA_TO_OBJECT_SEL = "[usp_cg_meta_area_to_objct_sel]";

        /// <summary>
        /// The user stored procedure for selecting from cg_meta_variant_objct
        /// </summary>
        public const string USP_CG_META_VARIANT_TO_OBJECT_SEL = "[usp_cg_meta_variant_objct_sel]";

        /// <summary>
        /// The SQL script for selecting everything from cg_meta_version
        /// </summary>
        public const string USP_CG_META_VERSION_SEL = "[usp_cg_meta_version_sel]";//"SELECT * FROM [dbo].[cg_meta_version] ORDER BY [version_id]";

        /// <summary>
        /// The user stored procedure for delete cg_meta_area
        /// </summary>
        public const string USP_CG_META_AREA_DEL = "[usp_cg_meta_area_del]";

        /// <summary>
        /// The user stored procedure for delete cg_meta_variant delete
        /// </summary>
        public const string USP_CG_META_VARIANT_DEL = "[usp_cg_meta_variant_del]";

        /// <summary>
        /// The user stored procedure for rename of cg_meta_area
        /// </summary>
        public const string USP_CG_META_AREA_RENAME = "[usp_cg_meta_area_rename]";

        /// <summary>
        /// The user stored procedure for mapping object(s) to area (table cg_meta_area_to_objct)
        /// </summary>
        public const string USP_CG_META_AREA_UPS = "[usp_cg_meta_area_ups]";

        /// <summary>
        /// The user stored procedure for mapping variants to objects
        /// </summary>
        public const string USP_CG_META_VARIANT_UPS = "[usp_cg_meta_variant_ups]";

        /// <summary>
        /// </summary>
        public const string USP_CG_META_AREA_INS = "[usp_cg_meta_area_ins]";

        /// <summary>
        /// The user stored procedure for inserting into cg_meta_variant
        /// </summary>
        public const string USP_CG_META_VARIANT_INS = "[usp_cg_meta_variant_ins]";

        /// <summary>
        /// The user stored procedure for selecting variant configurations
        /// </summary>
        public const string USP_CG_META_CONFIGURATION_SEL = "[usp_cg_meta_configuration_sel]";

        /// <summary>
        /// The user stored procedure for inserting variant configurations
        /// </summary>
        public const string USP_CG_META_CONFIGURATION_INS = "[usp_cg_meta_configuration_ins]";

        /// <summary>
        /// The usp cg meta configuration ups
        /// </summary>
        public const string USP_CG_META_CONFIGURATION_UPS = "[usp_cg_meta_configuration_ups]";

        /// <summary>
        /// The usp cg meta configuration rename
        /// </summary>
        public const string USP_CG_META_CONFIGURATION_RENAME = "[usp_cg_meta_configuration_rename]";

        /// <summary>
        /// The usp cg meta configuration delete
        /// </summary>
        public const string USP_CG_META_CONFIGURATION_DEL = "[usp_cg_meta_configuration_del]";

        /// <summary>
        /// The user stored procedure for selecting from cg_meta_variant_config
        /// </summary>
        public const string USP_CG_META_CONFIGURATION_TO_VARIANT_SEL = "[usp_cg_meta_configuration_variant_sel]";

        /// <summary>
        /// The usp cg meta group sel
        /// </summary>
        public const string USP_CG_META_GROUP_SEL = "[usp_cg_meta_group_sel]";

        /// <summary>
        /// The usp cg meta table sel
        /// </summary>
        public const string USP_CG_META_TABLE_SEL = "[usp_cg_meta_table_sel]";

        /// <summary>
        /// The usp cg meta helper table sel
        /// </summary>
        public const string USP_CG_META_HELPER_TABLE_SEL = "[usp_cg_meta_helperTable_sel]";

        /// <summary>
        /// The user stored procedure for selecting from cg_meta_extraction_logic
        /// </summary>
        public const string USP_CG_META_EXTRACTION_LOGIC_SEL = "[usp_cg_meta_extraction_logic_sel]";

        /// <summary>
        /// The usp for selecting from DD03L
        /// </summary>
        public const string USP_CG_DD03L_SEL = "[usp_DD03L_sel]";

        /// <summary>
        /// The user stored procedure for selecting and filtering nrobcts from cg_meta_technical_setting
        /// </summary>
        public const string USP_CG_META_TECHNICAL_SETTING_FIND_NROBJCT = "[usp_cg_meta_technical_setting_find_nrobjct]";

        /// <summary>
        /// The user stored procedure for selecting and filtering nrfields from cg_meta_technical_setting
        /// </summary>
        public const string USP_CG_META_TECHNICAL_SETTING_FIND_NRFIELD = "[usp_cg_meta_technical_setting_find_nrfield]";

        /// <summary>
        /// The user stored procedure for selecting and filtering options from cg_meta_constraint_to_area
        /// </summary>
        public const string USP_CG_META_CONSTRAINT_TO_AREA_FIND_CONOPTION = "[usp_cg_meta_constraint_to_area_find_conOption]";

        /// <summary>
        /// The user stored procedure for selecting and filtering conValues from cg_meta_constraint_to_area
        /// </summary>
        public const string USP_CG_META_CONSTRAINT_TO_AREA_FIND_CONVALUE = "[usp_cg_meta_constraint_to_area_find_conValue]";

        public const string TABLE_TYPE_CG_META_COLUMN = "[CgMetaColumnTableType]";

        public const string TABLE_TYPE_CG_META_CONSTRAINT = "[CgMetaConstraintTableType]";

        public const string TABLE_TYPE_CG_META_HCONSTRAINT = "[CgMetaHConstraintTableType]";
    }
}
