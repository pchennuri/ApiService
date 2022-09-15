using ApiService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Interfaces
{
   public interface IJobsInterface
    {
        Task<int> Save(Jobs jobs);
        Task<int> Delete(int id);
        Task<int> Update(int id, Jobs jobs);
        Task<List<CustomJobs>> Get();
        Task<Jobs> Get(int id);

    }
}
