namespace KPMG.XmlGenerator.Core.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;

    using KPMG.XmlGenerator.Core.Extensions;

    /// <summary>
    /// CgMetaVariantToObject class
    /// </summary>
    public class CgMetaVariantToObject
    {
        /// <summary>
        /// Gets or sets the version identifier.
        /// </summary>
        [Column("ref_version_id")]
        public int VersionId { get; set; }

        /// <summary>
        /// Gets or sets the name of the variant.
        /// </summary>
        [Column("variant_name")]
        [SqlDatabaseType(SqlDbType.NVarChar)]
        [SqlDatabaseTypeSize(255)]
        public string VariantName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of the variant.
        /// </summary>
        [Column("MapMetaObjctIdColumns")]
        [SqlDatabaseType(SqlDbType.NVarChar)]
        public string ObjctIdColumns { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [Column("VariantIdColumn")]
        [Key]
        public int VariantColumnId { get; set; }
    }
}
