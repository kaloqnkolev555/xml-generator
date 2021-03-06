namespace KPMG.XmlGenerator.Core.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;

    using KPMG.XmlGenerator.Core.Extensions;

    /// <summary>
    /// CgMetaVariantCreate class
    /// </summary>
    public class CgMetaVariantCreate : CgMetaVariant
    {
        /// <summary>
        /// Gets or sets the template cg meta variant identifier column.
        /// </summary>
        /// <value>
        /// The template cg meta variant identifier column.
        /// </value>
        [Column("TemplateVariantIdColumn")]
        public int? TemplateCgMetaVariantIdColumn { get; set; }

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
