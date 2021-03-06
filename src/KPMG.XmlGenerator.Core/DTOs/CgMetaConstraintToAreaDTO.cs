namespace KPMG.XmlGenerator.Core.DTOs
{
    public class CgMetaConstraintToAreaDTO
    {
        /// <summary>
        /// Gets or sets the version identifier.
        /// </summary>
        /// <value>
        /// The version identifier.
        /// </value>
        public int VersionId { get; set; }

        /// <summary>
        /// Gets or sets the name of the helper table.
        /// </summary>
        /// <value>
        /// The name of the helper table.
        /// </value>
        public string ExtractionLogicName { get; set; }

        /// <summary>
        /// Gets or sets the name of the object.
        /// </summary>
        /// <value>
        /// The name of the object.
        /// </value>
        public string CgMetaObjectName { get; set; }

        /// <summary>
        /// Gets or sets the conField.
        /// </summary>
        /// <value>
        /// The conField.
        /// </value>
        public string ConstraintField { get; set; }

        /// <summary>
        /// Gets or sets the conOption.
        /// </summary>
        /// <value>
        /// The conOption.
        /// </value>
        public string ConstraintOption { get; set; }

        /// <summary>
        /// Gets or sets the conValue.
        /// </summary>
        /// <value>
        /// The conValue.
        /// </value>
        public string ConstraintValue { get; set; }

        /// <summary>
        /// Gets or sets the sql flag.
        /// </summary>
        /// <value>
        /// The sql flag.
        /// </value>
        public bool InSQL { get; set; }

        /// <summary>
        /// Gets or sets the name of the area.
        /// </summary>
        /// <value>
        /// The area name.
        /// </value>
        public CgMetaAreaDTO Area { get; set; }

        /// <summary>
        /// Gets or sets the priority.
        /// </summary>
        /// <value>
        /// The priority.
        /// </value>
        public int Priority { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
    }
}
