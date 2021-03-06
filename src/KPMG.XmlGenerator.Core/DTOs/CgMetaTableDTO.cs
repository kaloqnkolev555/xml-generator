namespace KPMG.XmlGenerator.Core.DTOs
{
    /// <summary>
    /// CgMetaTableDTO class
    /// </summary>
    public class CgMetaTableDTO
    {
        /// <summary>
        /// Gets or sets the version identifier.
        /// </summary>
        /// <value>
        /// The version identifier.
        /// </value>
        public int VersionId { get; set; }

        /// <summary>
        /// Gets or sets the name of the table.
        /// </summary>
        /// <value>
        /// The name of the table.
        /// </value>
        public string TableName { get; set; }

        /// <summary>
        /// Gets or sets the identifier column.
        /// </summary>
        /// <value>
        /// The identifier column.
        /// </value>
        public int IdColumn { get; set; }
    }
}
