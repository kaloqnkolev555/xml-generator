namespace KPMG.XmlGenerator.Core.DTOs
{
    public class CgMetaHConstraintToAreaDTO
    {
        public string HConstraintName { get; set; }

        public string ConstraintContent { get; set; }

        public bool IsDefaultNoConstraint { get; set; }

        public CgMetaAreaDTO Area { get; set; }

        public int Priority { get; set; }
    }
}
