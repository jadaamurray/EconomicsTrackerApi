using EconomicsTrackerApi.Database;
using EconomicsTrackerApi.Models;
using Microsoft.EntityFrameworkCore;


namespace EconomicsTrackerApi.Repositories
{
    public class RegionRepository
    {
        private readonly EconomicsTrackerContext _context;

        public RegionRepository(EconomicsTrackerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Region>> GetAllAsync() => await _context.Regions.ToListAsync();

        public async Task<Region> GetByIdAsync(int id) => await _context.Regions.FindAsync(id);

        public async Task AddAsync(Region region)
        {
            _context.Regions.Add(region);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Region region)
        {
            _context.Entry(region).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var region = await _context.Regions.FindAsync(id);
            if (region != null)
            {
                _context.Regions.Remove(region);
                await _context.SaveChangesAsync();
            }
        }
    }
}