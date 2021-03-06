namespace KPMG.XmlGenerator.Core.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using KPMG.XmlGenerator.Core.Extensions;

    public class CgMetaAreaForTable : CgMetaArea
    {
        /// <summary>
        /// Gets or sets the name of the cg meta object.
        /// </summary>
        /// <value>
        /// The name of the cg meta object.
        /// </value>
        [Column("objct_name")]
        [SqlDatabaseType(SqlDbType.NVarChar)]
        [SqlDatabaseTypeSize(255)]
        public string CgMetaObjectName { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Column("ObjectIdColumn")]
        public int ObjectIdColumn { get; set; }
    }
}
