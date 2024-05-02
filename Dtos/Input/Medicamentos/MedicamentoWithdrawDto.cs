namespace Hospital.Dtos.Input.Medicamentos;
public class MedicamentoWithdrawDto
{
    public required string CodigoLote { get; set; }
    public int Quantidade { get; set; }
}