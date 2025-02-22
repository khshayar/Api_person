namespace Services.Personnels.Contracts;

public interface PersonnelRepository
{
    Task Add(Personnel personnel);
}