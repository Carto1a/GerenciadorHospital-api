using Hospital.Models.Cadastro;

namespace Hospital.Dto.Auth;
public class RegisterRequestPacienteDto : RegisterRequestDto
{
    public IFormFile Convenio { get; set; }
    public IFormFile Documento { get; set; }
    public bool TemConvenio { get; set; }
    public List<Convenio>? Convenios { get; set; }
}
