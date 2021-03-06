namespace KPMG.XmlGenerator.Core.Extensions
{
    using System;
    using System.Data;

    /// <summary>
    /// SqlDatabaseTypeAttribute class
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Property)]
    public class SqlDatabaseTypeAttribute : Attribute
    {
        private readonly SqlDbType sqlDbType;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlDatabaseTypeAttribute"/> class.
        /// </summary>
        /// <param name="sqlDbType">Type of the SQL database.</param>
        public SqlDatabaseTypeAttribute(SqlDbType sqlDbType)
        {
            this.sqlDbType = sqlDbType;
        }

        /// <summary>
        /// Gets the type of the SQL database.
        /// </summary>
        /// <value>
        /// The type of the SQL database.
        /// </value>
        public virtual SqlDbType SqlDbType
        {
            get { return sqlDbType; }
        }
    }
}
