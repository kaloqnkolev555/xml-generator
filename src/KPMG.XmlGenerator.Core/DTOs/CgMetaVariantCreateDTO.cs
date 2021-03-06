namespace KPMG.XmlGenerator.Core.DTOs
{
    /// <summary>
    /// CgMetaVariantCreateDTO class
    /// </summary>
    public class CgMetaVariantCreateDTO
    {
        /// <summary>
        /// Gets or sets the variant.
        /// </summary>
        /// <value>
        /// The variant.
        /// </value>
        public CgMetaVariantDTO Variant { get; set; }

        /// <summary>
        /// Gets or sets the template cg meta variant identifier column.
        /// </summary>
        /// <value>
        /// The template cg meta variant identifier column.
        /// </value>
        public int? TemplateCgMetaVariantIdColumn { get; set; }

        /// <summary>
        /// Gets or sets the map meta objct identifier columns.
        /// </summary>
        /// <value>
        /// The map meta objct identifier columns.
        /// </value>
        public int[] MapMetaObjctIdColumns { get; set; }
    }
}
