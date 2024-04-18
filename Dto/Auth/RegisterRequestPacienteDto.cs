namespace Hospital.Dto.Auth;
public class RegisterRequestPacienteDto
: RegisterRequestDto
{
    public required IFormFile DocumentoImg { get; set; }
    public Guid? ConvenioId { get; set; }
    public IFormFile? ConvenioImg { get; set; }
}