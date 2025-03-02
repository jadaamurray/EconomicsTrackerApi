using EconomicsTrackerApi.Database;
using EconomicsTrackerApi.Models;
using Microsoft.EntityFrameworkCore;


namespace EconomicsTrackerApi.Repositories
{
    public class SourceRepository
    {
        private readonly EconomicsTrackerContext _context;

        public SourceRepository(EconomicsTrackerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Source>> GetAllAsync() => await _context.Sources.ToListAsync();

        public async Task<Source> GetByIdAsync(int id) => await _context.Sources.FindAsync(id);

        public async Task AddAsync(Source source)
        {
            _context.Sources.Add(source);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Source source)
        {
            _context.Entry(source).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var source = await _context.Sources.FindAsync(id);
            if (source != null)
            {
                _context.Sources.Remove(source);
                await _context.SaveChangesAsync();
            }
        }
    }
}