using AutoMapper;
using BusinessObject.DTO;
using BusinessObject.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Repository.Employees
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public readonly IMapper _mapper;
        public EmployeeRepository(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<EmployeeCreateUpdateDTO> CreateEmployee(EmployeeCreateUpdateDTO employeeDTO)
        {
            var employee = _mapper.Map<Employee>(employeeDTO);
            return _mapper.Map<EmployeeCreateUpdateDTO>(await EmployeeDAO.CreateEmployee(employee));
        }

        public async Task DeleteEmployee(int id) => await EmployeeDAO.DeleteEmployee(id);

        public async Task<EmployeeDTO> GetEmployeeById(int id)
        {
            Employee employee = await EmployeeDAO.GetEmployeeById(id);
            return _mapper.Map<EmployeeDTO>(employee);
        }

        public async Task<List<EmployeeDTO>> GetEmployees(string? searchString)
        {
            List<Employee> employees = await EmployeeDAO.GetEmployees(searchString);
            List<EmployeeDTO> employeeDTOs = _mapper.Map<List<EmployeeDTO>>(employees);

            return employeeDTOs;
        }

        public async Task<EmployeeCreateUpdateDTO> UpdateEmployee(EmployeeCreateUpdateDTO employeeDTO)
        {
            var employee = _mapper.Map<Employee>(employeeDTO);
            return _mapper.Map<EmployeeCreateUpdateDTO>(await EmployeeDAO.UpdateEmployee(employee));
        }
    }
}
