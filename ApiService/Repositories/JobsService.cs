using ApiService.Interfaces;
using ApiService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Repositories
{
    public class JobsService : IJobsInterface
    {
        private readonly ApplicationDbContext dbContext;
        public JobsService(ApplicationDbContext applicationDbContext)
        {
            this.dbContext = applicationDbContext;
        }
        public async Task<int> Delete(int id)
        {
            var jbs = await dbContext.jobs.FindAsync(id);
            if (jbs != null)
                dbContext.jobs.Remove(jbs);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<List<CustomJobs>> Get()
        {
            var custom = await (from n in dbContext.jobs
                                select new CustomJobs
                                {
                                    Id = n.ID,
                                    Title = n.Title,
                                    location = dbContext.locations.Where(x => x.LocationId == n.LocationId).FirstOrDefault().Name,
                                    Department = dbContext.departments.Where(x => x.DepartmentId == n.DepartmentId).FirstOrDefault().Name,
                                    Description = n.Description,
                                    ClosingDate = n.ClosingDate
                                }).ToListAsync();

            var data = await (from n in dbContext.jobs
                              join d in dbContext.departments on n.DepartmentId equals d.DepartmentId
                              join l in dbContext.locations on n.LocationId equals l.LocationId
                              select new CustomJobs
                              {
                                  Id = n.ID,
                                  Title = n.Title,
                                  location = l.Name,
                                  Department = d.Name,
                                  Description = n.Description,
                                  ClosingDate = n.ClosingDate

                              }).ToListAsync();
            return custom;

        }

        public async Task<Jobs> Get(int id)
        {
            return await dbContext.jobs.Where(x => x.ID == id).FirstOrDefaultAsync();
        }

        public async Task<int> Save(Jobs jbs)
        {
            if (jbs != null)
                await dbContext.jobs.AddAsync(jbs);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> Update(int id, Jobs jbs)
        {
            var jb = await dbContext.jobs.FindAsync(id);

            if (jb != null)
            {
                jb.Title = jbs.Title;
                jb.Description = jbs.Description;

            }
            return await dbContext.SaveChangesAsync();
        }
    }
}
