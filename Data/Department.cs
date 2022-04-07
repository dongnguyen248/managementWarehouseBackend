using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Department
    {
        public Department()
        {
            ExportHistories = new HashSet<ExportHistory>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ExportHistory> ExportHistories { get; set; }

    }
}
