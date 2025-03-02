using EconomicsTrackerApi.Database;
using EconomicsTrackerApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;


namespace EconomicsTrackerApi.Repositories
{
    public class DataRepository
    {
        private readonly EconomicsTrackerContext _context;
        private readonly ILogger<DataRepository> _logger;


        public DataRepository(EconomicsTrackerContext context, ILogger<DataRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Data>> GetAllAsync() => await _context.Data.ToListAsync();
        public async Task<Data> GetByIdAsync(int id) => await _context.Data.FindAsync(id);

        public async Task UpdateAsync(Data data)
        {
            _context.Entry(data).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _context.Data.FindAsync(id);
            if (data != null)
            {
                _context.Data.Remove(data);
                await _context.SaveChangesAsync();
            }
        }
    }
}