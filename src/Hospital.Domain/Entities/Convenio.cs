using Hospital.Domain.Entities.ValueObjects;
using Hospital.Domain.Validators;

namespace Hospital.Domain.Entities;
public class Convenio : Entity
{
    public Cnpj? CNPJ { get; set; }
    public Endereco? Endereco { get; set; }
    public Email? Email { get; set; }
    public Telefone? Telefone { get; set; }
    public string? Nome { get; set; }
    public string? Descrição { get; set; }
    public string? Site { get; set; }
    public decimal Desconto { get; set; }

    public virtual ICollection<Paciente>? Pacientes { get; set; }
    public virtual ICollection<Consulta>? Consultas { get; set; }
    public virtual ICollection<Exame>? Exames { get; set; }
    public virtual ICollection<Retorno>? Retornos { get; set; }
    public virtual ICollection<ConsultaAgendamento>? AgendamentosConsultas { get; set; }
    public virtual ICollection<ExameAgendamento>? AgendamentosExames { get; set; }
    public virtual ICollection<RetornoAgendamento>? AgendamentosRetornos { get; set; }

    public Convenio(ConvenioCreateDto request)
    {
        Validate();
    }

    private void Validate()
    {
        var validator = new DomainValidator(
            $"Não foi possível validar o convênio de nome: {Nome}");

        validator.MinLength(Nome, 3, "Nome");
        validator.MinLength(Descrição, 3, "Descrição");
        validator.MinLength(Site, 8, "Site");

        validator.Check();
    }
}