using Data;
using DTO;
using System;
using System.Collections.Generic;
using System.IO;

namespace Services.Interfaces
{
    public interface IReportMaterial
    {
        string GetReportExcel(DateTime formDate, DateTime toDate);

    }
}
