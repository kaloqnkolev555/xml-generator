namespace KPMG.XmlGenerator.Data.Helpers
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Reflection;

    using KPMG.XmlGenerator.Core.Extensions;

    /// <summary>
    /// ModelAttributeHelper class
    /// </summary>
    public static class ModelAttributeHelper
    {
        /// <summary>
        /// Gets the column attribute information.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="src">The source.</param>
        /// <returns></returns>
        public static List<ModelAttributeInfo> GetColumnAttributeInfo<T>(object src)
        {
            var modelInfos = new List<ModelAttributeInfo>();

            //PropertyInfo[] props = typeof(T).GetProperties();
            PropertyInfo[] props = src.GetType().GetProperties();
            foreach (var prop in props)
            {
                var colAttr = prop.GetCustomAttribute<ColumnAttribute>();
                var sqlDbTypeAttr = prop.GetCustomAttribute<SqlDatabaseTypeAttribute>();
                var sqlDbTypeSizeAttr = prop.GetCustomAttribute<SqlDatabaseTypeSizeAttribute>();

                if (colAttr != null)
                {
                    modelInfos.Add(new ModelAttributeInfo()
                    {
                        PropertyName = prop.Name,
                        PropertyValue = prop.GetValue(src, null) ?? System.DBNull.Value,
                        SqlPropertyType = sqlDbTypeAttr?.SqlDbType,
                        SqlPropertySize = sqlDbTypeSizeAttr?.Size,
                        SqlParameterAlias = $"@{colAttr.Name}"
                    });
                }
            }

            return modelInfos;
        }
    }

    /// <summary>
    /// ModelAttributeInfo class
    /// </summary>
    public class ModelAttributeInfo
    {
        /// <summary>
        /// Gets or sets the name of the property.
        /// </summary>
        /// <value>
        /// The name of the property.
        /// </value>
        public string PropertyName { get; set; }

        /// <summary>
        /// Gets or sets the property value.
        /// </summary>
        /// <value>
        /// The property value.
        /// </value>
        public object PropertyValue { get; set; }

        /// <summary>
        /// Gets or sets the type of the SQL property.
        /// </summary>
        /// <value>
        /// The type of the SQL property.
        /// </value>
        public SqlDbType? SqlPropertyType { get; set; }

        /// <summary>
        /// Gets or sets the size of the SQL property.
        /// </summary>
        /// <value>
        /// The size of the SQL property.
        /// </value>
        public int? SqlPropertySize { get; set; }

        /// <summary>
        /// Gets or sets the SQL parameter alias.
        /// </summary>
        /// <value>
        /// The SQL parameter alias.
        /// </value>
        public string SqlParameterAlias { get; set; }
    }
}
