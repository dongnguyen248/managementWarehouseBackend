using AutoMapper;
using Data;
using DTO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Services
{
    public class ReportMaterialService : IReportMaterial
    {
        private readonly IRepository<Material> _materialRepository;
        private readonly IRepository<ImportHistory> _importtRepository;
        private readonly IMapper _mapper;
        private readonly IRepository<ExportHistory> _exportRepository;

        public ReportMaterialService(IRepository<Material> materialRepository, IRepository<ImportHistory> importtRepository, IMapper mapper, IRepository<ExportHistory> exportRepository)
        {
            _materialRepository = materialRepository;
            _importtRepository = importtRepository;
            _mapper = mapper;
            _exportRepository = exportRepository;
        }
        public Stream GetReportExcel(DateTime formDate, DateTime toDate)
        {
            int daySearch = (toDate.AddDays(1) - formDate).Days;
            var materials = _materialRepository.FindAll(x=>x.UnitNavigation,x=>x.ZoneNavigation,x => x.ExportHistories.Where(y => y.ExportDate >= formDate && y.ExportDate <= toDate.AddDays(1)), x => x.ImportHistories.Where(y => y.ImportDate >= formDate && y.ImportDate <= toDate.AddDays(1)));

            var listMaterial = MaterialsReport(materials, daySearch,formDate);
            


            return CreateExcelFile(listMaterial); 
        }
        private List<ReportExcelDTO> MaterialsReport(IQueryable<Material> materials,int daySearch,DateTime formDate)
        {

            var materialsReport = new List<ReportExcelDTO>();
            foreach (var item in materials)
            {
                for (var i = 0; i <= daySearch; i++)
                {
                    DateTime newddate = formDate.AddDays(i);

                    var quantityImport = item.ImportHistories.Where(x => x.MaterialNavigation.Qcode == item.Qcode && x.ImportDate == newddate).Sum(x => x.Quantity);
                    var quantityExport = item.ExportHistories.Where(x => x.MaterialNavigation.Qcode == item.Qcode && x.ExportDate == formDate.AddDays(i)).Sum(x => x.Quantity);
                    materialsReport.Add(new ReportExcelDTO
                    {
                        QCode = item.Qcode,
                        //Unit = item.UnitNavigation.Name,
                        Price = item.ExportHistories.Where(x => x.MaterialNavigation.Qcode == item.Qcode).FirstOrDefault().Price,
                        //Location = item.Location,
                        ImportQuantity = quantityImport,
                        //ExportQuantity = quantityExport,
                        //ExportDate = newddate
                    });
                }
            }
            return materialsReport;
        }
        private Stream CreateExcelFile(List<ReportExcelDTO> listItem, Stream stream = null)
        {
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            using (var excelPackage = new ExcelPackage(stream ?? new MemoryStream()))
            {
                // Tạo author cho file Excel
                excelPackage.Workbook.Properties.Author = "DongNguyen";
                // Tạo title cho file Excel
                excelPackage.Workbook.Properties.Title = "EPP test background";
                // thêm tí comments vào làm màu 
                excelPackage.Workbook.Properties.Comments = "This is my fucking generated Comments";
                // Add Sheet vào file Excel
                excelPackage.Workbook.Worksheets.Add("First-Sheet");
                // Lấy Sheet bạn vừa mới tạo ra để thao tác 
                var workSheet = excelPackage.Workbook.Worksheets["First-Sheet"];
                // Đỗ data vào Excel file
                workSheet.Cells[1, 1].LoadFromCollection(listItem, true, TableStyles.Dark9);
                BindingFormatForExcel(workSheet, listItem);
                excelPackage.Save();
                excelPackage.SaveAs(new FileInfo(@"D:\\New.xlsx"));
                return excelPackage.Stream;
            }
        }
        private void BindingFormatForExcel(ExcelWorksheet worksheet, List<ReportExcelDTO> listMaterial)
        {
            // Set default width cho tất cả column
            //worksheet.DefaultColWidth = 10;
            // Tự động xuống hàng khi text quá dài
            worksheet.Cells.Style.WrapText = true;
            // Tạo header
            worksheet.Cells[1, 1].Value = "ID";
            worksheet.Cells[1, 2].Value = "Full Name";
            worksheet.Cells[1, 3].Value = "Address";
            worksheet.Cells[1, 4].Value = "Money";

            // Lấy range vào tạo format cho range đó ở đây là từ A1 tới D1
            using (var range = worksheet.Cells["A1:D1"])
            {
                // Set PatternType
                range.Style.Fill.PatternType = ExcelFillStyle.DarkGray;
                // Set Màu cho Background
                range.Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                // Canh giữa cho các text
                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                // Set Font cho text  trong Range hiện tại
                //range.Style.Font.SetFromFont(new Font("Arial", 10));
                // Set Border
                range.Style.Border.Bottom.Style = ExcelBorderStyle.Thick;
                // Set màu ch Border
                range.Style.Border.Bottom.Color.SetColor(Color.Blue);
            }

            // Đỗ dữ liệu từ list vào 
            for (int i = 0; i < listMaterial.Count; i++)
            {
                var item = listMaterial[i];
                worksheet.Cells[i + 2, 1].Value = i;
                worksheet.Cells[i + 2, 2].Value = item.QCode;
                worksheet.Cells[i + 2, 3].Value = item.ImportQuantity;
                worksheet.Cells[i + 2, 4].Value = item.Price;



            }
            // Format lại định dạng xuất ra ở cột Money
            worksheet.Cells[2, 4, listMaterial.Count + 4, 4].Style.Numberformat.Format = "$#,##.00";
            // fix lại width của column với minimum width là 15
            worksheet.Cells[1, 1, listMaterial.Count + 5, 4].AutoFitColumns(15);

            // Thực hiện tính theo formula trong excel
            // Hàm Sum 
            worksheet.Cells[listMaterial.Count + 3, 3].Value = "Total is :";
            worksheet.Cells[listMaterial.Count + 3, 4].Formula = "SUM(D2:D" + (listMaterial.Count + 1) + ")";
           
        }


    }
}
