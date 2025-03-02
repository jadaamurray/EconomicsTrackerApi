using EconomicsTrackerApi.Database;
using EconomicsTrackerApi.Models;
using Microsoft.EntityFrameworkCore;


namespace EconomicsTrackerApi.Repositories
{
    public class IndicatorRepository
    {
        private readonly EconomicsTrackerContext _context;

        public IndicatorRepository(EconomicsTrackerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Indicator>> GetAllAsync() => await _context.Indicators.ToListAsync();

        public async Task<Indicator> GetByIdAsync(int id) => await _context.Indicators.FindAsync(id);

        public async Task AddAsync(Indicator indicator)
        {
            _context.Indicators.Add(indicator);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Indicator indicator)
        {
            _context.Entry(indicator).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var indicator = await _context.Indicators.FindAsync(id);
            if (indicator != null)
            {
                _context.Indicators.Remove(indicator);
                await _context.SaveChangesAsync();
            }
        }
    }
}