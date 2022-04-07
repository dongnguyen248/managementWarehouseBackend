using System.Collections.Generic;

#nullable disable

namespace Data
{
    public partial class CostAccount
    {
        public CostAccount()
        {
            CostAccountItems = new HashSet<CostAccountItem>();
            ExportHistories = new HashSet<ExportHistory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CostAccountItem> CostAccountItems { get; set; }
        public virtual ICollection<ExportHistory> ExportHistories { get; set; }
    }
}