using DTO;

namespace Services.Interfaces
{
    public interface IEmployeeService
    {
        EmployeeDTO Login(EmployeeDTO employee);
    }
}