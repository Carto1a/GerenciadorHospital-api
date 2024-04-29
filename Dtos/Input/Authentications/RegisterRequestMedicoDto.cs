namespace Hospital.Dtos.Input.Authentications;
public class RegisterRequestMedicoDto
: RegisterRequestDto
{
    public IFormFile? DocCRMImg { get; set; }
    public int CRM { get; set; }
    public required string CRMUF { get; set; }
    public required string Especialidade { get; set; }
}