using Hospital.Dto.Atendimento.Create;
using Hospital.Models.Atendimento.Interfaces;
using Hospital.Models.Cadastro;

namespace Hospital.Models.Atendimento;
public class Consulta
: Atendimento, IAtendimento<ConsultaCreationDto>
{
    public string Diagnostico { get; set; }
    // prescrição medica
    public string? Observacoes { get; set; }
    public void Creation(
        ConsultaCreationDto request,
        Medico medico,
        Paciente paciente)
    {
        base.Creation(request, medico, paciente);
        Diagnostico = request.Diagnostico;
        Observacoes = request.Observacoes;
    }
}
