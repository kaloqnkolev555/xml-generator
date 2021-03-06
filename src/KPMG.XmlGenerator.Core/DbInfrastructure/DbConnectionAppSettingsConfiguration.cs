namespace KPMG.XmlGenerator.Core
{
    public class DbConnectionAppSettingsConfiguration
    {
        public string Name { get; set; }

        public string Server { get; set; }

        public string Database { get; set; }

        public string ConnectionString { get; set; }

        public bool IsActive { get; set; }

        public bool IsDefault { get; set; }
    }
}
