using HangFireDemo.Interface;
using HangFireDemo.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangFireDemo.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DataContext _context;
        public DepartmentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Department> AddDepartment(Department model)
        {
            var department = await _context.Departments.AddAsync(model);
            return department.Entity;
        }

        public async Task DeleteDepartment(string id)
        {
            var department = await GetDepartment(id);
            _context.Departments.Remove(department);
        }

        public async Task<bool> DepartmentExist(string id)
        {
            return await _context.Departments.AnyAsync(x => x.Id == id);
        }

        public async Task<Department> GetDepartment(string id)
        {
            return await _context.Departments.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _context.Departments.ToListAsync();
        }

        public void UpdateDepartment( Department model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }
    }
}
