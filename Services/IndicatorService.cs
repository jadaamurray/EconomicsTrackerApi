using EconomicsTrackerApi.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using EconomicsTrackerApi.Database;

public class IndicatorService : IIndicatorService
{
    private readonly EconomicsTrackerContext _context;

    public IndicatorService(EconomicsTrackerContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Indicator>> GetAllIndicatorsAsync()
    {
        return await _context.Indicators.ToListAsync();
    }

    public async Task<Indicator> GetIndicatorByIdAsync(int id)
    {
        return await _context.Indicators.FindAsync(id);
    }

    public async Task AddIndicatorAsync(Indicator indicator)
    {
        _context.Indicators.Add(indicator);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateIndicatorAsync(int id, Indicator indicator)
    {
        _context.Entry(indicator).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteIndicatorAsync(int id)
    {
        var indicator = await _context.Indicators.FindAsync(id);
        if (indicator != null)
        {
            _context.Indicators.Remove(indicator);
            await _context.SaveChangesAsync();
        }
    }
}