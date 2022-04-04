using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IImportService
    {
        IEnumerable<ImportHistoryDTO> GetAll(int page, int pageSize, out int totalRow);

        IEnumerable<ImportHistoryDTO> Search(DateTime dateFrom, DateTime dateTo , string Qcode, string PO, string Line,string Supplier, int page, int pageSize, out int totalRow);
    }
}
