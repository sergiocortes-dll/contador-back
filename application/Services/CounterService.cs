using application.DTOs;
using application.Interfaces.Services;
using domain.Entities;
using domain.Interfaces.Repository;

namespace application.Services;

public class CounterService : ICounterService
{
    private readonly ICounterRepository _repo;
    private readonly IReasonRespository _repoReason;

    public CounterService(ICounterRepository repo, IReasonRespository repoReason)
    {
        _repo = repo;
        _repoReason = repoReason;
    }
    
    public async Task<Counter> Add(CounterCreateDto counter)
    {
        if (counter == null)
            throw new ArgumentNullException(nameof(counter));

        if (string.IsNullOrWhiteSpace(counter.Name))
            throw new ArgumentException("Counter name is required", nameof(counter.Name));

        if (string.IsNullOrWhiteSpace(counter.CreatedBy))
            throw new ArgumentException("CreatedBy is required", nameof(counter.CreatedBy));

        try
        {
            var newCounter = new Counter
            {
                Name = counter.Name.Trim(),
                Description = counter.Description?.Trim() ?? string.Empty,
                CreatedBy = counter.CreatedBy.Trim()
            };
        
            await _repo.Add(newCounter);
            await _repo.SaveAsync();

            var defaultReason = new Reason
            {
                Name = "General",
                Count = 1,
                CounterId = newCounter.Id,
            };

            await _repoReason.Add(defaultReason);
            await _repoReason.SaveAsync();

            return newCounter;
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to create counter: {ex.Message}", ex);
        }
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