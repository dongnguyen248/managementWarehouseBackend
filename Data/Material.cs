using System;
using System.Collections.Generic;

#nullable disable

namespace Data
{
    public partial class Material
    {
        public Material()
        {
            ExportHistories = new HashSet<ExportHistory>();
            ImportHistories = new HashSet<ImportHistory>();
        }

        public int Id { get; set; }
        public string Qcode { get; set; }
        public int Zone { get; set; }
        public int Unit { get; set; }
        public string Location { get; set; }
        public string Item { get; set; }
        public string Specification { get; set; }
        public string Remark { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Unit UnitNavigation { get; set; }
        public virtual Zone ZoneNavigation { get; set; }
        public virtual ICollection<ExportHistory> ExportHistories { get; set; }
        public virtual ICollection<ImportHistory> ImportHistories { get; set; }
    }
}