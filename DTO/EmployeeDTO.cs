using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<ExportHistoryDTO> ExportHistories { get; set; }
        public virtual ICollection<ImportHistoryDTO> ImportHistories { get; set; }

        #region IgnoreMap

        [NotMapped]
        public string PasswordOriginal { get; set; }

        #endregion IgnoreMap
    }
}