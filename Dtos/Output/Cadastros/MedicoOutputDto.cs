namespace Hospital.Dtos.Output.Cadastros;
public record MedicoOutputDto
: CadastroOutputDto
{
    public string CRM { get; init; }
    public string? DocCRMPath { get; init; }
    public string Especialidade { get; init; }
    public bool Ativo { get; init; }

    protected MedicoOutputDto(CadastroOutputDto original)
    : base(original)
    { }
}