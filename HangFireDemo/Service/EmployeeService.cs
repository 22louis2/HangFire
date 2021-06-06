using HangFireDemo.Interface;
using HangFireDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangFireDemo.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _employeeRepository.GetEmployees();
        }

        public async Task<Employee> GetEmployee(string id)
        {
            return await _employeeRepository.GetEmployee(id);
        }

        public void UpdateEmployee(string id, Employee model)
        {
            model.Id = id;
            _employeeRepository.UpdateEmployee(model);
        }

        public async Task<Employee> AddEmployee(Employee model)
        {
            return await _employeeRepository.AddEmployee(model);
        }

        public async Task DeleteEmployee(string id)
        {
            await _employeeRepository.DeleteEmployee(id);
        }

        public async Task<bool> EmployeeExist(string id)
        {
            return await _employeeRepository.EmployeeExists(id);
        }
    }
}
