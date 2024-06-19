namespace Hospital.Application.Dto.Input.Convenios;
public record ConvenioGetByQueryDto : GetByQueryDto
{
    public string? CNPJ { get; set; }
    public string? Nome { get; set; }
    /* public bool? PessoasCadastradas { get; set; } = false; */
    /* public bool? ListaPessoasCadastradas { get; set; } = false; */
}