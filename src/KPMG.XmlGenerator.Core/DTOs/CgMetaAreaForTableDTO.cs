namespace KPMG.XmlGenerator.Core.DTOs
{
    public class CgMetaAreaForTableDTO
    {
        /// <summary>
        /// Gets or sets the area.
        /// </summary>
        /// <value>
        /// The area.
        /// </value>
        public CgMetaAreaDTO Area { get; set; }

        /// <summary>
        /// Gets or sets the object name mapped to this area for the reference table.
        /// </summary>
        /// <value>
        /// The object name mapped to this area for the reference table.
        /// </value>
        public string CgMetaObjectName { get; set; }

        /// <summary>
        /// Gets or sets the id of the object mapped to this area for the reference table.
        /// </summary>
        /// <value>
        /// The id of the object mapped to this area for the reference table.
        /// </value>
        public int ObjectIdColumn { get; set; }

        /// <summary>
        /// Gets or sets the label to be displayed on the front end as Area Name - Object Name.
        /// </summary>
        /// <value>
        /// The label to be displayed on the front end as Area Name - Object Name.
        /// </value>
        public string DisplayName { get; set; }
    }
}
