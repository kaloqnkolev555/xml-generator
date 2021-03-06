namespace KPMG.XmlGenerator.Core.DTOs
{
    /// <summary>
    /// DTO class for mapping variants to a configuration
    /// </summary>
    public class CgMetaConfigurationToVariantDTO
    {
        /// <summary>
        /// Gets or sets the variant identifiers
        /// </summary>
        public int[] VariantColumnId { get; set; }

        /// <summary>
        /// Gets or sets the configuration identifier
        /// </summary>
        public int ConfigurationColumnId { get; set; }
    }
}
