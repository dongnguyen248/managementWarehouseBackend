using System.Collections.Generic;

namespace DTO
{
    public class UnitDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MaterialDTO> Materials { get; set; }
    }
}