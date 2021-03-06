namespace KPMG.XmlGenerator.Core.DTOs
{
    /// <summary>
    /// CgMetaAreaToObjectDTO class
    /// </summary>
    public class CgMetaAreaToObjectDTO
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
        public int AreaColumnId { get; set; }
    }
}
