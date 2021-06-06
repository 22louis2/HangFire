using HangFireDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangFireDemo.Interface
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetDepartments();
        Task<Department> GetDepartment(string id);
        void UpdateDepartment(string id, Department model);
        Task<Department> AddDepartment(Department model);
        Task DeleteDepartment(string id);
        Task<bool> DepartmentExist(string id); 
    }
}
