namespace KPMG.XmlGenerator.Core.DTOs
{
    using System.Collections.Generic;

    public class CgMetaObjectAreaToColumnDTO : CgMetaAreaDTO
    {
        public IEnumerable<CgMetaColumnDTO> MappedColumns { get; set; }
    }
}
