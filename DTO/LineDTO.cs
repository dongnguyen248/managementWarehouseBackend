using System.Collections.Generic;

namespace DTO
{
    public class LineDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CostCenter { get; set; }

        public ICollection<ExportHistoryDTO> ExportHistories { get; set; }
        public ICollection<ImportHistoryDTO> ImportHistories { get; set; }
    }
}