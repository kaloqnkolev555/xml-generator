namespace KPMG.XmlGenerator.Core.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;

    using KPMG.XmlGenerator.Core.DTOs;
    using KPMG.XmlGenerator.Core.Extensions;

    /// <summary>
    /// CgMetaAreaToObject class
    /// </summary>
    public class CgMetaAreaToObject
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
        /// Gets or sets the name of the area.
        /// </summary>
        /// <value>
        /// The name of the area.
        /// </value>
        [Column("area_name")]
        [SqlDatabaseType(SqlDbType.NVarChar)]
        [SqlDatabaseTypeSize(255)]
        public string AreaName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of the area.
        /// </summary>
        /// <value>
        /// The name of the area.
        /// </value>
        [Column("MapMetaObjctIdColumns")]
        [SqlDatabaseType(SqlDbType.NVarChar)]
        public string ObjctIdColumns { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Column("AreaIdColumn")]
        [Key]
        public int AreaColumnId { get; set; }
    }
}
