using Hospital.Dto.Atividades;
using Hospital.Models.Generics.Interfaces;

namespace Hospital.Models;
public class Retorno : Atendimento, IAtendimento<RetornoCreationDto>
{
    public Consulta Consulta { get; set; }
    public string Observacoes { get; set; }
    public void Creation(
        RetornoCreationDto request,
        Medico medico,
        Paciente paciente)
    {
        base.Creation(request, medico, paciente);
        Observacoes = request.Observacoes;
    }
}
