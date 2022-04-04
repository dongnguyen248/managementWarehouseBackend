using DTO;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface ILineService
    {
        IEnumerable<LineDTO> GetAll();
    }
}