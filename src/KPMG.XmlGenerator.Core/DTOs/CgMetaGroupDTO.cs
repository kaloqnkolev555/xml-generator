namespace KPMG.XmlGenerator.Core.DTOs
{
    /// <summary>
    /// CgMetaGroupDTO class
    /// </summary>
    public class CgMetaGroupDTO
    {
        /// <summary>
        /// Gets or sets the version identifier.
        /// </summary>
        /// <value>
        /// The version identifier.
        /// </value>
        public int VersionId { get; set; }

        /// <summary>
        /// Gets or sets the group identifier.
        /// </summary>
        /// <value>
        /// The group identifier.
        /// </value>
        public string GroupId { get; set; }

        /// <summary>
        /// Gets or sets the group label.
        /// </summary>
        /// <value>
        /// The group label.
        /// </value>
        public string GroupLabel { get; set; }

        /// <summary>
        /// Gets or sets the report identifier.
        /// </summary>
        /// <value>
        /// The report identifier.
        /// </value>
        public int ReportId { get; set; }

        /// <summary>
        /// Gets or sets the extract flag.
        /// </summary>
        /// <value>
        /// The extract flag.
        /// </value>
        public bool IsExtract { get; set; }

        /// <summary>
        /// Gets or sets the identifier column.
        /// </summary>
        /// <value>
        /// The identifier column.
        /// </value>
        public int IdColumn { get; set; }

        /// <summary>
        /// Gets or set the display value for front-end.
        /// </summary>
        public string GroupIdAndLabel { get; set; }
    }
}
