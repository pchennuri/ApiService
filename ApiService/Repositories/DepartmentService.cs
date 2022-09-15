using ApiService.Interfaces;
using ApiService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Repositories
{
    public class DepartmentService : IDepartmentInterface
    {
        private readonly ApplicationDbContext dbContext;
        public DepartmentService(ApplicationDbContext applicationDbContext)
        {
            this.dbContext = applicationDbContext;
        }
        public async Task<int> Delete(int id)
        {
            var dpet = await dbContext.departments.FindAsync(id);
            if (dpet != null)
                dbContext.departments.Remove(dpet);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<List<Department>> Get()
        {
            return await dbContext.departments.ToListAsync();
        }

        public async Task<Department> Get(int id)
        {
            return await dbContext.departments.Where(x => x.DepartmentId == id).FirstOrDefaultAsync();
        }

        public async Task<int> Save(Department department)
        {
            if (department != null)
                await dbContext.departments.AddAsync(department);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> Update(int id, Department department)
        {
            var depa = await dbContext.departments.FindAsync(id);

            if(depa !=null)
            {
                depa.Name = department.Name;
            }
            return await dbContext.SaveChangesAsync();
        }
    }
}
