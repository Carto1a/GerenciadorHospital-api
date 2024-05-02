using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

using Hospital.Dtos.Input.Medicamentos;
using Hospital.Enums;
using Hospital.Models.Cadastro;

namespace Hospital.Models.Medicamentos;
public class Medicamento
{
    [Key]
    public Guid Id { get; set; }
    public int CodigoDeBarras { get; set; }

    public required string Nome { get; set; }
    public required string Descricao { get; set; }
    public required string Composicao { get; set; }
    public required string PrincipioAtivo { get; set; }
    public decimal Preco { get; set; }
    public int QuantidadeMinima { get; set; }
    public int Quantidade { get; set; }
    public MedicamentoStatus Status { get; set; }

    public virtual ICollection<Paciente>? Pacientes { get; set; }
    public virtual ICollection<MedicamentoLote>? MedicamentoLotes { get; set; }
    public virtual ICollection<Laudo>? Laudos { get; set; }

    public DateTime Criado { get; set; }

    public Medicamento() { }
    [SetsRequiredMembers]
    public Medicamento(MedicamentoCreateDto request)
    {
        Id = Guid.NewGuid();
        CodigoDeBarras = request.CodigoDeBarras;
        Nome = request.Nome;
        Descricao = request.Descricao;
        Composicao = request.Composicao;
        PrincipioAtivo = request.PrincipioAtivo;
        Preco = request.Preco;
        QuantidadeMinima = request.QuantidadeMinima;
        Quantidade = 0;
        Status = request.Status;
        Criado = DateTime.Now;

        Validate();
    }

    public void Validate()
    {
        var validate = new Validators(
            $"Não foi possível validar o medicamento: {CodigoDeBarras}");

        validate.MinLength(Nome, 3, "Nome");
        validate.MinLength(Descricao, 3, "Descrição");
        validate.MinLength(Composicao, 3, "Composição");
        validate.MinLength(PrincipioAtivo, 3, "Princípio Ativo");
        validate.MinValue(Preco, 0, "Preço");
        validate.MinValue(QuantidadeMinima, 0, "Quantidade Mínima");
        validate.MinValue(Quantidade, 0, "Quantidade");
        validate.isInEnum(Status, "Status");

        validate.Check();
    }

    public void UpdateStatus()
    {
        if (Quantidade <= 0)
        {
            Status = MedicamentoStatus.Esgotado;
            return;
        }

        if (Quantidade < QuantidadeMinima)
        {
            Status = MedicamentoStatus.EstoqueBaixo;
            return;
        }

        Status = MedicamentoStatus.Disponivel;
    }
}