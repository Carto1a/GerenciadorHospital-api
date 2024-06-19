using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

using Hospital.Application.Dto.Input.Convenios;
using Hospital.Domain.Entities.Agendamentos;
using Hospital.Domain.Entities.Atendimentos;
using Hospital.Domain.Entities.Cadastros;
using Hospital.Domain.Validators;

namespace Hospital.Domain.Entities;
public class Convenio : Entity
{
    public required string CNPJ { get; set; }
    public string? CEP { get; set; }
    public string? Numero { get; set; }
    public string? Nome { get; set; }
    public string? Descrição { get; set; }
    public decimal Desconto { get; set; }
    public string? Telefone { get; set; }
    public string? Email { get; set; }
    public string? Site { get; set; }

    public virtual ICollection<Paciente>? Pacientes { get; set; }
    public virtual ICollection<Consulta>? Consultas { get; set; }
    public virtual ICollection<Exame>? Exames { get; set; }
    public virtual ICollection<Retorno>? Retornos { get; set; }
    public virtual ICollection<ConsultaAgendamento>? AgendamentosConsultas { get; set; }
    public virtual ICollection<ExameAgendamento>? AgendamentosExames { get; set; }
    public virtual ICollection<RetornoAgendamento>? AgendamentosRetornos { get; set; }

    public Convenio() { }
    [SetsRequiredMembers]
    public Convenio(ConvenioCreateDto request)
    {
        CNPJ = request.CNPJ;
        CEP = request.CEP;
        Numero = request.Numero;
        Nome = request.Nome;
        Descrição = request.Descrição;
        Desconto = request.Desconto;
        Telefone = request.Telefone;
        Email = request.Email;
        Site = request.Site;
        Criado = DateTime.Now;

        Validate();
    }

    private void Validate()
    {
        var validator = new DomainValidator(
            $"Não foi possível validar o convênio de nome: {Nome}");

        validator.Cnpj(CNPJ, "CNPJ");
        validator.MinLength(Nome, 3, "Nome");
        validator.MinLength(Descrição, 3, "Descrição");
        validator.MinLength(Telefone, 8, "Telefone");
        validator.MinLength(Email, 8, "Email");
        validator.MinLength(Site, 8, "Site");

        validator.Check();
    }
}