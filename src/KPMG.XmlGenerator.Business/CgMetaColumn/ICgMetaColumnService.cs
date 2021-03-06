namespace KPMG.XmlGenerator.Business.CgMetaColumn
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KPMG.XmlGenerator.Core.Models;

    /// <summary>
    /// ICgMetaColumnService interface
    /// </summary>
    public interface ICgMetaColumnService
    {
        /// <summary>
        /// Gets all columns mapped to an object and area.
        /// </summary>
        /// <param name="cgMetaObjectName">The name of the object</param>
        /// <param name="cgMetaAreaName">The name of the area</param>
        /// <returns></returns>
        Task<IEnumerable<CgMetaColumn>> GetColumnsByObjectNameAreaName(string cgMetaObjectName, string cgMetaAreaName);
    }
}
