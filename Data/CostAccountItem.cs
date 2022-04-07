
using System.Collections.Generic;

namespace Data
{
    public partial class CostAccountItem
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public int CostAccount { get; set; }

        public virtual CostAccount CostAccountNavigation { get; set; }
        public virtual ICollection<ExportHistory> ExportHistories { get; set; } 
    }
}