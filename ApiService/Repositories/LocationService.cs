using ApiService.Interfaces;
using ApiService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Repositories
{
    public class LocationService : ILocationInterface
    {
        private readonly ApplicationDbContext dbContext;
        public LocationService(ApplicationDbContext applicationDbContext)
        {
            this.dbContext = applicationDbContext;
        }
        public async Task<int> Delete(int id)
        {
            var loc = await dbContext.locations.FindAsync(id);
            if (loc != null)
                dbContext.locations.Remove(loc);
            return await dbContext.SaveChangesAsync();

        }

        public async Task<List<Location>> Get()
        {
            return await dbContext.locations.ToListAsync();
        }

        public async Task<Location> Get(int id)
        {
            return await dbContext.locations.Where(x => x.LocationId == id).FirstOrDefaultAsync();
        }

        public async Task<int> Save(Location location)
        {
            if (location != null)
                await dbContext.locations.AddAsync(location);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> Update(int id, Location location)
        {
            var loc = await dbContext.locations.FindAsync(id);

            if (loc != null)
            {
                loc.Name = location.Name;
            }
            return await dbContext.SaveChangesAsync();
        }
    }
}
