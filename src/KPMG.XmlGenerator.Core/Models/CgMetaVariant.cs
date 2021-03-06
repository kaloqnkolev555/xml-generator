namespace KPMG.XmlGenerator.Core.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using KPMG.XmlGenerator.Core.Comparators;
    using KPMG.XmlGenerator.Core.Extensions;

    /// <summary>
    /// CgMetaVariant class
    /// </summary>
    public class CgMetaVariant : BaseModel,  ICgMetaVariant
    {
        public CgMetaVariant()
        {
            this.MappedConfigurations = new HashSet<CgMetaConfiguration>(new BaseModelComparer());
        }
        
        /// <summary>
        /// Gets or sets the version identifier.
        /// </summary>
        /// <value>
        /// The version identifier.
        /// </value>
        [Column("ref_version_id")]
        public int VersionId { get; set; }

        /// <summary>
        /// Gets or sets the name of the variant.
        /// </summary>
        /// <value>
        /// The name of the variant.
        /// </value>
        [Column("variant_name")]
        [SqlDatabaseType(SqlDbType.NVarChar)]
        [SqlDatabaseTypeSize(255)]
        public string VariantName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [Column("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the mapped configurations of the variant.
        /// </summary>
        /// <value>
        /// The mapped configurations of the variant.
        /// </value>
        [NotMapped]
        public ICollection<CgMetaConfiguration> MappedConfigurations { get; set; }
    }
}
