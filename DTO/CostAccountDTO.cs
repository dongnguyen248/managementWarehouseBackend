using System.Collections.Generic;

namespace DTO
{
    public class CostAccountDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CostAccountItemDTO> CostAccountItems { get; set; }
    }
}