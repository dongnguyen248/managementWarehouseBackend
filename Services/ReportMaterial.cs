using AutoMapper;
using Data;
using DTO;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Services
{
    public class ReportMaterial : IReportMaterial
    {
        private readonly IRepository<Material> _materialRepository;
        private readonly IRepository<ImportHistory> _importtRepository;
        private readonly IMapper _mapper;

        public ReportMaterial(IRepository<Material> materialRepository , IRepository<ImportHistory> importtRepository,IMapper mapper)
        {
            _materialRepository = materialRepository;
            _importtRepository = importtRepository;
            _mapper = mapper;
        }
        public IEnumerable<Material> GetReportExcel(DateTime formDate, DateTime toDate)
        {
                Expression<Func<ImportHistory, bool>> predicateImport = x => (x.ImportDate >= formDate && x.ImportDate <= toDate.AddDays(1));
                IEnumerable<ImportHistory> resultImport = _importtRepository.FindAll(predicateImport, x => x.MaterialNavigation);
                int diff1 = (toDate.AddDays(1) - formDate).Days;
                IEnumerable<Material> resultmaterial = _materialRepository.FindAll(x=>x.ImportHistories,x=>x.ExportHistories);
                List<object> list = new List<object>();
            var material = _mapper.Map<IEnumerable<MaterialDTO>>(resultmaterial);
                for (int i = 0; i < diff1; i++)
                {

                    //var allMaterialInADayImport = resultImport.Where(x => x.ImportDate == formDate.AddDays(i)).GroupBy(x => x.MaterialNavigation.Qcode).ToList();
                    //foreach (var imp in allMaterialInADayImport)
                    //{
                    //var material = _materialRepository.FindAll(x=>x.Qcode == imp.Key,x => x.ExportHistories, x => x.ImportHistories);
                    //int totalImport = material.ImportHistories.Sum(x => x.Quantity);
                    //int totalExport = material.ExportHistories.Sum(x => x.Quantity);

                    //var totalQuantityImportInADay = imp.Sum(x => x.Quantity);
                    //    var totalQuantityExportInADay = _exportRepository.FindAll(x => x.MaterialNavigation.Qcode == imp.Key.ToString() && x.ExportDate == formDate.AddDays(i)).Sum(x => x.Quantity);
                    //    var material = _exportRepository.FindSingle(x => x.MaterialNavigation.Qcode == imp.Key.ToString(), x => x.CostAccountNavigation, x => x.CostAccountItemNavigation, x => x.DepartmentNavigation, x => x.MaterialNavigation);
                    //    var stream = new MemoryStream();

                    //    using (var package = new ExcelPackage(stream))
                    //    {
                    //        var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                    //        workSheet.Cells[1, 1].Value = totalQuantityExportInADay;
                    //        workSheet.Cells[1, 1].Value = totalQuantityExportInADay;

                    //        package.Save();
                    //    }
                    //    stream.Position = 0;
                    //    string excelName = $"UserList-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";

                    //}


                }


                return _mapper.Map<IEnumerable<Material>>(resultmaterial);
            
        }
    }
}
