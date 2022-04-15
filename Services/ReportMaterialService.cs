﻿using AutoMapper;
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
        public string GetReportExcel(DateTime formDate, DateTime toDate)
        {
            int daySearch = (toDate.AddDays(1) - formDate).Days;
            var materials = _materialRepository.FindAll(x=>x.UnitNavigation,x=>x.ZoneNavigation,
                                                        x => x.ExportHistories.Where(y => y.ExportDate >= formDate && y.ExportDate <= toDate.AddDays(1)), 
                                                        x => x.ImportHistories.Where(y => y.ImportDate >= formDate && y.ImportDate <= toDate.AddDays(1)));

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
                    var importItem = _exportRepository.FindSingle(x => x.MaterialNavigation.Qcode == item.Qcode,x=>x.CostAccountItemNavigation,x=>x.CostAccountNavigation,x =>x.ReceiverNavigation);
                    materialsReport.Add(new ReportExcelDTO
                    {
                        QCode = item.Qcode,
                        Unit = item.UnitNavigation.Name,
                        Price = item.ExportHistories.Where(x => x.MaterialNavigation.Qcode == item.Qcode).FirstOrDefault().Price,
                        Location = item.Location,
                        ImportQuantity = quantityImport,
                        ExportQuantity = quantityExport,
                        ExportDate = newddate,
                        Item = item.Item,
                        Specification = item.Specification,
                        Line = importItem.ReceiverNavigation.Name,
                        CostLine = importItem.ReceiverNavigation.CostCenter,
                        CostAccount = importItem.CostAccountNavigation.Name,
                        costAccountItem = importItem.CostAccountItemNavigation.Note,
                        Locator = "QMA01." + item.ZoneNavigation.Name + item.Location,
                        Inspection = _importtRepository.FindSingle(x => x.MaterialNavigation.Qcode == item.Qcode,x=>x.InspectionNavigation).InspectionNavigation.Inspector
                       

                    }) ;
                }
            }
            return materialsReport;
        }
        private string CreateExcelFile(List<ReportExcelDTO> listItem, Stream stream = null)
        {
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            using (var excelPackage = new ExcelPackage(stream ?? new MemoryStream()))
            {
                
                excelPackage.Workbook.Properties.Author = "DongNguyen";
                
                excelPackage.Workbook.Worksheets.Add("First-Sheet");

                var workSheet = excelPackage.Workbook.Worksheets["First-Sheet"];
                workSheet.DefaultColWidth = 30;
                workSheet.Row(1).Height = 40;
               
                BindingFormatForExcel(workSheet, listItem);
                workSheet.Cells[$"A2:A{listItem.Count()}"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                var fileName = $"Dally-Report--{DateTime.Now.ToString("yyyyMMddhhmmssff")}.xlsx" ;
                excelPackage.SaveAs(new FileInfo($@"D:\\C#\WarehouseManagement-main\\Web\\FileReport\\{fileName}"));
                return fileName;
            }
        }
        private void BindingFormatForExcel(ExcelWorksheet worksheet, List<ReportExcelDTO> listMaterial)
        {
           
            worksheet.Cells.Style.WrapText = true;
            worksheet.Cells[1, 1].Value = "No";
            worksheet.Cells[1, 2].Value = "Export Date";
            worksheet.Cells[1, 3].Value = "QCode";
            worksheet.Cells[1, 4].Value = "Item";
            worksheet.Cells[1, 5].Value = "Spec";
            worksheet.Cells[1, 6].Value = "Unit";
            worksheet.Cells[1, 7].Value = "Price";
            worksheet.Cells[1, 8].Value = "In";
            worksheet.Cells[1, 9].Value = "Out";
            worksheet.Cells[1, 10].Value = "Line";
            worksheet.Cells[1, 11].Value = "Cost Center";
            worksheet.Cells[1, 12].Value = "Cost Account";
            worksheet.Cells[1, 13].Value = "Cost AcoutnItem";
            worksheet.Cells[1, 14].Value = "Locator";
            worksheet.Cells[1, 15].Value = "Inspection";

            using (var range = worksheet.Cells["A1:O1"])
            {
                Color colFromHex = ColorTranslator.FromHtml("#29E669");
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(colFromHex);
                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                range.Style.Font.Bold = true;
                range.Style.Font.Color.SetColor(Color.Black);
                
            }

            // Đỗ dữ liệu từ list vào 
            for (int i = 1; i < listMaterial.Count; i++)
            {
                
                var item = listMaterial[i];
                worksheet.Cells[i + 1, 1].Value = i;
                worksheet.Cells[i + 1, 2].Value = item.ExportDate.ToString("yyyy-MM-dd");
                worksheet.Cells[i + 1, 3].Value = item.QCode;
                worksheet.Cells[i + 1, 4].Value = item.Item;
                worksheet.Cells[i + 1, 5].Value = item.Specification;
                worksheet.Cells[i + 1, 6].Value = item.Unit;
                worksheet.Cells[i + 1, 7].Value = item.Price;
                worksheet.Cells[i + 1, 8].Value = item.ImportQuantity;
                worksheet.Cells[i + 1, 9].Value = item.ExportQuantity;
                worksheet.Cells[i + 1, 10].Value = item.Line;
                worksheet.Cells[i + 1, 11].Value = item.CostLine;
                worksheet.Cells[i + 1, 12].Value = item.CostAccount;
                worksheet.Cells[i + 1, 13].Value = item.costAccountItem;
                worksheet.Cells[i + 1, 14].Value = item.Locator;
                worksheet.Cells[i + 1, 15].Value = item.Inspection;
            }

            //worksheet.Cells["A1:O1"].AutoFitColumns();


        }


    }
}
