using ApiService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Interfaces
{
    public interface IDepartmentInterface
    {
        Task<int> Save(Department department);
        Task<int> Delete(int id);
        Task<int> Update(int id, Department department);
        Task<List<Department>> Get();
        Task<Department> Get(int id);
        
    }
}
