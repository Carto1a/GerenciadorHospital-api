namespace Hospital.Dtos.Input.Authentications;
public class RegisterRequestPacienteDto
: RegisterRequestDto
{
    public IFormFile DocIDImg { get; set; }
    public IFormFile? DocConvenioImg { get; set; }
    public Guid? ConvenioId { get; set; }
}