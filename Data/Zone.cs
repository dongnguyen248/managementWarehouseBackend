using System.Collections.Generic;

#nullable disable

namespace Data
{
    public partial class Zone
    {
        public Zone()
        {
            Materials = new HashSet<Material>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Material> Materials { get; set; }
    }
}