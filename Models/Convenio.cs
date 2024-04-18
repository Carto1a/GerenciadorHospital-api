using System.ComponentModel.DataAnnotations;

using Hospital.Dto.Convenios;

namespace Hospital.Models.Cadastro;
public class Convenio
{
    [Key]
    public Guid Id { get; set; }
    public string? CNPJ { get; set; }
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
    public virtual ICollection<Paciente> Pacientes { get; set; }

    public void Deletar() => Deletado = true;

    public void Create(ConvenioCreateDto request)
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
    }
}