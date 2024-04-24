using System.ComponentModel.DataAnnotations;

using Hospital.Enums;
using Hospital.Models.Cadastro;

namespace Hospital.Models.Medicamentos;
public class Medicamento
{
    [Key]
    public Guid Id { get; set; }
    public int CodigoDeBarras { get; set; }

    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string Composicao { get; set; }
    public string PrincipioAtivo { get; set; }
    public decimal Preco { get; set; }
    public int QuantidadeMinima { get; set; }
    public int Quantidade { get; set; }
    public MedicamentoStatus Status { get; set; }

    public virtual ICollection<Paciente>? Pacientes { get; set; }
    public virtual ICollection<MedicamentoLote>? MedicamentoLotes { get; set; }
    public virtual ICollection<Laudo>? Laudos { get; set; }

    public DateOnly Criado { get; set; }
}