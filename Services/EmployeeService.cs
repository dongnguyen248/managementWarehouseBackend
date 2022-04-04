using AutoMapper;
using Data;
using DTO;
using Repositories.Interfaces;
using Services.Interfaces;
using Utilities;

namespace Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IRepository<Employee> employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public EmployeeDTO Login(EmployeeDTO employee)
        {
            string passwordEncrypted = Encryptor.MD5Hash(employee.PasswordOriginal);
            Employee result = _employeeRepository.FindSingle(x => x.EmployeeId == employee.EmployeeId && x.Password == passwordEncrypted && x.IsActive);
            return _mapper.Map<EmployeeDTO>(result);
        }
    }
}