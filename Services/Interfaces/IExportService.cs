using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IExportService
    {
        IEnumerable<ExportHistoryDTO> GetAll(int page, int pageSize, out int totalRow);

        IEnumerable<ExportHistoryDTO> Search(DateTime dateFrom, DateTime dateTo, string Qcode, string PO, string Line, string Supplier, int page, int pageSize, out int totalRow);

        void Add(ExportHistoryDTO exportHistory);
        void UpdateExportHistory(ExportHistoryDTO exportHistory);
        IEnumerable<ExportHistoryDTO> GetAllExpHis();
        void DeleteHistory(int id);
    }
}
