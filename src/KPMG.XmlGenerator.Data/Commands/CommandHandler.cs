namespace KPMG.XmlGenerator.Data.Commands
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KPMG.XmlGenerator.Data.Repository;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="KPMG.XmlGenerator.Data.Commands.ICommandHandler{T}" />
    public class CommandHandler<T> : ICommandHandler<T> where T : class
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly ICommandRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandHandler{T}"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public CommandHandler(ICommandRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Saves the specified sp name.
        /// </summary>
        /// <param name="spName">Name of the sp.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task<int> Save(string spName, T model)
        {
            return await this.repository.Save<T>(spName, model);
        }

        /// <summary>
        /// Deletes one or more entities.
        /// </summary>
        /// <param name="spName">Name of the sp.</param>
        /// <param name="ids">The ids of entities to delete.</param>
        /// <returns></returns>
        public async Task<int> DeleteMany(string spName, IEnumerable<int> ids)
        {
            return await this.repository.DeleteMany(spName, ids);
        }
    }
}
