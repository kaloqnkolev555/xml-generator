namespace KPMG.XmlGenerator.Core.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// CgMetaGroup class
    /// </summary>
    public class CgMetaGroup
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
        /// Gets or sets the group identifier.
        /// </summary>
        /// <value>
        /// The group identifier.
        /// </value>
        [Column("group_id")]
        public string GroupId { get; set; }

        /// <summary>
        /// Gets or sets the group label.
        /// </summary>
        /// <value>
        /// The group label.
        /// </value>
        [Column("group_lable")]
        public string GroupLabel { get; set; }

        /// <summary>
        /// Gets or sets the report identifier.
        /// </summary>
        /// <value>
        /// The report identifier.
        /// </value>
        [Column("ref_report_id")]
        public int ReportId { get; set; }

        /// <summary>
        /// Gets or sets the extract.
        /// </summary>
        /// <value>
        /// The extract.
        /// </value>
        [Column("extract")]
        public bool Extract { get; set; }

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
