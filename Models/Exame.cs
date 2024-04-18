using Hospital.Dto.Atividades;
using Hospital.Models.Generics.Interfaces;

namespace Hospital.Models;
public class Exame : Atendimento, IAtendimento<ExameCreationDto>
{
    // tipo de exame
    public string Resultado { get; set; }

    public void Creation(
        ExameCreationDto request,
        Medico medico,
        Paciente paciente)
    {
        base.Creation(request, medico, paciente);
        Resultado = request.Resultado;
    }
}
