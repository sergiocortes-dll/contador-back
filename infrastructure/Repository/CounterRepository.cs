using domain.Entities;
using domain.Interfaces.Repository;
using infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Repository;

public class CounterRepository : ICounterRepository
{
    private readonly AppDbContext _context;

    public CounterRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Counter> Add(Counter counter)
    {
        await _context.counter.AddAsync(counter);
        return counter;
    }

    public bool Update(Counter counter)
    {
        _context.counter.Update(counter);
        return true;
    }

    public bool Delete(Counter counter)
    {
        _context.counter.Remove(counter);
        return true;
    }

    public async Task<Counter?> GetById(int id)
    {
        return await  _context.counter.FindAsync(id);
    }

    public async Task<List<Counter>> GetAll()
    {
        return await _context.counter.ToListAsync();
    }

    public async Task<bool> SaveAsync()
    {
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Counter>> GetByIdWithReasonAsync()
    {
        return await _context.counter
            .Include(c => c.Reasons)
            .ToListAsync();
    }

    public async Task<Counter?> GetByIdWithReasonAsync(int id)
    {
        return await _context.counter
            .Include(c => c.Reasons)
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}