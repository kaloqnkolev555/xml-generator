namespace KPMG.XmlGenerator.Data.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using static Dapper.SqlMapper;

    /// <summary>
    /// IQueryRepository interface
    /// </summary>
    public interface IQueryRepository
    {
        /// <summary>
        /// Executes the specified sp name.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="spName">Name of the sp.</param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> Execute<TEntity>(string spName, int? version) where TEntity : class;

        /// <summary>
        /// Executes the specified sp name.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="spName">Name of the sp.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<TEntity> Execute<TEntity>(string spName, int id) where TEntity : class;

        /// <summary>
        /// Executes the specified stored procedure passing the param object as parameters.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="spName">Name of the stored procedure.</param>
        /// <param name="param">The parameters to use for the stored procedure.</param>
        /// <param name="commandTimeout">Number of seconds before execution timeout.</param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> QueryAsync<TEntity>(string spName, object param = null, int? commandTimeout = null) where TEntity : class;

        /// <summary>
        /// Executes the specified stored procedure with param object as parameters,
        /// multi-mapping delegate and Dapper splitOn property.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity to return.</typeparam>
        /// <param name="spName">Name of the stored procedure.</param>
        /// <param name="types">Array of types in the recordset.</param>
        /// <param name="map">The function to map row types to the return type.</param>
        /// <param name="param">The parameters to use for the stored procedure.</param>
        /// <param name="splitOn">The field Dapper should split and read the second object from (default: "Id").</param>
        /// <param name="commandTimeout">Number of seconds before execution timeout.</param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> QueryAsync<TEntity>(string spName, Type[] types,
            Func<object[], TEntity> map, object param = null,
            string splitOn = "Id", int? commandTimeout = null) where TEntity : class;

        /// <summary>
        /// Executes the specified stored procedures with param object as parameters. 
        /// Multiple result sets as GridReader object are returned.
        /// </summary>
        /// <param name="spName">Name of the stored procedure.</param>
        /// <param name="param">The parameters to use for the stored procedure.</param>
        /// <param name="commandTimeout">Number of seconds before execution timeout.</param>
        /// <returns>Multiple result sets as GridReader object</returns>
        Task<GridReader> QueryMultipleAsync(string spName, object param = null,
            int? commandTimeout = null);
    }
}
