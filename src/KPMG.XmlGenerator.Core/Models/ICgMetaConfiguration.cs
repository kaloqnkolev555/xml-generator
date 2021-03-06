using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using KPMG.XmlGenerator.Core.Extensions;

namespace KPMG.XmlGenerator.Core.Models
{
    public interface ICgMetaConfiguration : IBaseModel
    {
        /// <summary>
        /// Gets or sets the version identifier.
        /// </summary>
        /// <value>
        /// The version identifier.
        /// </value>
        [Column("ref_version_id")]
        int VersionId { get; set; }

        /// <summary>
        /// Gets or sets the name of the configuration.
        /// </summary>
        /// <value>
        /// The name of the configuration.
        /// </value>
        [Column("configuration_name")]
        [SqlDatabaseType(SqlDbType.NVarChar)]
        [SqlDatabaseTypeSize(255)]
        string ConfigurationName { get; set; }

        /// <summary>
        /// Gets or sets the mapped variant identifier columns as a comma delimited list.
        /// </summary>
        /// <value>
        /// The mapped variant identifier columns.
        /// </value>
        [Column("ref_variant_name")]
        [SqlDatabaseType(SqlDbType.NVarChar)]
        string VariantName { get; set; }
    }
}
