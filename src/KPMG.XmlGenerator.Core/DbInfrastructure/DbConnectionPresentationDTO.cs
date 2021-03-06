namespace KPMG.XmlGenerator.Core
{
    public class DbConnectionPresentationDTO
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Server { get; set; }

        public string Database { get; set; }

        public bool IsActive { get; set; }

        public bool IsDefault { get; set; }
    }
}
