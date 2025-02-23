using Entities.Personnels;
using Persistence.Ef.DataContexts;

namespace Persistence.Ef.Personnels;

public class EfPersonnelRepository(EfDataContext context)
    :PersonnelRepository
{
    public async Task Add(Personnel personnel)
    {
        await context.Set<Personnel>().AddAsync(personnel);
    }
}