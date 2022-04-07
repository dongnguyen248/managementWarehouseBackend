using AutoMapper;
using Data;
using DTO;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DepartmentService : IDeparmentService
    {
        private readonly IRepository<Department> _departmentRepository;
        private readonly IMapper _mapper;
        public DepartmentService(IRepository<Department> departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }
        public IEnumerable<DepartmentDTO> GetAll()
        {
            var deparments = _departmentRepository.FindAll();
            return _mapper.Map<IEnumerable<DepartmentDTO>>(deparments);
        }
    }
}
