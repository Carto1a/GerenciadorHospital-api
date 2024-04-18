using Hospital.Dto.Atendimento.Create;
using Hospital.Models.Atendimento.Interfaces;
using Hospital.Models.Cadastro;

namespace Hospital.Models.Atendimento;
public class Exame
: Atendimento, IAtendimento<ExameCreationDto>
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
