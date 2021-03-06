namespace KPMG.XmlGenerator.Core.Models
{
    using System.Data;
    using System.ComponentModel.DataAnnotations.Schema;

    using KPMG.XmlGenerator.Core.Extensions;

    /// <summary>
    /// CgMetaExtractionLogic class
    /// </summary>
    /// <seealso cref="KPMG.XmlGenerator.Core.Models.IBaseModel" />
    public class CgMetaExtractionLogic : BaseModel
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
        /// Gets or sets the name of the extraction logic.
        /// </summary>
        /// <value>
        /// The name of the extraction logic.
        /// </value>
        [Column("extraction_logic_name")]
        [SqlDatabaseType(SqlDbType.NVarChar)]
        [SqlDatabaseTypeSize(255)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the extraction logic.
        /// </summary>
        /// <value>
        /// The description of the extraction logic.
        /// </value>
        [Column("extraction_logic_description")]
        [SqlDatabaseType(SqlDbType.NVarChar)]
        [SqlDatabaseTypeSize(255)]
        public string Description { get; set; }
    }
}
