namespace Hospital.Dtos.Output.Cadastros;
public record PacienteOutputDto
: CadastroOutputDto
{
    public Guid? ConsultaId { get; init; }
    public string? DocIDPath { get; init; }
    public string? DocConvenioPath { get; init; }

    protected PacienteOutputDto(CadastroOutputDto original)
    : base(original)
    {
    }
}