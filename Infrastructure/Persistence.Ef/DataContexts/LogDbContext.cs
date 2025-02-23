using Persistence.Ef.Logs;

namespace Persistence.Ef.DataContexts;

public class LogDbContext: DbContext
{
    public LogDbContext(DbContextOptions<LogDbContext> options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(LogEntityMap).Assembly);
    }

    public DbSet<Log> Logs { get; set; }
}

