namespace KPMG.XmlGenerator.Core.DTOs
{
    public class CgMetaExtractionLogicDTO
    {
        /// <summary>
        /// Gets or sets the version identifier.
        /// </summary>
        /// <value>
        /// The version identifier.
        /// </value>
        public int VersionId { get; set; }

        /// <summary>
        /// Gets or sets the name of the extraction logic.
        /// </summary>
        /// <value>
        /// The name of the extraction logic.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the extraction logic.
        /// </summary>
        /// <value>
        /// The description of the extraction logic.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the display value for front-end
        /// </summary>
        public string CgMetaExtractionLogicName { get; set; }
    }
}
