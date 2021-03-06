namespace KPMG.XmlGenerator.Core.DTOs
{
    public class CgMetaConfigurationDTO
    {
        /// <summary>
        /// Gets or sets the version identifier.
        /// </summary>
        /// <value>
        /// The version identifier.
        /// </value>
        public int VersionId { get; set; }

        /// <summary>
        /// Gets or sets the name of the configuration.
        /// </summary>
        /// <value>
        /// The name of the configuration.
        /// </value>
        public string ConfigurationName { get; set; }

        /// <summary>
        /// Gets or sets the mapped variant name columns.
        /// </summary>
        /// <value>
        /// Themapped variant name columns.
        /// </value>
        public string VariantName { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
    }
}
