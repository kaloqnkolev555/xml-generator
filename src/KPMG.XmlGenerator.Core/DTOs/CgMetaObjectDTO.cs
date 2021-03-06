using System.Collections.Generic;

namespace KPMG.XmlGenerator.Core.DTOs
{
    /// <summary>
    /// CgMetaObjectDTO class
    /// </summary>
    public class CgMetaObjectDTO
    {
        /// <summary>
        /// Gets or sets the version identifier.
        /// </summary>
        /// <value>
        /// The version identifier.
        /// </value>
        public int VersionId { get; set; }

        /// <summary>
        /// Gets or sets the name of the cg meta object.
        /// </summary>
        /// <value>
        /// The name of the cg meta object.
        /// </value>
        public string CgMetaObjectName { get; set; }

        /// <summary>
        /// Gets or sets the name of the cg meta group.
        /// </summary>
        /// <value>
        /// The name of the cg meta group.
        /// </value>
        public string MapCgMetaGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the cg meta table.
        /// </summary>
        /// <value>
        /// The name of the cg meta table.
        /// </value>
        public string MapCgMetaTableName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is footer.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is footer; otherwise, <c>false</c>.
        /// </value>
        public bool IsFooter { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the is default.
        /// </summary>
        /// <value>
        /// The is default.
        /// </value>
        public bool IsDefault { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int? Id { get; set; }

        /// <summary>
        /// Gets or sets the footer filename.
        /// </summary>
        /// <value>
        /// The footer filename.
        /// </value>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the footer hashtotalfield.
        /// </summary>
        /// <value>
        /// The footer hashtotalfield.
        /// </value>
        public string HashTotalField { get; set; }

        /// <summary>
        /// Gets or sets the header object id for the footer.
        /// </summary>
        /// <value>
        /// The header object id for the footer.
        /// </value>
        public int? CgMetaHeaderObjectId { get; set; }

        /// <summary>
        /// Gets or sets the header object name for the footer.
        /// </summary>
        /// <value>
        /// The header object name for the footer.
        /// </value>
        public string HeaderObjectName { get; set; }

        /// <summary>
        /// Gets or sets the group of the cg meta object.
        /// </summary>
        /// <value>
        /// The group of the cg meta object.
        /// </value>
        public CgMetaGroupDTO MapCgMetaGroup { get; set; }

        ///// <summary>
        ///// Gets or sets the settings of the cg meta object.
        ///// </summary>
        ///// <value>
        ///// The settings of the cg meta object.
        ///// </value>
        //public CgMetaTechnicalSettingDTO CgMetaObjectTechnicalSettings { get; set; }

        ///// <summary>
        ///// Gets or sets the areas of the cg meta object.
        ///// </summary>
        ///// <value>
        ///// The areas of the cg meta object.
        ///// </value>
        //public ICollection<CgMetaAreaDTO> Areas { get; set; }

        ///// <summary>
        ///// Gets or sets the variants of the cg meta object.
        ///// </summary>
        ///// <value>
        ///// The variants of the cg meta object.
        ///// </value>
        //public CgMetaObjectVariantsDTO CgMetaVariantToObject { get; set; }

        ///// <summary>
        ///// Gets or sets the columns of the cg meta object.
        ///// </summary>
        ///// <value>
        ///// The columns of the cg meta object.
        ///// </value>
        //public ICollection<CgMetaColumnDTO> Columns { get; set; }
    }
}
