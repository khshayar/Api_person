namespace Services.Personnels;

public class PersonnelAppService(UnitOfWork unitOfWork,
    PersonnelRepository repository,
    PersonnelQuery query)
    :PersonnelService
{
    public async Task Add(AddPersonnelDto dto)
    {
        var IsDuplicateByNationalCode = await query
            .DuplicateByNationalCode(dto.NationalCode);
        if (IsDuplicateByNationalCode)
        {
            throw new
                PersonnelNationalCodeDuplicateException();
        }

        if (dto.NationalCode.Length !=10 )
        {
            throw new
                NationalIsnotValidException();
        }

        if (dto.PhoneNumber.Length != 11)
        {
            throw new 
                PhoneNumberIsnotvalidException();
        }

        var personnel = new Personnel()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            NationalCode = dto.NationalCode,
            PhoneNumber = dto.PhoneNumber,
            Email = dto.Email,
            CreatAt = dto.CreatAt,
        };
        await repository.Add(personnel);
        await unitOfWork.Save();
    }
    
}