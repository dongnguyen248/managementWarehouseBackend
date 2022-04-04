using System;
using System.Collections.Generic;

namespace DTO
{
    public class MaterialDTO
    {
        public int Id { get; set; }
        public string Qcode { get; set; }
        public int Zone { get; set; }
        public int Unit { get; set; }
        public string Location { get; set; }
        public string Item { get; set; }
        public string Specification { get; set; }
        public string Remark { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual UnitDTO UnitNavigation { get; set; }
        public virtual ZoneDTO ZoneNavigation { get; set; }
        public virtual ICollection<ExportHistoryDTO> ExportHistories { get; set; }
        public virtual ICollection<ImportHistoryDTO> ImportHistories { get; set; }
    }
}