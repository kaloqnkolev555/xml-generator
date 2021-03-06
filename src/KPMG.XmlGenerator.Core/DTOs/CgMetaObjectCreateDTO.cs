namespace KPMG.XmlGenerator.Core.DTOs
{
    using System.Collections.Generic;

    public class CgMetaObjectCreateDTO
    {
        public CgMetaObjectDTO CgMetaObjectDTO { get; set; }

        public CgMetaTechnicalSettingDTO CgMetaObjectTechnicalSettings { get; set; }

        public CgMetaObjectMappedAreasDTO MappedAreas { get; set; }

        public IEnumerable<CgMetaObjectAreaToColumnDTO> MappedColumns { get; set; }

        public CgMetaObjectConstraintToAreaDTO CgMetaConstraintsArea { get; set; }

        public CgMetaObjectHardCodedConstraintsDTO HardCodedConstraints { get; set; }

        public CgMetaObjectVariantsDTO CgMetaVariantToObject { get; set; }
    }
}
