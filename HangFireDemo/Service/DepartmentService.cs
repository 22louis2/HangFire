using HangFireDemo.Interface;
using HangFireDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangFireDemo.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<Department> AddDepartment(Department model)
        {
            return await _departmentRepository.AddDepartment(model);
        }

        public async Task DeleteDepartment(string id)
        {
            await _departmentRepository.DeleteDepartment(id);
        }

        public async Task<bool> DepartmentExist(string id)
        {
            return await _departmentRepository.DepartmentExist(id); 
        }

        public async Task<Department> GetDepartment(string id)
        {
            return await _departmentRepository.GetDepartment(id);
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _departmentRepository.GetDepartments();
        }

        public void UpdateDepartment(string id, Department model)
        {
            model.Id = id;
            _departmentRepository.UpdateDepartment(model);
        }
    }
}
