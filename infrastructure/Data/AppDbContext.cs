using domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Counter> counter { get; set; }
    public DbSet<Reason> reason { get; set; }
    public DbSet<ReasonFeedback> reason_feedback { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}