namespace KPMG.XmlGenerator.Core.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using KPMG.XmlGenerator.Core.Extensions;

    public class CgMetaColumn : BaseModel
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
        /// Gets or sets the name of the reference table.
        /// </summary>
        /// <value>
        /// The name of the reference.
        /// </value>
        [Column("TABNAME")]
        [SqlDatabaseType(SqlDbType.NVarChar)]
        [SqlDatabaseTypeSize(255)]
        public string TableName { get; set; }

        /// <summary>
        /// Gets or sets the name of the column.
        /// </summary>
        /// <value>
        /// The name of the column.
        /// </value>
        [Column("column_name")]
        [SqlDatabaseType(SqlDbType.NVarChar)]
        [SqlDatabaseTypeSize(255)]
        public string ColumnName { get; set; }

        /// <summary>
        /// Gets or sets the key flag for the column.
        /// </summary>
        /// <value>
        /// The key flag for the column.
        /// </value>
        [Column("KEYFLAG")]
        [SqlDatabaseType(SqlDbType.NVarChar)]
        [SqlDatabaseTypeSize(2)]
        public string KeyFlag { get; set; }

        /// <summary>
        /// Gets or sets the area name of the column.
        /// </summary>
        /// <value>
        /// The area name of the column.
        /// </value>
        [Column("ref_area_name")]
        [SqlDatabaseType(SqlDbType.NVarChar)]
        [SqlDatabaseTypeSize(255)]
        public string AreaName { get; set; }

        public int AreaIdColumn { get; set; }

        public string AreaDescription { get; set; }
    }
}
