using AutoMapper;
using Data;
using DTO;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using Utilities;

namespace Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeService(IRepository<Employee> employeeRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            
        }

        public EmployeeDTO Login(EmployeeDTO employee)
        {
            string passwordEncrypted = Encryptor.MD5Hash(employee.PasswordOriginal);
            Employee result = _employeeRepository.FindSingle(x => x.EmployeeId == employee.EmployeeId && x.Password == passwordEncrypted && x.IsActive);
            return _mapper.Map<EmployeeDTO>(result);
        }
        public IEnumerable<EmployeeDTO> GetAllEmployee()
        {
            var result = _employeeRepository.FindAll();
            return _mapper.Map<IEnumerable<EmployeeDTO>>(result);
        }

        public void Create(EmployeeDTO employee)
        {
            var emp = _employeeRepository.FindSingle(x=>x.EmployeeId == employee.EmployeeId);
            if(emp != null)
            {
                throw new InvalidOperationException("employee already created");
            }
            else
            {

                try
                {
                    employee.Password = Encryptor.MD5Hash(employee.Password);
                    _employeeRepository.Add(_mapper.Map<Employee>(employee));
                    _unitOfWork.Commit();

                }catch (Exception ex)
                {
                    throw new InvalidOperationException(ex.Message);
                }
            }
            
            
        }

        public void Update(EmployeeDTO employee)
        {
            try
            {
            employee.Password = Encryptor.MD5Hash(employee.Password);
            _employeeRepository.Update(_mapper.Map<Employee>(employee));
            _unitOfWork.Commit();

            }catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        public void ChangePassword(int id, string newPassword, string oldPassword)
        {
            var employee = _employeeRepository.FindById(id);

            if (employee != null)
            {
                bool checkPassword = employee.Password == Encryptor.MD5Hash(oldPassword);
                if (checkPassword)
                {
                    try
                    {
                        employee.Password = Encryptor.MD5Hash(newPassword);
                        _employeeRepository.Update(_mapper.Map<Employee>(employee));
                        _unitOfWork.Commit();
                    }catch(Exception ex)
                    {
                        throw new InvalidOperationException(ex.Message);
                    }
                }
                else
                {
                    throw new InvalidOperationException("Old  Pasword is Wrong Please check again!");
                }

            }
            else
            {
                throw new InvalidOperationException("User  is Wrong Please check again!");
            }
           
        }

        public void Delete(int id)
        {
            try
            {
                _employeeRepository.Remove(id);
                _unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
           
        }
    }
}