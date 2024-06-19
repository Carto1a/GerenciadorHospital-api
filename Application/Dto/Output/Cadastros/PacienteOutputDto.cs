using Hospital.Domain.Entities.Cadastros;

namespace Hospital.Application.Dto.Output.Cadastros;
public class PacienteOutputDto : CadastroOutputDto
{
    public Guid? ConvenioId { get; init; }
    public Guid? DocIDPath { get; init; }
    public Guid? DocConvenioPath { get; init; }

    public PacienteOutputDto(Paciente paciente) : base(paciente)
    {
        ConvenioId = paciente.ConvenioId;
        DocIDPath = paciente.DocIDPath;
        DocConvenioPath = paciente.DocConvenioPath;
    }

    public PacienteOutputDto() { }

    public override PacienteOutputDto Create<T>(T cadastro)
    {
        return new PacienteOutputDto(cadastro as Paciente);
    }
}