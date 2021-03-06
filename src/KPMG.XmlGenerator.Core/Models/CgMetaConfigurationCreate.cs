namespace KPMG.XmlGenerator.Core.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;

    using KPMG.XmlGenerator.Core.Extensions;

    public class CgMetaConfigurationCreate : CgMetaConfiguration, ICgMetaConfigurationCreate
    {
        /// <summary>
        /// Gets or sets the mapped variant ID columns.
        /// </summary>
        /// <value>
        /// The mapped variant ID columns.
        /// </value>
        [Column("MapMetaVariantIdColumns")]
        [SqlDatabaseType(SqlDbType.NVarChar)]
        public string MapMetaVariantIdColumns { get; set; }
    }
}
