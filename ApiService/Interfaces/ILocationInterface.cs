using ApiService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Interfaces
{
   public interface ILocationInterface
    {
        Task<int> Save(Location location);
        Task<int> Delete(int id);
        Task<int> Update(int id, Location location);
        Task<List<Location>> Get();
        Task<Location> Get(int id);

    }
}
