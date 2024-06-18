using Hospital.Domain.Entities.Cadastros;
using Hospital.Domain.Enums;

namespace Hospital.Application.Dto.Output.Cadastros;
public class PacienteOutputDto
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

    public Guid? ConvenioId { get; init; }
    public Guid? DocIDPath { get; init; }
    public Guid? DocConvenioPath { get; init; }

    public PacienteOutputDto(Paciente paciente)
    {
        Id = paciente.Id;
        Email = paciente.Email!;
        Nome = paciente.Nome;
        DataNascimento = paciente.DataNascimento;
        Genero = paciente.Genero;
        Telefone = paciente.Telefone;
        CPF = paciente.CPF;
        CEP = paciente.CEP;
        NumeroCasa = paciente.NumeroCasa;
        Ativo = paciente.Ativo;

        ConvenioId = paciente.ConvenioId;
        DocIDPath = paciente.DocIDPath;
        DocConvenioPath = paciente.DocConvenioPath;
    }
}