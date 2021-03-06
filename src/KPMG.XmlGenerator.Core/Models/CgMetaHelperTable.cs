namespace KPMG.XmlGenerator.Core.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// CgMetaHelperTable class
    /// </summary>
    /// <seealso cref="Object" />
    public class CgMetaHelperTable
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
        /// Gets or sets the name of the helper table.
        /// </summary>
        /// <value>
        /// The name of the helper table.
        /// </value>
        [Column("helperTable_name")]
        public string HelperTableName { get; set; }

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
