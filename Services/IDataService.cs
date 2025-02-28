using EconomicsTrackerApi.DTOs;
using EconomicsTrackerApi.Models;

public interface IDataService
{
    Task<IEnumerable<Data>> GetAllDataAsync();
    Task<Data> GetDataByIdAsync(int id);
    Task AddDataAsync(Data data);
    Task UpdateDataAsync(int id, Data data);
    Task DeleteDataAsync(int id);
}
