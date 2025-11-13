using application.DTOs;
using domain.Entities;

namespace application.Interfaces.Services;

public interface ICounterService
{
    Task<Counter> Add(CounterCreateDto counter);
    Task<bool> Update(Counter counter);
    Task<bool> Delete(Counter counter);
    Task<Counter?> GetById(int id);
    Task<List<Counter>> GetAll();
    Task<List<CounterWithCountDto>> GetCounterWithCount();
    Task<CounterWithCountDto?> GetCounterWithCount(int id);
}