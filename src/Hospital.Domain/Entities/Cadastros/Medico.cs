using Hospital.Domain.Entities.ValueObjects;
using Hospital.Domain.Validators;

namespace Hospital.Domain.Entities.Cadastros;
public class Medico : Cadastro
{
    public Crm CRM { get; set; }
    public Guid? DocCRMPath { get; set; }
    public required string Especialidade { get; set; }

    public virtual ICollection<Consulta>? Consultas { get; set; }
    public virtual ICollection<Exame>? Exames { get; set; }
    public virtual ICollection<Retorno>? Retornos { get; set; }
    public virtual ICollection<Laudo>? Laudos { get; set; }
    public virtual ICollection<ConsultaAgendamento>? AgendamentosConsultas { get; set; }
    public virtual ICollection<ExameAgendamento>? AgendamentosExames { get; set; }
    public virtual ICollection<RetornoAgendamento>? AgendamentosRetornos { get; set; }

    public Medico(RegisterRequestMedicoDto request)
    : base(request)
    {
        CRM = request.CRM;
        Especialidade = request.Especialidade;

        Validate();
    }

    public override void Validate()
    {
        var validation = new DomainValidator(
            $"Não foi possível validar o medico de email: {Email}");

        validation.MinLength(Especialidade, 4, "Especialidade");
        validation.MaxLength(Especialidade, 50, "Especialidade");

        validation.LoadValueObjectValidations(CRM.Validations());

        validation.Check();
    }

    public override bool CheckUniqueness<TCadastro>(TCadastro cadastro)
    {
        if (cadastro is Medico medico)
        {
            return Email == medico.Email
                || CPF == medico.CPF
                || CRM == medico.CRM;
        }

        throw new ArgumentException(
            "O tipo de registro não é um médico.");
    }
}