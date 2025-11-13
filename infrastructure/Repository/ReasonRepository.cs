using domain.Entities;
using domain.Interfaces.Repository;
using infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Repository;

public class ReasonRepository : IReasonRespository
{
    private readonly AppDbContext _context;

    public ReasonRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Reason> Add(Reason reason)
    {
        await _context.reason.AddAsync(reason);
        return reason;
    }

    public bool Update(Reason reason)
    {
        _context.reason.Update(reason);
        return true;
    }

    public bool Delete(Reason reason)
    {
        _context.reason.Remove(reason);
        return true;
    }

    public async Task<Reason?> GetById(int id)
    {
        return await  _context.reason.FindAsync(id);
    }

    public async Task<List<Reason>> GetAll()
    {
        return await _context.reason.ToListAsync();
    }

    public async Task<bool> SaveAsync()
    {
        await _context.SaveChangesAsync();
        return true;
    }
}