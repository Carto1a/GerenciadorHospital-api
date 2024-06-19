namespace Hospital.Application.Dto.Input.Medicamentos;
public class MedicamentoBulkWithdrawDto
{
    public List<MedicamentoWithdrawDto> Medicamentos { get; set; } = new();
}