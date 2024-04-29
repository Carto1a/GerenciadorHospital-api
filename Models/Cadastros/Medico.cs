using System.Diagnostics.CodeAnalysis;

using Hospital.Dtos.Input.Authentications;
using Hospital.Models.Agendamentos;
using Hospital.Models.Atendimento;

namespace Hospital.Models.Cadastro;
public class Medico
: Cadastro
{
    public int CRM { get; set; }
    public required string CRMUF { get; set; }
    public Guid? DocCRMPath { get; set; }
    public required string Especialidade { get; set; }

    public virtual ICollection<Consulta>? Consultas { get; set; }
    public virtual ICollection<Exame>? Exames { get; set; }
    public virtual ICollection<Retorno>? Retornos { get; set; }
    public virtual ICollection<Laudo>? Laudos { get; set; }
    public virtual ICollection<ConsultaAgendamento>? AgendamentosConsultas { get; set; }
    public virtual ICollection<ExameAgendamento>? AgendamentosExames { get; set; }
    public virtual ICollection<RetornoAgendamento>? AgendamentosRetornos { get; set; }

    public Medico() { }
    [SetsRequiredMembers]
    public Medico(
        RegisterRequestMedicoDto request)
    : base(request)
    {
        CRM = request.CRM;
        CRMUF = request.CRMUF;
        Especialidade = request.Especialidade;

        Validate();
    }

    new void Validate()
    {
        var validation = new Validators(
            $"Não foi possível validar o medico de email: {Email}");

        validation.Crm(CRM, "CRM");
        validation.CrmUf(CRMUF, "CRMUF");
        validation.MinLength(Especialidade, 4, "Especialidade");

        validation.Check();
    }
}