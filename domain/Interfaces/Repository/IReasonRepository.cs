using domain.Entities;

namespace domain.Interfaces.Repository;

public interface IReasonRespository
{
    Task<Reason> Add(Reason counter);
    bool Update(Reason counter);
    bool Delete(Reason counter);
    Task<Reason?> GetById(int id);
    Task<Reason?> GetGeneral(int id);
    Task<List<Reason>> GetAll();
    Task<List<Reason>> GetReasonsByCounterId(int counterId);
    Task<bool> IncrementCount(int reasonId);
    Task<bool> SaveAsync();
}