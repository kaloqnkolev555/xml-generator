namespace KPMG.XmlGenerator.Core.DTOs
{
    public class CgMetaTechnicalSettingDTO
    {
        public int VersionId { get; set; }

        public string CgMetaObjectName { get; set; }

        public CgMetaExtractionLogicDTO CgMetaExtractionLogic { get; set; }

        public string MapCgMetaHelperTableName { get; set; }

        public string DayByDay { get; set; }

        public int? DaysPerLoop { get; set; }

        public string MapNrObject { get; set; }

        public string MapNrField { get; set; }

        public bool? UseNrMinMax { get; set; }

        public bool? NrMin { get => this.UseNrMinMax; }

        public bool? NrMax { get => this.UseNrMinMax; }

        public bool? IsParallel { get; set; }

        public int? PkgSize { get; set; }

        public int? PkgSize2 { get; set; }

        public string XFilename { get; set; }

        public string HashTotalField { get; set; }

        public bool? IsDefault { get; set; }

        public string DocNbr { get; set; }

        public string LoopAt { get; set; }

        public string[] Dd03lFields { get; set; }
    }
}
