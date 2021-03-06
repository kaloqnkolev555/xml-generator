namespace KPMG.XmlGenerator.Business
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KPMG.XmlGenerator.Core;
    using KPMG.XmlGenerator.Core.Common;
    using KPMG.XmlGenerator.Core.Models;
    using KPMG.XmlGenerator.Data;
    using KPMG.XmlGenerator.Data.Repository;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Caching.Memory;

    public class DbConnectionsConfigurationService
    {
        private const string dbConnectionConfigurationsCacheKey = "DbConnectionConfigurations";

        private readonly IMemoryCache memoryCache;
        private readonly IDictionary<string, DbConnectionAppSettingsConfiguration> dbConnectionAppSettingsConfigurations;

        public DbConnectionsConfigurationService(
            IMemoryCache memoryCache,
            IDictionary<string, DbConnectionAppSettingsConfiguration> dbConnectionAppSettingsConfigurations)
        {
            this.memoryCache = memoryCache;
            this.dbConnectionAppSettingsConfigurations = dbConnectionAppSettingsConfigurations;
        }

        public async Task<DbConnectionConfigurationDTO> GetDbConnectionConfiguration(string id, bool forceRebuildCache = false)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            var keyId = id.ToLowerInvariant();

            if (!this.dbConnectionAppSettingsConfigurations.ContainsKey(keyId))
            {
                throw new ArgumentException($"DB Configuration with id {id} does not exist.", nameof(id));
            }

            var cacheKey = $"{dbConnectionConfigurationsCacheKey}:{keyId}";

            var dbConnectionAppSettingsConfiguration = this.dbConnectionAppSettingsConfigurations[keyId];

            if (forceRebuildCache)
            {
                return await this.BuildCachedConfiguration(cacheKey, dbConnectionAppSettingsConfiguration);
            }

            if (this.memoryCache.TryGetValue(cacheKey, out DbConnectionConfigurationDTO result))
            {
                return result;
            }

            return await this.BuildCachedConfiguration(cacheKey, dbConnectionAppSettingsConfiguration);
        }

        public async Task<IDictionary<string, DbConnectionConfigurationDTO>> GetDbConnectionConfigurations(bool forceRebuildCache = false)
        {
            var result = new Dictionary<string, DbConnectionConfigurationDTO>();

            foreach (var kvp in this.dbConnectionAppSettingsConfigurations)
            {
                var cacheKey = $"{dbConnectionConfigurationsCacheKey}:{kvp.Key}";

                DbConnectionConfigurationDTO dbConnectionConfig;

                if (forceRebuildCache || !this.memoryCache.TryGetValue(cacheKey, out dbConnectionConfig))
                {
                    dbConnectionConfig = await this.BuildCachedConfiguration(cacheKey, kvp.Value);
                }

                result.Add(kvp.Key, dbConnectionConfig);
            }
            return result;
        }

        private async Task<DbConnectionConfigurationDTO> BuildCachedConfiguration(string cacheKey, DbConnectionAppSettingsConfiguration dbConnectionAppSettingsConfiguration)
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder();

            var dbConnectionConfig = new DbConnectionConfigurationDTO()
            {
                DbConnectionAppSettingsConfiguration = dbConnectionAppSettingsConfiguration
            };

            dbContextOptionsBuilder.UseSqlServer(dbConnectionAppSettingsConfiguration.ConnectionString);
            using (var dbContext = new XmlGeneratorDbContext(dbContextOptionsBuilder.Options))
            {
                var repository = new Repository(dbContext);
                dbConnectionConfig.AvailableVersions = await repository.Execute<CgMetaVersion>(Constants.USP_CG_META_VERSION_SEL, null);
            }

            this.memoryCache.Set(cacheKey, dbConnectionConfig);

            return dbConnectionConfig;
        }
    }
}
