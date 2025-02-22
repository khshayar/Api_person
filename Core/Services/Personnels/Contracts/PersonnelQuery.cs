namespace Services.Personnels.Contracts;

public interface PersonnelQuery
{
    Task<bool> DuplicateByNationalCode(string nationalCode);
    Task<IEnumerable<Personnel>> GetAll();
    Task<Personnel> GetByNationalCode(string nationalCode);
}