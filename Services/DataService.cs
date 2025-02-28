using EconomicsTrackerApi.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using EconomicsTrackerApi.Databse;

public class DataService : IDataService
{
    private readonly EconomicsTrackerContext _context;

    public DataService(EconomicsTrackerContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Data>> GetAllDataAsync()
    {
        return await _context.Data.ToListAsync();
    }

    public async Task<Data> GetDataByIdAsync(int id)
    {
        return await _context.Data.FindAsync(id);
    }

    public async Task AddDataAsync(Data data)
    {
        _context.Data.Add(data);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateDataAsync(int id, Data data)
    {
        _context.Entry(data).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteDataAsync(int id)
    {
        var data = await _context.Data.FindAsync(id);
        if (data != null)
        {
            _context.Data.Remove(data);
            await _context.SaveChangesAsync();
        }
    }
}