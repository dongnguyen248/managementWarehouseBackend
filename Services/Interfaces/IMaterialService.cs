using DTO;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IMaterialService
    {
        IEnumerable<MaterialDTO> GetAll(int page, int pageSize, out int totalRow);

        IEnumerable<MaterialDTO> Search(string qCode, string zone, string location, string item, string specification, int page, int pageSize, out int totalRow);

        void Add(MaterialDTO material);
    }
}