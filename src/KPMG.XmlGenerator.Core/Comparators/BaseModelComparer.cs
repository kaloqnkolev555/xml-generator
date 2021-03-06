namespace KPMG.XmlGenerator.Core.Comparators
{
    using System.Collections.Generic;
    using KPMG.XmlGenerator.Core.Models;

    public class BaseModelComparer : IEqualityComparer<BaseModel>
    {
        public bool Equals(BaseModel x, BaseModel y)
        {
            return x.Id.Equals(y.Id);
        }

        public int GetHashCode(BaseModel obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
