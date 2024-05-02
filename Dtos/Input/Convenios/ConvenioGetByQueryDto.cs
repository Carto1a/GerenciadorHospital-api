namespace Hospital.Dtos.Input.Convenios;
public class ConvenioGetByQueryDto
{
    public string? CNPJ { get; set; }
    public string? Nome { get; set; }
    public bool? Ativo { get; set; }
    /* public bool? PessoasCadastradas { get; set; } = false; */
    /* public bool? ListaPessoasCadastradas { get; set; } = false; */
    public int? Limit { get; set; } = 1;
    public int? Page { get; set; } = 0;
}