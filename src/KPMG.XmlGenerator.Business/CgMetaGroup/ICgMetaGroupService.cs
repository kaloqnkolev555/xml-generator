namespace KPMG.XmlGenerator.Business.CgMetaGroup
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using XmlGenerator.Core.Models;

    public interface ICgMetaGroupService
    {
        Task<IEnumerable<CgMetaGroup>> GetAllGroups();
        Task<CgMetaGroup> GetGroupById(int id);
    }
}
