namespace KPMG.XmlGenerator.Core.DTOs
{
    using System.Collections.Generic;

    /// <summary>
    /// CgMetaAreaDTO class
    /// </summary>
    public class CgMetaVariantDTO
    {
        /// <summary>
        /// Gets or sets the version identifier.
        /// </summary>
        /// <value>
        /// The version identifier.
        /// </value>
        public int VersionId { get; set; }

        /// <summary>
        /// Gets or sets the name of the variant.
        /// </summary>
        /// <value>
        /// The name of the variant.
        /// </value>
        public string VariantName { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the mapped configurations of the variant.
        /// </summary>
        /// <value>
        /// The mapped configurations of the variant.
        /// </value>
        public IEnumerable<CgMetaConfigurationDTO> MappedConfigurations { get; set; }
    }
}
