using DTO;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IEmployeeService
    {
        EmployeeDTO Login(EmployeeDTO employee);
        void Create(EmployeeDTO employee);
        IEnumerable<EmployeeDTO> GetAllEmployee();
        void Update(EmployeeDTO employee);
        void Delete(int id);
        void ChangePassword(int id, string newPassword);
    }
}