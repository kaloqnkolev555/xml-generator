namespace KPMG.XmlGenerator.Core.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;

    using KPMG.XmlGenerator.Core.Extensions;

    public class CgMetaConfiguration : BaseModel, ICgMetaConfiguration
    {
        [Column("ref_version_id")]
        public int VersionId { get; set; }

        [Column("configuration_name")]
        [SqlDatabaseType(SqlDbType.NVarChar)]
        [SqlDatabaseTypeSize(255)]
        public string ConfigurationName { get; set; }

        [Column("ref_variant_name")]
        [SqlDatabaseType(SqlDbType.NVarChar)]
        public string VariantName { get; set; }
    }
}
