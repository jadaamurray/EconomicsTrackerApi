using EconomicsTrackerApi.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using EconomicsTrackerApi.Database;

public class RegionService : IRegionService
{
    private readonly EconomicsTrackerContext _context;

    public RegionService(EconomicsTrackerContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Region>> GetAllRegionsAsync()
    {
        return await _context.Regions.ToListAsync();
    }

    public async Task<Region> GetRegionByIdAsync(int id)
    {
        return await _context.Regions.FindAsync(id);
    }

    public async Task AddRegionAsync(Region region)
    {
        _context.Regions.Add(region);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateRegionAsync(int id, Region region)
    {
        _context.Entry(region).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteRegionAsync(int id)
    {
        var region = await _context.Regions.FindAsync(id);
        if (region != null)
        {
            _context.Regions.Remove(region);
            await _context.SaveChangesAsync();
        }
    }
}