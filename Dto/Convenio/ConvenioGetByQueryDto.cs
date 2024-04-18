namespace Hospital.Dto.Convenios;
public class ConvenioGetByQueryDto
{
    public string? CNPJ { get; set; }
    public bool? PessoasCadastradas { get; set; } = false;
    public bool? ListaPessoasCadastradas { get; set; } = false;
    public int? limit { get; set; } = 1;
    public int? page { get; set; } = 0;
    /* public string? Nome { get; set; } */
}