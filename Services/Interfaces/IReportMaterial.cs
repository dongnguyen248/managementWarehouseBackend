using Data;
using System;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IReportMaterial
    {
        IEnumerable<Material> GetReportExcel(DateTime formDate, DateTime toDate);

    }
}
