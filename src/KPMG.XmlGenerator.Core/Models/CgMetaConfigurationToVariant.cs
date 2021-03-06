namespace KPMG.XmlGenerator.Core.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;

    using KPMG.XmlGenerator.Core.Extensions;

    public class CgMetaConfigurationToVariant
    {
        /// <summary>
        /// Gets or sets the version identifier.
        /// </summary>
        [Column("ref_version_id")]
        public int VersionId { get; set; }

        /// <summary>
        /// Gets or sets the name of the configuration.
        /// </summary>
        [Column("configuration_name")]
        [SqlDatabaseType(SqlDbType.NVarChar)]
        [SqlDatabaseTypeSize(255)]
        public string ConfigurationName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the ids of the mapped variants.
        /// </summary>
        [Column("MapMetaVariantIdColumns")]
        [SqlDatabaseType(SqlDbType.NVarChar)]
        public string VariantIdColumns { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [Column("ConfigurationIdColumn")]
        [Key]
        public int ConfigurationColumnId { get; set; }
    }
}
