namespace KPMG.XmlGenerator.Data
{
    using Microsoft.EntityFrameworkCore;

    using KPMG.XmlGenerator.Core.Models;

    /// <summary>
    /// XmlGeneratorDbContext class
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class XmlGeneratorDbContext : DbContext
    {
        public XmlGeneratorDbContext(DbContextOptions options)
            : base(options)
        {
        }

        //public virtual DbSet<SampleModel> SampleModels { get; set; }

        /// <summary>
        /// Gets or sets the version models.
        /// </summary>
        /// <value>
        /// The version models.
        /// </value>
        public virtual DbSet<CgMetaVersion> CgMetaVersions { get; set; }

        /// <summary>
        /// Gets or sets the cg meta objects.
        /// </summary>
        /// <value>
        /// The cg meta objects.
        /// </value>
        public virtual DbSet<CgMetaObject> CgMetaObjects { get; set; }

        /// <summary>
        /// Gets or sets the cg meta areas.
        /// </summary>
        /// <value>
        /// The cg meta areas.
        /// </value>
        public virtual DbSet<CgMetaArea> CgMetaAreas { get; set; }

        /// <summary>
        /// Gets or sets the cg meta area to objects.
        /// </summary>
        /// <value>
        /// The cg meta area to objects.
        /// </value>
        public virtual DbSet<CgMetaAreaToObject> CgMetaAreaToObjects { get; set; }

        /// <summary>
        /// Gets or sets the cg meta configuration.
        /// </summary>
        /// <value>
        /// The cg meta configurations.
        /// </value>
        public virtual DbSet<CgMetaConfiguration> CgMetaConfigurations { get; set; }

        /// <summary>
        /// Gets or sets the cg meta variants.
        /// </summary>
        /// <value>
        /// The cg meta variants.
        /// </value>
        public virtual DbSet<CgMetaVariant> CgMetaVariants { get; set; }

        /// <summary>
        /// Gets or sets the cg meta variant to objects.
        /// </summary>
        /// <value>
        /// The cg meta variant to objects.
        /// </value>
        public virtual DbSet<CgMetaVariantToObject> CgMetaVariantToObjects { get; set; }

        /// <summary>
        /// Gets or sets the configuration to variants mapping object
        /// </summary>
        /// <value>
        /// The cg meta configuration to variants.
        /// </value>
        public virtual DbSet<CgMetaConfigurationToVariant> CgMetaConfigurationToVariants { get; set; }

        /// <summary>
        /// Gets or sets the cg meta groups.
        /// </summary>
        /// <value>
        /// The cg meta groups.
        /// </value>
        public virtual DbSet<CgMetaGroup> CgMetaGroups { get; set; }

        /// <summary>
        /// Gets or sets the cg meta tables.
        /// </summary>
        /// <value>
        /// The cg meta tables.
        /// </value>
        public virtual DbSet<CgMetaTable> CgMetaTables { get; set; }

        /// <summary>
        /// Gets or sets the cg meta helper tables.
        /// </summary>
        /// <value>
        /// The cg meta helper tables.
        /// </value>
        public virtual DbSet<CgMetaHelperTable> CgMetaHelperTables { get; set; }

        /// <summary>
        /// Gets or sets the cg meta extraction logics.
        /// </summary>
        /// <value>
        /// The cg meta extraction logics.
        /// </value>
        public virtual DbSet<CgMetaExtractionLogic> CgMetaExtractionLogics { get; set; }

        /// <summary>
        /// Existses this instance.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns></returns>
        public bool Exists<TEntity>() where TEntity : class
        {
            return this.Model.FindEntityType(typeof(TEntity)) != null;
        }
    }
}
