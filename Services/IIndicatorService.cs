using EconomicsTrackerApi.DTOs;
using EconomicsTrackerApi.Models;

public interface IIndicatorService
{
    Task<IEnumerable<Indicator>> GetAllIndicatorsAsync();
    Task<Indicator> GetIndicatorByIdAsync(int id);
    Task AddIndicatorAsync(Indicator indicator);
    Task UpdateIndicatorAsync(int id, Indicator indicator);
    Task DeleteIndicatorAsync(int id);
}