using domain.Entities;

namespace domain.Interfaces.Repository;

public interface ICounterRepository
{
    Task<Counter> Add(Counter counter);
    bool Update(Counter counter);
    bool Delete(Counter counter);
    Task<Counter?> GetById(int id);
    Task<List<Counter>> GetAll();
    Task<bool> SaveAsync();

    Task<List<Counter>> GetByIdWithReasonAsync();
    Task<Counter?> GetByIdWithReasonAsync(int id);
}