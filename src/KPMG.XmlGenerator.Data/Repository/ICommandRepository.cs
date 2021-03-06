namespace KPMG.XmlGenerator.Data.Repository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using KPMG.XmlGenerator.Core.Models;

    public interface ICommandRepository
    {
        Task<int> Save<TEntity>(string spName, TEntity model) where TEntity : class;

        Task<int> DeleteMany(string spName, IEnumerable<int> ids);
    }
}
