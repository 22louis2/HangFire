using HangFireDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangFireDemo.Interface
{
    public interface IEmployeeRepository
    {
        Task<Employee> AddEmployee(Employee model);
        Task<Employee> GetEmployee(string id);
        Task<IEnumerable<Employee>> GetEmployees();
        void UpdateEmployee(Employee model); 
        Task DeleteEmployee(string id);
        Task<bool> EmployeeExists(string id);
    }
}
