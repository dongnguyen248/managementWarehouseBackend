using System.Collections.Generic;

#nullable disable

namespace Data
{
    public partial class CostAccount
    {
        public CostAccount()
        {
            CostAccountItems = new HashSet<CostAccountItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CostAccountItem> CostAccountItems { get; set; }
    }
}