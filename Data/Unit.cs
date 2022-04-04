using System.Collections.Generic;

#nullable disable

namespace Data
{
    public partial class Unit
    {
        public Unit()
        {
            Materials = new HashSet<Material>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Material> Materials { get; set; }
    }
}