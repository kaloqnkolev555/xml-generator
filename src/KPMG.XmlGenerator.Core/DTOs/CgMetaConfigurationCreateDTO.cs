namespace KPMG.XmlGenerator.Core.DTOs
{
    public class CgMetaConfigurationCreateDTO
    {
        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public CgMetaConfigurationDTO Configuration { get; set; }

        /// <summary>
        /// Gets or sets the mapped variant ID columns.
        /// </summary>
        /// <value>
        /// The mapped variant ID columns.
        /// </value>
        public int[] MapMetaVariantIdColumns { get; set; }
    }
}
