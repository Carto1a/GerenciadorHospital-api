using Hospital.Enums;
using Hospital.Models.Cadastro;

namespace Hospital.Dtos.Output.Cadastros;
public class MedicoOutputDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Nome { get; set; }
    public DateOnly DataNascimento { get; set; }
    public GeneroEnum Genero { get; set; }
    public long? Telefone { get; set; }
    public string CPF { get; set; }
    public string CEP { get; set; }
    public string? NumeroCasa { get; set; }
    public bool Ativo { get; set; }

    public int CRM { get; init; }
    public Guid? DocCRMPath { get; init; }
    public string Especialidade { get; init; }

    public MedicoOutputDto(Medico medico)
    {
        Id = medico.Id;
        Email = medico.Email!;
        Nome = medico.Nome;
        DataNascimento = medico.DataNascimento;
        Genero = medico.Genero;
        Telefone = medico.Telefone;
        CPF = medico.CPF;
        CEP = medico.CEP;
        NumeroCasa = medico.NumeroCasa;
        Ativo = medico.Ativo;

        CRM = medico.CRM;
        DocCRMPath = medico.DocCRMPath;
        Especialidade = medico.Especialidade;
    }
}