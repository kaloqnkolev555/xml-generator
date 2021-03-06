namespace KPMG.XmlGenerator.Core.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;

    using KPMG.XmlGenerator.Core.Extensions;

    /// <summary>
    /// Represents an entity from table cg_meta_version
    /// </summary>
    public class CgMetaVersion
    {
        /// <summary>
        /// Gets or sets the version identifier.
        /// </summary>
        /// <value>
        /// The version identifier.
        /// </value>
        [Column("version_id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the area.
        /// </summary>
        /// <value>
        /// The name of the area.
        /// </value>
        [Column("version_name")]
        [SqlDatabaseType(SqlDbType.NVarChar)]
        [SqlDatabaseTypeSize(255)]
        [Required]
        public string VersionName { get; set; }
    }
}
