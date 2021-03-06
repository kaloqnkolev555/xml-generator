namespace KPMG.XmlGenerator.Business.CgMetaObject
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KPMG.XmlGenerator.Core.DTOs;
    using KPMG.XmlGenerator.Core.Models;

    /// <summary>
    /// ICgMetaObjectService interface
    /// </summary>
    public interface ICgMetaObjectService
    {
        /// <summary>
        /// Gets all objects.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CgMetaObject>> GetAllObjects();

        /// <summary>
        /// Gets the object by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<CgMetaObject> GetObjectById(int id);

        /// <summary>
        /// Gets the object by identifier or name.
        /// </summary>
        /// <param name="id">The object identifier.</param>
        /// /// <param name="name">The object name.</param>
        /// <returns></returns>
        Task<CgMetaObjectLoad> GetObjectWithAllRelations(int? id, string name);

        /// <summary>
        /// Creates the new object.
        /// </summary>
        /// <param name="entity">The cg meta object.</param>
        /// <param name="step1Changed">Has step 1 changed.</param>
        /// <param name="step2Changed">Has step 2 changed.</param>
        /// <param name="step3Changed">Has step 3 changed.</param>
        /// <param name="step4Changed">Has step 4 changed.</param>
        /// <param name="step5Changed">Has step 5 changed.</param>
        /// <param name="step6Changed">Has step 6 changed.</param>
        /// <param name="step7Changed">Has step 7 changed.</param>
        /// <returns></returns>
        Task<int?> Create(CgMetaObjectCreateDTO obj, bool? step1Changed = null,
            bool? step2Changed = null, bool? step3Changed = null, bool? step4Changed = null,
            bool? step5Changed = null, bool? step6Changed = null, bool? step7Changed = null);

        /// <summary>
        /// Deletes one ore more objects.
        /// </summary>
        /// <param name="ids">The ids of the objects to delete.</param>
        /// <returns></returns>
        Task<int> DeleteObjects(IEnumerable<int> ids);

        /// <summary>
        /// Checks if an object name is already in use for the current version.
        /// </summary>
        /// <param name="objct_name">Object name to check.</param>
        /// <param name="idColumn">The IdColumn value when an object is being edited.</param>
        /// <returns><c>true</c> if the name is already in use; otherwise, <c>false</c></returns>
        Task<bool> IsObjectNameTaken(string objct_name, int? idColumn);
    }
}
