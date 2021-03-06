namespace KPMG.XmlGenerator.Core.Models
{
    public class CgMetaHConstraintToArea
    {
        public int VersionId { get; set; }

        public string HConstraintName { get; set; }

        public string AreaName { get; set; }

        public string AreaDescription { get; set; }

        public int AreaIdColumn { get; set; }

        public bool IsDefaultNoConstraint { get; set; }

        public string ConstraintContent { get; set; }

        public int Priority { get; set; }
    }
}
