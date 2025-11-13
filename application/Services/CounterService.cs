using application.DTOs;
using application.Interfaces.Services;
using domain.Entities;
using domain.Interfaces.Repository;

namespace application.Services;

public class CounterService : ICounterService
{
    private readonly ICounterRepository _repo;

    public CounterService(ICounterRepository repo)
    {
        _repo = repo;
    }
    
    public async Task<Counter> Add(CounterCreateDto counter)
    {
        var c = new Counter
        {
            Name = counter.Name,
            Description = counter.Description,
            CreatedBy = counter.CreatedBy
        };
        
        await _repo.Add(c);
        await _repo.SaveAsync();
        return c;
    }

    public async Task<bool> Update(Counter counter)
    {
        _repo.Update(counter);
        await _repo.SaveAsync();
        return true;
    }

    public async Task<bool> Delete(Counter counter)
    {
        _repo.Delete(counter);
        await _repo.SaveAsync();
        return true;
    }

    public async Task<Counter?> GetById(int id)
    {
        var counter = await _repo.GetById(id);
        return counter;
    }

    public async Task<List<Counter>> GetAll()
    {
        return await _repo.GetAll();
    }


    public async Task<List<CounterWithCountDto>> GetCounterWithCount()
    {
        var counters = await _repo.GetByIdWithReasonAsync();
        return counters.Select(c => new CounterWithCountDto
        {
            Id = c.Id,
            Name = c.Name,
            Description = c.Description,
            CreatedBy = c.CreatedBy,
            Count = c.Reasons.Sum(r => r.Count)
        }).ToList();
    }

    public async Task<CounterWithCountDto?> GetCounterWithCount(int id)
    {
        var counter = await _repo.GetByIdWithReasonAsync(id);
        if (counter == null) return null;

        return new CounterWithCountDto
        {
            Id = counter.Id,
            Name = counter.Name,
            Description = counter.Description,
            CreatedBy = counter.CreatedBy,
            Count = counter.Reasons.Sum(r => r.Count)
        };
    }
}