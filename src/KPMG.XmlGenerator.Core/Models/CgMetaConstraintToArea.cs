namespace KPMG.XmlGenerator.Core.Models
{
    public class CgMetaConstraintToArea : BaseModel
    {
        public int VersionId { get; set; }

        public string ExtractionLogicName { get; set; }

        public string ConField { get; set; }

        public string ConOption { get; set; }

        public string ConValue { get; set; }

        public string AreaName { get; set; }

        public string AreaDescription { get; set; }

        public string AreaIdColumn { get; set; }

        public bool InSQL { get; set; }

        public int Priority { get; set; }
    }
}
