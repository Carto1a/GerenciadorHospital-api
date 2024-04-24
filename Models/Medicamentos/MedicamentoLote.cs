using System.ComponentModel.DataAnnotations;

using Hospital.Enums;

namespace Hospital.Models.Medicamentos;
public class MedicamentoLote
{
    [Key]
    public Guid Id { get; set; }
    public Guid MedicamentoId { get; set; }

    public virtual Medicamento? Medicamento { get; set; }

    public string Codigo { get; set; }
    public DateOnly DataFabricacao { get; set; }
    public DateOnly DataVencimento { get; set; }
    public DateOnly DataCadastro { get; set; }
    public string Fabricante { get; set; }
    public int Quantidade { get; set; }
    public int QuantidadeDisponivel { get; set; }
    public decimal PrecoUnitario { get; set; }
    public MedicamentoLoteStatus Status { get; set; }
}