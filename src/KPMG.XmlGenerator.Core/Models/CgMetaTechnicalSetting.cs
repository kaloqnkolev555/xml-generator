namespace KPMG.XmlGenerator.Core.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class CgMetaTechnicalSetting : BaseModel
    {
        [Column("ref_version_id")]
        public int VersionId { get; set; }

        public string SettingObjectName { get; set; }

        public string ExtractionLogicName { get; set; }

        public string ExtractionLogicDescription { get; set; }

        public int ExtractionLogicIdColumn { get; set; }

        public string HelperTableName { get; set; }

        public string DayByDay { get; set; }

        public int DaysPerLoop { get; set; }

        public string NrObject { get; set; }

        public string NrField { get; set; }

        public bool NrMin { get; set; }

        public bool NrMax { get; set; }

        public int Parallel { get; set; }

        public int PkgSize { get; set; }

        public int PkgSize2 { get; set; }

        public string XFilename { get; set; }

        public string HashTotalField { get; set; }

        public bool? IsDefaultSetting { get; set; }

        public string DocNbr { get; set; }

        public string LoopAt { get; set; }
    }
}
