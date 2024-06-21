using Hospital.Domain.Enums;
using Hospital.Domain.Validators;

namespace Hospital.Domain.Entities.Medicamentos;
public class MedicamentoEstoque : Entity
{
    public int CodigoDeBarras { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string Composicao { get; set; }
    public string PrincipioAtivo { get; set; }
    public string Fabricante { get; set; }
    public decimal Preco { get; set; }
    public int QuantidadeMinima { get; set; }
    public int Quantidade { get; set; }
    public MedicamentoStatus Status { get; set; }

    public ICollection<MedicamentoLote>? MedicamentoLotes { get; set; }

    public MedicamentoEstoque(
        int codigoDeBarras, string nome, string descricao,
        string composicao, string principioAtivo, string fabricante,
        decimal preco, int quantidadeMinima, MedicamentoStatus status = MedicamentoStatus.Esgotado,
        int quantidade = 0)
    {
        CodigoDeBarras = codigoDeBarras;
        Nome = nome;
        Descricao = descricao;
        Composicao = composicao;
        PrincipioAtivo = principioAtivo;
        Fabricante = fabricante;
        Preco = preco;
        QuantidadeMinima = quantidadeMinima;
        Status = status;
        Quantidade = quantidade;

        UpdateStatus();

        Validate();
    }

    public void AddLote(string codigo, DateOnly dataFabricacao,
        DateOnly dataVencimento, int quantidade, int quantidadeDisponivel,
        decimal precoUnitario)
    {
        var lote = new MedicamentoLote(
            codigo, dataFabricacao, dataVencimento,
            quantidade, quantidadeDisponivel, precoUnitario);

        if (MedicamentoLotes == null)
            MedicamentoLotes = new List<MedicamentoLote>();

        MedicamentoLotes.Add(lote);
    }

    public override void Validate()
    {
        var validate = new DomainValidator(
            $"Não foi possível validar o medicamento: {CodigoDeBarras}");

        validate.MinLength(Nome, 3, "Nome");
        validate.MinLength(Descricao, 3, "Descrição");
        validate.MinLength(Composicao, 3, "Composição");
        validate.MinLength(PrincipioAtivo, 3, "Princípio Ativo");
        validate.MinValue(Preco, 0, "Preço");
        validate.MinValue(QuantidadeMinima, 0, "Quantidade Mínima");
        validate.MinValue(Quantidade, 0, "Quantidade");
        validate.isInEnum(Status, typeof(MedicamentoStatus), "Status");

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