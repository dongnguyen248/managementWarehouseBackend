using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Web.Models
{
    public class MaterialViewModels
    {
        public MaterialViewModels()
        {
        }

        public MaterialViewModels(MaterialDTO material)
        {
            int totalImport = material.ImportHistories.Sum(x => x.Quantity);
            int totalExport = material.ExportHistories.Sum(x => x.Quantity);
            DateTime lastImportDate = material.ImportHistories.OrderByDescending(x => x.ImportDate).FirstOrDefault().ImportDate;

            Id = material.Id;
            QCode = material.Qcode;
            Zone = material.ZoneNavigation.Description;
            Unit = material.UnitNavigation.Name;
            Item = material.Item;
            Locator = "QMA01." + material.ZoneNavigation.Name + material.Location;
            Location = material.Location;
            LastImportDate = lastImportDate;
            Specification = material.Specification;
            Inventory = totalImport - totalExport;
        }

        public int Id { get; set; }
        public string QCode { get; set; }
        public string Zone { get; set; }
        public string Unit { get; set; }
        public string Item { get; set; }
        public string Location { get; set; }
        public string Locator { get; set; }
        public DateTime LastImportDate { get; set; }
        public string Specification { get; set; }
        public int Inventory { get; set; }

       
        public IEnumerable<MaterialViewModels> Gets(IEnumerable<MaterialDTO> materials)
        {
            foreach (var item in materials)
            {
                yield return new MaterialViewModels(item);
            }
        }
    }
}