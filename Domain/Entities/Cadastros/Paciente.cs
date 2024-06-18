using System.Diagnostics.CodeAnalysis;

using Hospital.Application.Dto.Input.Authentications;
using Hospital.Domain.Entities.Agendamentos;
using Hospital.Domain.Entities.Atendimentos;
using Hospital.Domain.Entities.Medicamentos;

namespace Hospital.Domain.Entities.Cadastros;
public class Paciente : Cadastro
{
    public Guid? ConvenioId { get; set; }

    public virtual Convenio? Convenio { get; set; }
    public virtual ICollection<Consulta>? Consultas { get; set; }
    public virtual ICollection<Exame>? Exames { get; set; }
    public virtual ICollection<Retorno>? Retornos { get; set; }
    public virtual ICollection<Laudo>? Laudos { get; set; }
    public virtual ICollection<Medicamento>? Medicamentos { get; set; }
    public virtual ICollection<ConsultaAgendamento>? AgendamentosConsultas { get; set; }
    public virtual ICollection<ExameAgendamento>? AgendamentosExames { get; set; }
    public virtual ICollection<RetornoAgendamento>? AgendamentosRetornos { get; set; }

    public Guid? DocConvenioPath { get; set; }
    public Guid? DocIDPath { get; set; }

    public Paciente() { }
    [SetsRequiredMembers]
    public Paciente(RegisterRequestPacienteDto request)
    : base(request)
    {
        ConvenioId = request.ConvenioId;
    }

    protected override bool Equals<TRegister>(TRegister request)
    {
        if (request is RegisterRequestPacienteDto requestPaciente)
        {
            return Email == request.Email
                || CPF == request.CPF;
        }

        throw new ArgumentException(
            "O tipo de registro não é um paciente.");
    }
}