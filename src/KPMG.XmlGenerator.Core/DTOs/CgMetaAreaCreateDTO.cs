namespace KPMG.XmlGenerator.Core.DTOs
{
    /// <summary>
    /// CgMetaAreaCreateDTO class
    /// </summary>
    public class CgMetaAreaCreateDTO
    {
        /// <summary>
        /// Gets or sets the area.
        /// </summary>
        /// <value>
        /// The area.
        /// </value>
        public CgMetaAreaDTO Area { get; set; }

        /// <summary>
        /// Gets or sets the template cg meta template area identifier column.
        /// </summary>
        /// <value>
        /// The template cg meta template area identifier column.
        /// </value>
        public int? TemplateCgMetaAreaIdColumn { get; set; }

        /// <summary>
        /// Gets or sets the map meta objct identifier columns.
        /// </summary>
        /// <value>
        /// The map meta objct identifier columns.
        /// </value>
        public int[] MapMetaObjctIdColumns { get; set; }
    }
}
