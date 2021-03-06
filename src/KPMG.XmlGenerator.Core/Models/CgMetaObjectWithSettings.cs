namespace KPMG.XmlGenerator.Core.Models
{
    using System.Collections.Generic;
    using KPMG.XmlGenerator.Core.DTOs;

    public class CgMetaObjectLoad : CgMetaObject
    {

        /// <summary>
        /// Gets or sets the footer filename.
        /// </summary>
        /// <value>
        /// The footer filename.
        /// </value>
        public string FooterFileName { get; set; }

        /// <summary>
        /// Gets or sets the header object IdColumn for a footer object.
        /// </summary>
        /// <value>
        /// The header object IdColumn for a footer object.
        /// </value>
        public string HeaderObjectId { get; set; }

        /// <summary>
        /// Gets or sets the header object name for a footer object.
        /// </summary>
        /// <value>
        /// The header object name for a footer object.
        /// </value>
        public string HeaderObjectName { get; set; }

        /// <summary>
        /// Gets or sets the hashtotalfield.
        /// </summary>
        /// <value>
        /// The hashtotalfield.
        /// </value>
        public string FooterHashTotalField { get; set; }

        public string GroupId { get; set; }

        public string GroupLabel { get; set; }

        public int GroupReportId { get; set; }

        public bool GroupIsExtract { get; set; }

        public int GroupIdColumn { get; set; }

        public CgMetaTechnicalSetting CgMetaObjectTechnicalSettings { get; set; }

        public IEnumerable<CgMetaArea> Areas { get; set; }

        public IEnumerable<CgMetaVariantDTO> Variants { get; set; }

        public IEnumerable<CgMetaConstraintToArea> Constraints { get; set; }

        public IEnumerable<CgMetaObjectAreaToColumnDTO> Columns { get; set; }

        public IEnumerable<CgMetaHConstraintToArea> HConstraints { get; set; }

        public IEnumerable<DD03L> Dd03lFields { get; set; }
    }
}
