namespace KPMG.XmlGenerator.Core.Extensions
{
    using System;

    /// <summary>
    /// SqlDatabaseTypeSizeAttribute class
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Property)]
    public class SqlDatabaseTypeSizeAttribute : Attribute
    {
        private readonly int size;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlDatabaseTypeSizeAttribute"/> class.
        /// </summary>
        /// <param name="size">The size.</param>
        public SqlDatabaseTypeSizeAttribute(int size)
        {
            this.size = size;
        }

        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        public virtual int Size
        {
            get { return size; }
        }
    }
}
