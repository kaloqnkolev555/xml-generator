namespace KPMG.XmlGenerator.Core.Models
{
    public class CgMetaVariantWithConfigs : CgMetaVariant
    {
        public string ConfigurationName { get; set; }

        public int ConfigurationIdColumn { get; set; }
    }
}
