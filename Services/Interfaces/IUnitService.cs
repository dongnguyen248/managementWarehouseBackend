using DTO;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IUnitService
    {
        IEnumerable<UnitDTO> GetAll();
    }
}