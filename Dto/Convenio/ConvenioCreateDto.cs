namespace Hospital.Dto.Convenios;
public class ConvenioCreateDto
{
    public string CNPJ { get; set; }
    public string? CEP { get; set; }
    public string? Numero { get; set; }
    public string? Nome { get; set; }
    public string? Descrição { get; set; }
    public decimal Desconto { get; set; }
    public string? Telefone { get; set; }
    public string? Email { get; set; }
    public string? Site { get; set; }
}