namespace KPMG.XmlGenerator.Core.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;

    using KPMG.XmlGenerator.Core.Extensions;

    /// <summary>
    /// CgMetaAreaCreate class
    /// </summary>
    /// <seealso cref="KPMG.XmlGenerator.Core.Models.CgMetaArea" />
    /// <seealso cref="KPMG.XmlGenerator.Core.Models.ICgMetaAreaCreate" />
    public class CgMetaAreaCreate : CgMetaArea, ICgMetaAreaCreate
    {
        /// <summary>
        /// Gets or sets the template cg meta template area identifier column.
        /// </summary>
        /// <value>
        /// The template cg meta template area identifier column.
        /// </value>
        [Column("TemplateAreaIdColumn")]
        public int? TemplateCgMetaAreaIdColumn { get; set; }

        /// <summary>
        /// Gets or sets the map meta objct identifier columns.
        /// </summary>
        /// <value>
        /// The map meta objct identifier columns.
        /// </value>
        [Column("MapMetaObjctIdColumns")]
        [SqlDatabaseType(SqlDbType.NVarChar)]
        public string MapMetaObjctIdColumns { get; set; }
    }
}
