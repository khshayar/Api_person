using Entities.Personnels;
using Persistence.Ef.DataContexts;

namespace Persistence.Ef.Personnels;

public class EfPersonnalQuery(EfDataContext context)
    :PersonnelQuery
{
    public async Task<bool> DuplicateByNationalCode(string nationalCode)
    {
        return await context.Set<Personnel>().AnyAsync(_ => _.NationalCode == nationalCode);
    }
    

    public async Task<IEnumerable<Personnel>> GetAll()
    {
        return await context.Set<Personnel>().ToListAsync();
    }
    

    public async Task<Personnel> GetByNationalCode(string nationalCode)
    {
        return await context.Set<Personnel>()
            .FirstOrDefaultAsync(x => x.NationalCode == nationalCode);
    }
}