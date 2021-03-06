using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using KPMG.XmlGenerator.Core.Extensions;

namespace KPMG.XmlGenerator.Core.Models
{
    public class DD03L
    {
        /// <summary>
        /// Gets or sets the table name.
        /// </summary>
        [Column("TABNAME")]
        [SqlDatabaseType(SqlDbType.NVarChar)]
        [SqlDatabaseTypeSize(30)]
        [Key]
        public string TABNAME { get; set; }

        /// <summary>
        /// Gets or sets the field name.
        /// </summary>
        [Column("FIELDNAME")]
        [SqlDatabaseType(SqlDbType.NVarChar)]
        [SqlDatabaseTypeSize(30)]
        [Key]
        public string FIELDNAME { get; set; }

        /// <summary>
        /// Gets or sets whether this is a key field.
        /// </summary>
        [Column("KEYFLAG")]
        [SqlDatabaseType(SqlDbType.NVarChar)]
        [SqlDatabaseTypeSize(2)]
        public string KEYFLAG { get; set; }
    }
}
