namespace RestApi.Controllers.Personnels;
[Route("api/[controller]")]
[ApiController]
public class PersonnelController: ControllerBase
{
    private readonly PersonnelService _service;
    private readonly PersonnelQuery _query;

    public PersonnelController(PersonnelService service , PersonnelQuery query)
    {
        _service = service;
        _query = query;
    }

    [HttpPost]
    public async Task<ActionResult> CreatePersonnel([FromBody] AddPersonnelDto dto)
    {
        await _service.Add(dto);
        return Ok("Personnel created successfully");
    }

    [HttpGet]
    public async Task<ActionResult> GetPersonnels()
    {
        var personnels= await _query.GetAll();
        
        if (personnels is null) return NotFound("Personnels not found");
        
        return Ok(personnels);
    }

    [HttpGet("{NationalCode}")]
    public async Task<ActionResult> GetPersonnelById(string NationalCode)
    {
        if (!await _query.DuplicateByNationalCode(NationalCode))
        {
            return NotFound("Personnel with NationalCode " + NationalCode + " not found");
        }
        var personnel=await _query.GetByNationalCode(NationalCode);
        return Ok(personnel);
    }
}