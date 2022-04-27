using DTO;
using System;
using System.Collections.Generic;

namespace Web.Models
{
    public class ExportHistoryVM
    {
        public ExportHistoryVM()
        {

        }
        public ExportHistoryVM(ExportHistoryDTO exportHistory)
        {
            Id = exportHistory.Id;
            QCode = exportHistory.MaterialNavigation.Qcode;
            Price = exportHistory.Price;
            Item = exportHistory.MaterialNavigation.Item;
            Location = exportHistory.MaterialNavigation.Location;
            Locator = "QMA01." + exportHistory.MaterialNavigation.ZoneNavigation.Name + "-"+ exportHistory.MaterialNavigation.Location;
            ExportDate = exportHistory.ExportDate;
            Specification = exportHistory.MaterialNavigation.Specification;
            CostLine = exportHistory.ReceiverNavigation.CostCenter;
            Line = exportHistory.ReceiverNavigation.Name;
            Remark = exportHistory.Remark;
            Requestor = exportHistory.Requestor;
            Unit = exportHistory.MaterialNavigation.UnitNavigation.Name;
            Quantity = exportHistory.Quantity;
            CostAccount = exportHistory.CostAccountNavigation.Name;
            costAccountItem = exportHistory.CostAccountItemNavigation.Note;
            Zone = exportHistory.MaterialNavigation.ZoneNavigation.Name;
            InventoriesBefor= exportHistory.InventoriesBefor;
            Department = exportHistory.DepartmentNavigation.Name;
        }

        public int Id { get; set; }
        public string QCode { get; set; }
        public int Price { get; set; }
        public string Item { get; set; }
        public string Location { get; set; }
        public string Locator { get; set; }
        public DateTime ExportDate { get; set; }
        public string Specification { get; set; }
        public string CostLine { get; set; }
        public string Line { get; set; }
        public string Unit { get; set; }
        public string Remark { get; set; }
        public string Requestor { get; set; }
        public int Quantity { get; set; }
        public string CostAccount { get; set; }
        public string costAccountItem { get; set; }
        public string Zone { get; set; }
        public string Department { get; set; }

        public int InventoriesBefor { get; set; }


        public IEnumerable<ExportHistoryVM> Gets(IEnumerable<ExportHistoryDTO> importHistory)
        {
            foreach (var item in importHistory)
            {
                yield return new ExportHistoryVM(item);
            }
        }
    }
}
