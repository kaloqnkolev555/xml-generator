namespace KPMG.XmlGenerator.Core
{
    using System.Collections.Generic;
    using KPMG.XmlGenerator.Core.Models;

    public class DbConnectionConfigurationDTO
    {
        public DbConnectionAppSettingsConfiguration DbConnectionAppSettingsConfiguration { get; set; }

        public IEnumerable<CgMetaVersion> AvailableVersions { get; set; }
    }
}
