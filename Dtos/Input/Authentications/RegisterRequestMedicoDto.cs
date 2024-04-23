namespace Hospital.Dtos.Input.Authentications;
public class RegisterRequestMedicoDto
: RegisterRequestDto
{
    public IFormFile? DocCRMImg { get; set; }
    public string CRM { get; set; }
    public string Especialidade { get; set; }
}