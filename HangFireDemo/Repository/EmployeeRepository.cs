using HangFireDemo.Interface;
using HangFireDemo.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangFireDemo.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Employee> AddEmployee(Employee model)
        {
            var employee = await _context.Employees.AddAsync(model);
            return employee.Entity;
        }

        public async Task DeleteEmployee(string id)
        {
            var employee = await GetEmployee(id);
            _context.Employees.Remove(employee);
        }

        public async Task<Employee> GetEmployee(string id)
        {
            return await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public void UpdateEmployee(Employee model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }

        public async Task<bool> EmployeeExists(string id)
        {
            return await _context.Employees.AnyAsync(x => x.Id == id);
        }
    }
}
