using System.Collections.Generic;

#nullable disable

namespace Data
{
    public partial class Employee
    {
        public Employee()
        {
            ExportHistories = new HashSet<ExportHistory>();
            ImportHistories = new HashSet<ImportHistory>();
        }

        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<ExportHistory> ExportHistories { get; set; }
        public virtual ICollection<ImportHistory> ImportHistories { get; set; }
    }
}