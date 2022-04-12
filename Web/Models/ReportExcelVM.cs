using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Web.Models
{
    //Feb-22	QCODE ITEM    SPEC UNIT    PRICE INVENTORY   IN OUT INVENTORY AMOUNT USD LINE    COST CENTER COST ACCOUNT    REMARK NOTE
    //NAME LOCATOR INSPECTION INSPECTION_DATE INSPECTOR RESULT

    public class ReportExcelVM
    {
        public ReportExcelVM()
        {


        }
        public ReportExcelVM(ExportHistoryDTO exportHistory)
        {
            var importHistories = exportHistory.MaterialNavigation.ExportHistories.OrderBy(x => x.CreatedDate).ToList();
           var totalImportInADay = exportHistory.MaterialNavigation.ImportHistories.Select(x=>x.ImportDate).ToList();
            foreach(var total in totalImportInADay)
            {
                var sumImport = total;

            }

            if(importHistories != null)
            {
                foreach (var importHistoriesItem in importHistories)
                {
                    QCode = exportHistory.MaterialNavigation.Qcode;
                    Item = exportHistory.MaterialNavigation.Item;
                    Specification = exportHistory.MaterialNavigation.Specification;
                    Unit = exportHistory.MaterialNavigation.UnitNavigation.Name;
                    Price = exportHistory.Price;
                    ImportQuantity = importHistoriesItem.Quantity;
                    ExportQuantity = exportHistory.Quantity;
                    InventoriesAfter = exportHistory.inventoriesAfter;
                    InventoriesBefor = InventoriesAfter + ImportQuantity - ExportQuantity;

                }
            }
            else
            {
                QCode = exportHistory.MaterialNavigation.Qcode;
                Item = exportHistory.MaterialNavigation.Item;
                Specification = exportHistory.MaterialNavigation.Specification;
                Unit = exportHistory.MaterialNavigation.UnitNavigation.Name;
                Price = exportHistory.Price;
                ImportQuantity = 0;
                ExportQuantity = exportHistory.Quantity;
            }
            
            
            



        }
        public int Id { get; set; }
        public int InventoriesAfter { get; set; }
        public int InventoriesBefor { get; set; }
        public int ImportQuantity { get; set; }
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
        public int ExportQuantity { get; set; }
        public string CostAccount { get; set; }
        public string costAccountItem { get; set; }
        public string Zone { get; set; }

        public IEnumerable<ReportExcelVM> Gets(IEnumerable<ExportHistoryDTO> importHistory)
        {
            foreach (var item in importHistory)
            {
                yield return new ReportExcelVM(item);
            }
        }
    }
}
