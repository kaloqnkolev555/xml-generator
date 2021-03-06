namespace KPMG.XmlGenerator.Data.Commands
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// ICommandHandler interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICommandHandler<T> where T : class
    {
        /// <summary>
        /// Saves the specified sp name.
        /// </summary>
        /// <param name="spName">Name of the sp.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task<int> Save(string spName, T model);

        /// <summary>
        /// Deletes one or more entities.
        /// </summary>
        /// <param name="spName">Name of the sp.</param>
        /// <param name="ids">The ids of the entities to delete.</param>
        /// <returns></returns>
        Task<int> DeleteMany(string spName, IEnumerable<int> ids);
    }
}
