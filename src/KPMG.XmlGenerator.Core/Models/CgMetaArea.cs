namespace KPMG.XmlGenerator.Core.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;

    using KPMG.XmlGenerator.Core.Extensions;

    /// <summary>
    /// CgMetaArea class
    /// </summary>
    public class CgMetaArea : BaseModel, ICgMetaArea
    {
        public CgMetaArea()
        {
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
        /// Gets or sets the name of the area.
        /// </summary>
        /// <value>
        /// The name of the area.
        /// </value>
        [Column("area_name")]
        [SqlDatabaseType(SqlDbType.NVarChar)]
        [SqlDatabaseTypeSize(255)]
        public string AreaName { get; set; }

        /// <summary>
        /// Gets or sets the description of the area.
        /// </summary>
        /// <value>
        /// The description of the area.
        /// </value>
        [Column("description")]
        [SqlDatabaseType(SqlDbType.NVarChar)]
        [SqlDatabaseTypeSize(200)]
        public string Description { get; set; }
    }
}
