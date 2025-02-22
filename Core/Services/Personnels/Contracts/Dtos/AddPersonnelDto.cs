namespace Services.Personnels.Contracts;

public class AddPersonnelDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string NationalCode { get; set; }
    public required string PhoneNumber { get; set; }
    public required DateTime CreatAt { get; set; }
    public string? Email { get; set; }
}