using Persistence.Ef.Personnels;

namespace Persistence.Ef.DataContexts;

public class EfDataContext: DbContext
{
    public EfDataContext(string connectionString) : this(
        new DbContextOptionsBuilder<EfDataContext>()
            .UseSqlServer(connectionString).Options)
    {
    }
    public EfDataContext(DbContextOptions<EfDataContext> options) :
        base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(PersonnelEntityMap).Assembly);
    }
}