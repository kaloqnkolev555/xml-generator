using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using KPMG.XmlGenerator.Core.Extensions;

namespace KPMG.XmlGenerator.Core.Models
{
    public interface ICgMetaVariant : IBaseModel
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
        /// Gets or sets the name of the variant.
        /// </summary>
        /// <value>
        /// The name of the variant.
        /// </value>
        [Column("variant_name")]
        [SqlDatabaseType(SqlDbType.NVarChar)]
        [SqlDatabaseTypeSize(255)]
        string VariantName { get; set; }

        /// <summary>
        /// Gets or sets the variant description.
        /// </summary>
        /// <value>
        /// The variant description.
        /// </value>
        [Column("description")]
        [SqlDatabaseType(SqlDbType.NVarChar)]
        string Description { get; set; }
    }
}
