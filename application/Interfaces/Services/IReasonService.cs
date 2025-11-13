using application.DTOs;
using domain.Entities;

namespace application.Interfaces.Services;

public interface IReasonService
{
    Task<Reason> Add(ReasonCreateDto reason);
    Task<bool> Update(Reason reason);
    Task<bool> Delete(Reason reason);
    Task<Reason?> GetById(int id);
    Task<List<Reason>> GetAll();
}