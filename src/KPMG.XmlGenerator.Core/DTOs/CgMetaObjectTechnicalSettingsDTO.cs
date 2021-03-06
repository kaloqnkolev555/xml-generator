namespace KPMG.XmlGenerator.Core.DTOs
{
    public class CgMetaObjectTechnicalSettingsDTO
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the version identifier.
        /// </summary>
        /// <value>
        /// The version identifier.
        /// </value>
        public int VersionId { get; set; }

        /// <summary>
        /// Gets or sets the name of the cg meta object.
        /// </summary>
        /// <value>
        /// The name of the cg meta object.
        /// </value>
        public string CgMetaObjectName { get; set; }

        /// <summary>
        /// Gets or sets the name of the extraction logic for the object.
        /// </summary>
        /// <value>
        /// The name of the extraction logic for the object.
        /// </value>
        public string CgMetaExtractionLogicName{ get; set; }

        /// <summary>
        /// Gets or sets the name of the cg meta helper table.
        /// </summary>
        /// <value>
        /// The name of the cg meta helper table.
        /// </value>
        public string MapCgMetaHelperTableName { get; set; }

        /// <summary>
        /// Gets or sets the name of the daybyday column.
        /// </summary>
        /// <value>
        /// The name of the day by day column.
        /// </value>
        public string DayByDay { get; set; }

        /// <summary>
        /// Gets or sets the days per loop.
        /// </summary>
        /// <value>
        /// The days per loop.
        /// </value>
        public int DaysPerLoop { get; set; }

        /// <summary>
        /// Gets or sets the nrobject mapped to the object.
        /// </summary>
        /// <value>
        /// The nrobject mapped to the object.
        /// </value>
        public string MapNrObject { get; set; }

        /// <summary>
        /// Gets or sets the nrfield mapped to the object.
        /// </summary>
        /// <value>
        /// The nrfield mapped to the object.
        /// </value>
        public string MapNrField { get; set; }

        /// <summary>
        /// Gets or sets nrmin/nrmax flag.
        /// </summary>
        /// <value>
        /// The nrmin/nrmax flag.
        /// </value>
        public bool UseNrMinMax { get; set; }

        /// <summary>
        /// Gets or sets the parallel flag.
        /// </summary>
        /// <value>
        /// The parallel flag.
        /// </value>
        public bool IsParallel { get; set; }

        /// <summary>
        /// Gets or sets the package size.
        /// </summary>
        /// <value>
        /// The package size.
        /// </value>
        public int PkgSize { get; set; }

        /// <summary>
        /// Gets or sets the package size 2.
        /// </summary>
        /// <value>
        /// The package size 2.
        /// </value>
        public int PkgSize2 { get; set; }

        /// <summary>
        /// Gets or sets the xfilename.
        /// </summary>
        /// <value>
        /// The xfilename.
        /// </value>
        public string XFilename { get; set; }

        /// <summary>
        /// Gets or sets the hashtotalfield.
        /// </summary>
        /// <value>
        /// The hashtotalfield.
        /// </value>
        public string HashTotalField { get; set; }

        /// <summary>
        /// Gets or sets the is default flag.
        /// </summary>
        /// <value>
        /// The is default flag.
        /// </value>
        public bool IsDefault { get; set; }

        /// <summary>
        /// Gets or sets the docNbr.
        /// </summary>
        /// <value>
        /// The docNbr.
        /// </value>
        public string DocNbr { get; set; }

        /// <summary>
        /// Gets or sets the loopAt constraint.
        /// </summary>
        /// <value>
        /// The loopAt constraint.
        /// </value>
        public string LoopAt { get; set; }
    }
}
