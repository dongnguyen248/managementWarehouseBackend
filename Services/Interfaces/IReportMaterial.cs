using Data;
using DTO;
using System;
using System.Collections.Generic;
using System.IO;

namespace Services.Interfaces
{
    public interface IReportMaterial
    {
        Stream GetReportExcel(DateTime formDate, DateTime toDate);

    }
}
