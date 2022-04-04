using DTO;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IZoneService
    {
        IEnumerable<ZoneDTO> GetAll();
    }
}