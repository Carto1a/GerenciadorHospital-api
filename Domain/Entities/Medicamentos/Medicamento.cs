using System.Diagnostics.CodeAnalysis;

using Hospital.Application.Dto.Input.Medicamentos;
using Hospital.Domain.Entities.Cadastros;
using Hospital.Domain.Enums;
using Hospital.Domain.Validators;

namespace Hospital.Domain.Entities.Medicamentos;
public class Medicamento : Entity
{
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

    public Medicamento() { }
    [SetsRequiredMembers]
    public Medicamento(MedicamentoCreateDto request)
    {
        CodigoDeBarras = request.CodigoDeBarras;
        Nome = request.Nome;
        Descricao = request.Descricao;
        Composicao = request.Composicao;
        PrincipioAtivo = request.PrincipioAtivo;
        Preco = request.Preco;
        QuantidadeMinima = request.QuantidadeMinima;
        Quantidade = 0;
        Status = request.Status;

        Validate();
    }

    public void Validate()
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
        validate.isInEnum(
            Status,
            typeof(MedicamentoStatus),
            "Status");

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