namespace KPMG.XmlGenerator.Core.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    /// <summary>
    /// CgMetaTable class
    /// </summary>
    public class CgMetaTable
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
        /// Gets or sets the name of the table.
        /// </summary>
        /// <value>
        /// The name of the table.
        /// </value>
        [Column("table_name")]
        public string TableName { get; set; }

        /// <summary>
        /// Gets or sets the identifier column.
        /// </summary>
        /// <value>
        /// The identifier column.
        /// </value>
        [Key]
        [Column("IdColumn")]
        public int IdColumn { get; set; }
    }
}
