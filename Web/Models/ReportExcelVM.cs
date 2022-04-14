﻿using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Web.Models
{
    //Feb-22	QCODE ITEM    SPEC UNIT    PRICE INVENTORY   IN OUT INVENTORY AMOUNT USD LINE    COST CENTER COST ACCOUNT    REMARK NOTE
    //NAME LOCATOR INSPECTION INSPECTION_DATE INSPECTOR RESULT

    public class ReportExcelVM
    {
     
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

       
    }
}
