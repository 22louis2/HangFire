using HangFireDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangFireDemo.Interface
{
    public interface IDepartmentRepository
    {
        Task<Department> AddDepartment(Department model); 
        Task<Department> GetDepartment(string id);
        Task<IEnumerable<Department>> GetDepartments();
        void UpdateDepartment(Department model);
        Task DeleteDepartment(string id);
        Task<bool> DepartmentExist(string id);  
    }
}
