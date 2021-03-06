namespace KPMG.XmlGenerator.Core.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using KPMG.XmlGenerator.Core.Extensions;

    /// <summary>
    /// CgMetaObject class
    /// </summary>
    /// <seealso cref="KPMG.XmlGenerator.Core.Models.IBaseModel" />
    public class CgMetaObject : BaseModel
    {
        /// <summary>
        /// Gets or sets the version identifier.
        /// </summary>
        /// <value>
        /// The version identifier.
        /// </value>
        [Column("ref_version_id")]
        public int VersionId { get; set; }

        /// <summary>
        /// Gets or sets the name of the cg meta object.
        /// </summary>
        /// <value>
        /// The name of the cg meta object.
        /// </value>
        [Column("objct_name")]
        [SqlDatabaseType(SqlDbType.NVarChar)]
        [SqlDatabaseTypeSize(255)]
        public string CgMetaObjectName { get; set; }

        /// <summary>
        /// Gets or sets the name of the cg meta group.
        /// </summary>
        /// <value>
        /// The name of the cg meta group.
        /// </value>
        [Column("ref_group_name")]
        [SqlDatabaseType(SqlDbType.NVarChar)]
        [SqlDatabaseTypeSize(255)]
        public string CgMetaGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the cg meta table.
        /// </summary>
        /// <value>
        /// The name of the cg meta table.
        /// </value>
        [Column("ref_table_name")]
        [SqlDatabaseType(SqlDbType.NVarChar)]
        [SqlDatabaseTypeSize(255)]
        public string CgMetaTableName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is footer.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is footer; otherwise, <c>false</c>.
        /// </value>
        [Column("is_footer")]
        [SqlDatabaseType(SqlDbType.Bit)]
        public bool IsFooter { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [Column("Description")]
        [SqlDatabaseType(SqlDbType.NVarChar)]
        [SqlDatabaseTypeSize(1000)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the is default.
        /// </summary>
        /// <value>
        /// The is default.
        /// </value>
        [Column("is_default")]
        [SqlDatabaseType(SqlDbType.VarChar)]
        [SqlDatabaseTypeSize(20)]
        public string IsDefault { get; set; }
    }
}
