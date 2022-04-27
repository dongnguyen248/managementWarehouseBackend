using DTO;
using System;
using System.Collections.Generic;

namespace Web.Models
{
    public class ImportHistoryVM
    {
        public ImportHistoryVM()
        {

        }
        public ImportHistoryVM(ImportHistoryDTO importHistory)
        {
            Id = importHistory.Id;
            QCode = importHistory.MaterialNavigation.Qcode;
            Price = importHistory.Price;
            Quantity = importHistory.Quantity;
            Item = importHistory.MaterialNavigation.Item;
            Location = importHistory.MaterialNavigation.Location;
            Locator = "QMA01." + importHistory.MaterialNavigation.ZoneNavigation.Name != null ? importHistory.MaterialNavigation.ZoneNavigation.Name : "" + "-"+ importHistory.MaterialNavigation.Location != null ? importHistory.MaterialNavigation.Location :"";
            LastImportDate = importHistory.ImportDate;
            Specification = importHistory.MaterialNavigation.Specification;
            Buyer = importHistory.Buyer;
            Po = importHistory.Po;
            Remark = importHistory.Remark;
            Supplier = importHistory.Supplier;
            Requester = importHistory.LineRequestNavigation.Name;
            Received = importHistory.InspectionNavigation.Result;

            

        }

        public int Id { get; set; }
        public string QCode { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Item { get; set; }
        public string Location { get; set; }
        public string Locator { get; set; }
        public DateTime LastImportDate { get; set; }
        public string Specification { get; set; }
        public string Buyer { get; set; }
        public string Requester { get; set; }
        public string  Po { get; set; }
        public string Remark { get; set; }
        public string Supplier { get; set; }
        public bool? Received { get; set; }

        public IEnumerable<ImportHistoryVM> Gets(IEnumerable<ImportHistoryDTO> importHistory)
        {
            foreach (var item in importHistory)
            {
                yield return new ImportHistoryVM(item);
            }
        }
    }
   
}
