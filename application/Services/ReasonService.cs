using application.DTOs;
using application.Interfaces.Services;
using domain.Entities;
using domain.Interfaces.Repository;

namespace application.Services;

public class ReasonService : IReasonService
{
    private readonly IReasonRespository _repo;

    public ReasonService(IReasonRespository repo)
    {
        _repo = repo;
    }
    
    public async Task<Reason> Add(ReasonCreateDto reason)
    {
        var r = new Reason
        {
            Name = reason.Name,
            Count = reason.Count,
            CounterId = reason.CounterId
        };
        
        await _repo.Add(r);
        await _repo.SaveAsync();
        return r;
    }

    public async Task<bool> Update(Reason reason)
    {
        _repo.Update(reason);
        await _repo.SaveAsync();
        return true;
    }

    public async Task<bool> Delete(Reason reason)
    {
        _repo.Delete(reason);
        await _repo.SaveAsync();
        return true;
    }

    public async Task<Reason?> GetById(int id)
    {
        var reason = await _repo.GetById(id);
        return reason;
    }

    public async Task<List<Reason>> GetByCounter(int id)
    {
        return await _repo.GetReasonsByCounterId(id);
    }

    public async Task<List<Reason>> GetAll()
    {
        return await _repo.GetAll();
    }

    public async Task<bool> IncrementCount(int reasonId, int counterId)
    {
        if (reasonId == 0)
        {
            var generalReason = await _repo.GetGeneral(counterId);
            await _repo.IncrementCount(generalReason.Id);
        }
        else
        {
            await _repo.IncrementCount(reasonId);
        }
        await _repo.SaveAsync();
        return true;
    }
}