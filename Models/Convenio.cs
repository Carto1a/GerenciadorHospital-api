using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

using Hospital.Dtos.Input.Convenios;
using Hospital.Models.Agendamentos;
using Hospital.Models.Atendimento;

namespace Hospital.Models.Cadastro;
public class Convenio
{
    [Key]
    public Guid Id { get; set; }
    public required string CNPJ { get; set; }
    public string? CEP { get; set; }
    public string? Numero { get; set; }
    public string? Nome { get; set; }
    public string? Descrição { get; set; }
    public decimal Desconto { get; set; }
    public string? Telefone { get; set; }
    public string? Email { get; set; }
    public string? Site { get; set; }
    public DateTime Criado { get; set; }
    public bool Deletado { get; set; }
    public virtual ICollection<Paciente>? Pacientes { get; set; }
    public virtual ICollection<Consulta>? Consultas { get; set; }
    public virtual ICollection<Exame>? Exames { get; set; }
    public virtual ICollection<Retorno>? Retornos { get; set; }
    public virtual ICollection<ConsultaAgendamento>? AgendamentosConsultas { get; set; }
    public virtual ICollection<ExameAgendamento>? AgendamentosExames { get; set; }
    public virtual ICollection<RetornoAgendamento>? AgendamentosRetornos { get; set; }

    public void Deletar() => Deletado = true;

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
        Deletado = false;

        Validate();
    }

    private void Validate()
    {
        var validator = new Validators(
            $"Não foi possível validar o convênio de nome: {Nome}");

        /* validator.Cnpj(CNPJ, "CNPJ"); */
        /* validator.MinLength(Nome, 3, "Nome"); */
        /* validator.MinLength(Descrição, 3, "Descrição"); */
        /* validator.MinLength(Telefone, 8, "Telefone"); */
        /* validator.MinLength(Email, 8, "Email"); */
        /* validator.MinLength(Site, 8, "Site"); */

        validator.Check();
    }
}