namespace Hospital.Dtos.Input.Medicamentos;
public class MedicamentoBulkWithdrawDto
{
    public List<MedicamentoWithdrawDto> Medicamentos { get; set; } = new();
}