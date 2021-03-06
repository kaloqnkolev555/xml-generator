namespace KPMG.XmlGenerator.Data.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    using Dapper;
    using static Dapper.SqlMapper;

    using KPMG.XmlGenerator.Data.Helpers;

    /// <summary>
    /// Repository class
    /// </summary>
    /// <seealso cref="KPMG.XmlGenerator.Data.Repository.IQueryRepository" />
    /// <seealso cref="KPMG.XmlGenerator.Data.Repository.ICommandRepository" />
    public class Repository : IQueryRepository, ICommandRepository
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly XmlGeneratorDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public Repository(XmlGeneratorDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Executes the specified sp name.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="spName">Name of the sp.</param>
        /// <param name="version">ID of the version.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Entity argument does not exist in that context.</exception>
        public async Task<IEnumerable<TEntity>> Execute<TEntity>(string spName, int? version = null)
            where TEntity : class
        {
            if (!this.context.Exists<TEntity>())
            {
                throw new ArgumentException("Entity argument does not exist in that context.");
            }

            var dbSet = this.context.Set<TEntity>();
            List<TEntity> result;

            try
            {
                if (version.HasValue)
                {
                    result = await dbSet.FromSql($"{spName} @IdColumn, @ref_version_id",
                        new SqlParameter[] { new SqlParameter("@IdColumn", SqlDbType.Int) { Value = DBNull.Value, Direction = ParameterDirection.Input }
                        , new SqlParameter("@ref_version_id", SqlDbType.Int) { Value = version, Direction = ParameterDirection.Input } }).ToListAsync();
                }
                else
                {
                    result = await dbSet.FromSql(spName).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        /// <summary>
        /// Executes the specified sp name.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="spName">Name of the sp.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Entity argument does not exist in that context.</exception>
        public async Task<TEntity> Execute<TEntity>(string spName, int id)
            where TEntity : class
        {
            if (!this.context.Exists<TEntity>())
            {
                throw new ArgumentException("Entity argument does not exist in that context.");
            }

            var dbSet = this.context.Set<TEntity>();
            TEntity result;

            try
            {
                result = await dbSet.FromSql($"{spName} @IdColumn", new SqlParameter("@IdColumn", id)).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        /// <summary>
        /// Saves the specified sp name.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="spName">Name of the sp.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task<int> Save<TEntity>(string spName, TEntity model)
            where TEntity : class
        {
            var sql = new StringBuilder();
            const string outputParamIdColumn = "@NewIdColumn";
            const string outputParamErrorCode = "@ErrorCode";
            var newModelId = 0;

            try
            {
                var propInfos = ModelAttributeHelper.GetColumnAttributeInfo<TEntity>(model);
                sql.Append(string.Format("{0} {1}", spName, string.Join(",", propInfos.Select(p => p.SqlParameterAlias))));

                var sqlParameters = new List<SqlParameter>();

                foreach (var propInfo in propInfos)
                {
                    var sqlParameter = new SqlParameter
                    {
                        ParameterName = propInfo.SqlParameterAlias,
                        Value = propInfo.PropertyValue ?? DBNull.Value
                    };
                    sqlParameter.SqlDbType = propInfo.SqlPropertyType ?? sqlParameter.SqlDbType;
                    sqlParameter.Size = propInfo.SqlPropertySize ?? sqlParameter.Size;

                    sqlParameters.Add(sqlParameter);
                }

                sqlParameters.Add(new SqlParameter(outputParamIdColumn, SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                });

                sql.Append($",{outputParamIdColumn} OUTPUT");

                sqlParameters.Add(new SqlParameter(outputParamErrorCode, SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                });
                sql.Append($",{outputParamErrorCode} OUTPUT");

                var affectedRows = await this.context.Database.ExecuteSqlCommandAsync(sql.ToString(), sqlParameters);

                SqlErrorCodeHelper.ParseError(sqlParameters.FirstOrDefault(p => p.ParameterName.Equals(outputParamErrorCode)));

                var result = sqlParameters.FirstOrDefault(p => p.ParameterName.Equals(outputParamIdColumn)).Value;

                int.TryParse(result.ToString(), out newModelId);
            }
            catch (Exception e)
            {
                throw e;
            }

            return newModelId;
        }

        /// <summary>
        /// Deletes the area.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="spName">Name of the sp.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task<int> DeleteMany(string spName, IEnumerable<int> ids)
        {
            var sql = new StringBuilder();
            var newResultId = 0;
            sql.Append(string.Format("{0} {1}, {2} OUTPUT", spName, "@IdColumn", "@ErrorCode"));

            var sqlParameters = new SqlParameter[] {
                    new SqlParameter("@IdColumn", ids != null && ids.Any() ? (object)string.Join(",", ids) : DBNull.Value),
                    new SqlParameter("@ErrorCode", SqlDbType.Int) { Direction = ParameterDirection.Output }
                };

            try
            {
                newResultId = await this.context.Database.ExecuteSqlCommandAsync(sql.ToString(), sqlParameters);
            }
            catch (Exception e)
            {
                throw e;
            }

            return newResultId;
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
            return await this.context.Database.GetDbConnection().QueryAsync<TEntity>(spName, param: param, commandTimeout: commandTimeout, commandType: CommandType.StoredProcedure);
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
            return await this.context.Database.GetDbConnection()
                                              .QueryAsync<TEntity>(spName, types: types, map: map,
                                                param: param, splitOn: splitOn,
                                                commandTimeout: commandTimeout,
                                                commandType: CommandType.StoredProcedure);
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
            return await this.context.Database.GetDbConnection()
                                              .QueryMultipleAsync(sql: spName, param: param, commandTimeout: commandTimeout,
                                                commandType: CommandType.StoredProcedure);
        }
    }
}
