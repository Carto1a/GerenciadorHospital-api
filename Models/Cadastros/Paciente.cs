using System.Diagnostics.CodeAnalysis;

using FluentResults;

using Hospital.Dtos.Input.Authentications;
using Hospital.Models.Agendamentos;
using Hospital.Models.Atendimento;
using Hospital.Models.Medicamentos;

namespace Hospital.Models.Cadastro;
public class Paciente
: Cadastro
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
}