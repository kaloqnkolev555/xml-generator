namespace KPMG.XmlGenerator.Business
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using KPMG.XmlGenerator.Core.Models;

    public interface IDD03LService
    {
        /// <summary>
        /// Gets all fields for a table name.
        /// </summary>
        /// <param name="tableName">Table name.</param>
        /// <returns></returns>
        Task<IEnumerable<DD03L>> GetFieldsForTable(string tableName);

        /// <summary>
        /// Gets a field by table name and field name.
        /// </summary>
        /// <param name="tableName">Table name.</param>
        /// <param name="fieldName">Field name.</param>
        /// <returns></returns>
        Task<DD03L> GetField(string tableName, string fieldName);
    }
}
