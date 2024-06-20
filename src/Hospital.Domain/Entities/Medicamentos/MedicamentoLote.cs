using Hospital.Domain.Enums;
using Hospital.Domain.Validators;

namespace Hospital.Domain.Entities.Medicamentos;
public class MedicamentoLote : Entity
{
    public string Codigo { get; set; }
    public DateOnly DataFabricacao { get; set; }
    public DateOnly DataVencimento { get; set; }

    public int Quantidade { get; set; }
    public int QuantidadeDisponivel { get; set; }
    public decimal PrecoUnitario { get; set; }
    public MedicamentoLoteStatus Status { get; set; }

    public MedicamentoLote(
        string codigo, DateOnly dataFabricacao, DateOnly dataVencimento,
        int quantidade, int quantidadeDisponivel, decimal precoUnitario)
    {
        Codigo = codigo;
        DataFabricacao = dataFabricacao;
        DataVencimento = dataVencimento;
        Quantidade = quantidade;
        QuantidadeDisponivel = quantidadeDisponivel;
        PrecoUnitario = precoUnitario;

        UpdateStatus();

        Validate();
    }

    public override void Validate()
    {
        var validate = new DomainValidator(
            $"Não foi possível validar o lote de medicamento: {Codigo}");

        // NOTE: ainda não sei validar as coisas do medicamento
        validate.MinLength(Codigo, 3, "Código");
        validate.MinValue(Quantidade, 0, "Quantidade");
        validate.MinValue(QuantidadeDisponivel, 0, "Quantidade Disponível");
        validate.MinValue(QuantidadeDisponivel, Quantidade, "Quantidade Disponível");
        validate.MinValue(PrecoUnitario, 0, "Preço Unitário");
        validate.MinDate(
            DataFabricacao.ToDateTime(TimeOnly.MinValue),
            DateTime.Parse("1950-01-01"), "Data de Fabricação");
        validate.MaxDate(
            DataFabricacao.ToDateTime(TimeOnly.MaxValue),
            DateTime.Now.AddDays(1), "Data de Fabricação");
        validate.MinDate(
            DataVencimento.ToDateTime(TimeOnly.MinValue),
            DateTime.Parse("1950-01-01"), "Data de Vencimento");

        validate.Check();
    }

    public void UpdateStatus()
    {
        if (QuantidadeDisponivel <= 0)
        {
            Status = MedicamentoLoteStatus.Esgotado;
            return;
        }

        if (DataVencimento < DateOnly.FromDateTime(DateTime.Now))
        {
            Status = MedicamentoLoteStatus.Vencido;
            return;
        }

        Status = MedicamentoLoteStatus.Disponivel;
    }
}