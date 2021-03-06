namespace KPMG.XmlGenerator.Core.DTOs
{
    /// <summary>
    /// CgMetaVariantToObjectDTO class
    /// </summary>
    public class CgMetaVariantToObjectDTO
    {
        /// <summary>
        /// Gets or sets the object identifier.
        /// </summary>
        /// <value>
        /// The object identifier.
        /// </value>
        public int[] ObjectColumnId { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int VariantColumnId { get; set; }
    }
}
