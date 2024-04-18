using Hospital.Dto.Atividades;
using Hospital.Models.Generics.Interfaces;

namespace Hospital.Models;
public class Consulta : Atendimento, IAtendimento<ConsultaCreationDto>
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
