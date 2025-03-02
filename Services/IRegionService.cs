using EconomicsTrackerApi.DTOs;
using EconomicsTrackerApi.Models;

public interface IRegionService
{
    Task<IEnumerable<Region>> GetAllRegionsAsync();
    Task<Region> GetRegionByIdAsync(int id);
    Task AddRegionAsync(Region region);
    Task UpdateRegionAsync(int id, Region region);
    Task DeleteRegionAsync(int id);
}