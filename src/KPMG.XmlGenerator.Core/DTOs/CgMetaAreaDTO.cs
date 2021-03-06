using System.Collections.Generic;

namespace KPMG.XmlGenerator.Core.DTOs
{
    /// <summary>
    /// CgMetaAreaDTO class
    /// </summary>
    public class CgMetaAreaDTO
    {
        /// <summary>
        /// Gets or sets the version identifier.
        /// </summary>
        /// <value>
        /// The version identifier.
        /// </value>
        public int VersionId { get; set; }

        /// <summary>
        /// Gets or sets the name of the area.
        /// </summary>
        /// <value>
        /// The name of the area.
        /// </value>
        public string AreaName { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        public string Description { get; set; }
    }
}
