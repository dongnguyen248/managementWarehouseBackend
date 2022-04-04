using System.Collections.Generic;

#nullable disable

namespace Data
{
    public partial class Line
    {
        public Line()
        {
            ExportHistories = new HashSet<ExportHistory>();
            ImportHistories = new HashSet<ImportHistory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string CostCenter { get; set; }

        public virtual ICollection<ExportHistory> ExportHistories { get; set; }
        public virtual ICollection<ImportHistory> ImportHistories { get; set; }
    }
}