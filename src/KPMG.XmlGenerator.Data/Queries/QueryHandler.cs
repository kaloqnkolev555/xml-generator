namespace KPMG.XmlGenerator.Data.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KPMG.XmlGenerator.Data.Repository;
    using static Dapper.SqlMapper;

    /// <summary>
    /// QueryHandler interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="KPMG.XmlGenerator.Data.Queries.IQueryHandler{T}" />
    public class QueryHandler<T> : IQueryHandler<T> where T : class
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly IQueryRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryHandler{T}"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public QueryHandler(IQueryRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Fetches all for version.
        /// </summary>
        /// <param name="spName">Name of the sp.</param>
        /// <param name="versionId">The version identifier.</param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> FetchAllForVersion(string spName, int? versionId)
        {
            return await this.repository.Execute<T>(spName, versionId);
        }

        /// <summary>
        /// Fetches the by identifier.
        /// </summary>
        /// <param name="spName">Name of the sp.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<T> FetchById(string spName, int id)
        {
            return await this.repository.Execute<T>(spName, id);
        }

        /// <summary>
        /// Executes the specified stored procedure passing the param object as parameters.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="spName">Name of the stored procedure.</param>
        /// <param name="param">The parameters to use for the stored procedure.</param>
        /// <param name="commandTimeout">Number of seconds before execution timeout.</param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> QueryAsync<TEntity>(string spName, object param = null, int? commandTimeout = null) where TEntity : class
        {
            return await this.repository.QueryAsync<TEntity>(spName, param, commandTimeout);
        }

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
        public async Task<IEnumerable<TEntity>> QueryAsync<TEntity>(string spName, Type[] types,
            Func<object[], TEntity> map, object param = null,
            string splitOn = "Id", int? commandTimeout = null) where TEntity : class
        {
            return await this.repository.QueryAsync<TEntity>(spName, types: types, map: map,
                                                param: param, splitOn: splitOn,
                                                commandTimeout: commandTimeout);
        }

        /// <summary>
        /// Executes the specified stored procedures with param object as parameters. 
        /// Multiple result sets as GridReader object are returned.
        /// </summary>
        /// <param name="spName">Name of the stored procedure.</param>
        /// <param name="param">The parameters to use for the stored procedure.</param>
        /// <param name="commandTimeout">Number of seconds before execution timeout.</param>
        /// <returns>Multiple result sets as GridReader object</returns>
        public async Task<GridReader> QueryMultipleAsync(string spName, object param = null,
            int? commandTimeout = null)
        {
            return await this.repository.QueryMultipleAsync(spName, param, commandTimeout);
        }
    }
}
