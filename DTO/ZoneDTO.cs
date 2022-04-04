using System.Collections.Generic;

namespace DTO
{
    public class ZoneDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<MaterialDTO> Materials { get; set; }
    }
}