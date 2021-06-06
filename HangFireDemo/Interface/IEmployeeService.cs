using HangFireDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangFireDemo.Interface
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(string id);
        void UpdateEmployee(string id, Employee model);
        Task<Employee> AddEmployee(Employee model);
        Task DeleteEmployee(string id);
        Task<bool> EmployeeExist(string id);
    }
}
