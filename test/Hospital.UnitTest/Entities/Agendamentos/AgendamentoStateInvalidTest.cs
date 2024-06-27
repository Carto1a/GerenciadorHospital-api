using Bogus;

using Hospital.Domain.Entities.Agendamentos;
using Hospital.Domain.Entities.Agendamentos.Status;
using Hospital.Domain.Entities.Atendimentos;
using Hospital.Domain.Enums;
using Hospital.Domain.Exceptions;

namespace Hospital.UnitTest.Entities.Agendamentos;
public class AgendamentoStateInvalidTest
{
    [Fact]
    public void QuandoEmEsperaNaoPodeSerCancelado()
    {
        var agendamento = new Faker<AgendamentoClassTest>()
            .RuleFor(a => a.Status, f => AgendamentoStatusEnum.EmEspera)
            .RuleFor(a => a.State, f => new AgendamentoEmEspera())
            .Generate();

        var message = "O agendamento não pode ser cancelado.";

        var exception = Assert.Throws<DomainException>(() =>
        {
            agendamento.Cancelar();
        });

        Assert.Equal(message, exception.Message);
    }

    [Fact]
    public void QuandoEmAndamentoNaoPodeSerCancelado()
    {
        var agendamento = new Faker<AgendamentoClassTest>()
            .RuleFor(a => a.Status, f => AgendamentoStatusEnum.EmAndamento)
            .RuleFor(a => a.State, f => new AgendamentoEmAndamento())
            .Generate();

        var message = "O agendamento não pode ser cancelado.";

        var exception = Assert.Throws<DomainException>(() =>
        {
            agendamento.Cancelar();
        });

        Assert.Equal(message, exception.Message);
    }

    [Fact]
    public void QuandoEmAndamentoNaoPodeSerEmEspera()
    {
        var agendamento = new Faker<AgendamentoClassTest>()
            .RuleFor(a => a.Status, f => AgendamentoStatusEnum.EmAndamento)
            .RuleFor(a => a.State, f => new AgendamentoEmAndamento())
            .Generate();

        var message = "O agendamento não pode ser colocado em espera.";

        var exception = Assert.Throws<DomainException>(() =>
        {
            agendamento.EmEspera();
        });

        Assert.Equal(message, exception.Message);
    }

    [Fact]
    public void QuandoRealizadoNaoPodeSerEmEspera()
    {
        var agendamento = new Faker<AgendamentoClassTest>()
            .RuleFor(a => a.Status, f => AgendamentoStatusEnum.Realizado)
            .RuleFor(a => a.State, f => new AgendamentoRealizado())
            .Generate();

        var message = "O agendamento não pode ser colocado em espera.";

        var exception = Assert.Throws<DomainException>(() =>
        {
            agendamento.EmEspera();
        });

        Assert.Equal(message, exception.Message);
    }

    [Fact]
    public void QuandoRealizadoNaoPodeSerEmAndamento()
    {
        var agendamento = new Faker<AgendamentoClassTest>()
            .RuleFor(a => a.Status, f => AgendamentoStatusEnum.Realizado)
            .RuleFor(a => a.State, f => new AgendamentoRealizado())
            .Generate();

        var message = "O agendamento não pode ser colocado em andamento.";

        var exception = Assert.Throws<DomainException>(() =>
        {
            agendamento.EmAndamento();
        });

        Assert.Equal(message, exception.Message);
    }

    [Fact]
    public void QuandoRealizadoNaoPodeSerAusente()
    {
        var agendamento = new Faker<AgendamentoClassTest>()
            .RuleFor(a => a.Status, f => AgendamentoStatusEnum.Realizado)
            .RuleFor(a => a.State, f => new AgendamentoRealizado())
            .Generate();

        var message = "O agendamento não pode ser colocado como ausente.";

        var exception = Assert.Throws<DomainException>(() =>
        {
            agendamento.Ausencia();
        });

        Assert.Equal(message, exception.Message);
    }

    [Fact]
    public void QuandoRealizadoNaoPodeSerCancelado()
    {
        var agendamento = new Faker<AgendamentoClassTest>()
            .RuleFor(a => a.Status, f => AgendamentoStatusEnum.Realizado)
            .RuleFor(a => a.State, f => new AgendamentoRealizado())
            .Generate();

        var message = "O agendamento não pode ser cancelado.";

        var exception = Assert.Throws<DomainException>(() =>
        {
            agendamento.Cancelar();
        });

        Assert.Equal(message, exception.Message);
    }

    [Fact]
    public void QuandoRealizadoNaoPodeSerRealizado()
    {
        var agendamento = new Faker<AgendamentoClassTest>()
            .RuleFor(a => a.Status, f => AgendamentoStatusEnum.Realizado)
            .RuleFor(a => a.State, f => new AgendamentoRealizado())
            .Generate();

        var message = "O agendamento não pode ser realizado.";

        var exception = Assert.Throws<DomainException>(() =>
        {
            agendamento.Realizar(new Consulta());
        });

        Assert.Equal(message, exception.Message);
    }

    [Fact]
    public void QuandoAusenteNaoPodeSerAusente()
    {
        var agendamento = new Faker<AgendamentoClassTest>()
            .RuleFor(a => a.Status, f => AgendamentoStatusEnum.Ausencia)
            .RuleFor(a => a.State, f => new AgendamentoAusente())
            .Generate();

        var message = "O agendamento não pode ser colocado como ausente.";

        var exception = Assert.Throws<DomainException>(() =>
        {
            agendamento.Ausencia();
        });

        Assert.Equal(message, exception.Message);
    }

    [Fact]
    public void QuandoAusenteNaoPodeSerCacelado()
    {
        var agendamento = new Faker<AgendamentoClassTest>()
            .RuleFor(a => a.Status, f => AgendamentoStatusEnum.Ausencia)
            .RuleFor(a => a.State, f => new AgendamentoAusente())
            .Generate();

        var message = "O agendamento não pode ser cancelado.";

        var exception = Assert.Throws<DomainException>(() =>
        {
            agendamento.Cancelar();
        });

        Assert.Equal(message, exception.Message);
    }

    [Fact]
    public void QuandoAusenteNaoPodeSerEmEspera()
    {
        var agendamento = new Faker<AgendamentoClassTest>()
            .RuleFor(a => a.Status, f => AgendamentoStatusEnum.Ausencia)
            .RuleFor(a => a.State, f => new AgendamentoAusente())
            .Generate();

        var message = "O agendamento não pode ser colocado em espera.";

        var exception = Assert.Throws<DomainException>(() =>
        {
            agendamento.EmEspera();
        });

        Assert.Equal(message, exception.Message);
    }

    [Fact]
    public void QuandoAusenteNaoPodeSerEmAndamento()
    {
        var agendamento = new Faker<AgendamentoClassTest>()
            .RuleFor(a => a.Status, f => AgendamentoStatusEnum.Ausencia)
            .RuleFor(a => a.State, f => new AgendamentoAusente())
            .Generate();

        var message = "O agendamento não pode ser colocado em andamento.";

        var exception = Assert.Throws<DomainException>(() =>
        {
            agendamento.EmAndamento();
        });

        Assert.Equal(message, exception.Message);
    }

    [Fact]
    public void QuandoCanceladoNaoPodeSerCancelado()
    {
        var agendamento = new Faker<AgendamentoClassTest>()
            .RuleFor(a => a.Status, f => AgendamentoStatusEnum.Cancelado)
            .RuleFor(a => a.State, f => new AgendamentoCancelado())
            .Generate();

        var message = "O agendamento não pode ser cancelado.";

        var exception = Assert.Throws<DomainException>(() =>
        {
            agendamento.Cancelar();
        });

        Assert.Equal(message, exception.Message);
    }

    [Fact]
    public void QuandoCanceladoNaoPodeSerEmEspera()
    {
        var agendamento = new Faker<AgendamentoClassTest>()
            .RuleFor(a => a.Status, f => AgendamentoStatusEnum.Cancelado)
            .RuleFor(a => a.State, f => new AgendamentoCancelado())
            .Generate();

        var message = "O agendamento não pode ser colocado em espera.";

        var exception = Assert.Throws<DomainException>(() =>
        {
            agendamento.EmEspera();
        });

        Assert.Equal(message, exception.Message);
    }

    [Fact]
    public void QuandoCanceladoNaoPodeSerEmAndamento()
    {
        var agendamento = new Faker<AgendamentoClassTest>()
            .RuleFor(a => a.Status, f => AgendamentoStatusEnum.Cancelado)
            .RuleFor(a => a.State, f => new AgendamentoCancelado())
            .Generate();

        var message = "O agendamento não pode ser colocado em andamento.";

        var exception = Assert.Throws<DomainException>(() =>
        {
            agendamento.EmAndamento();
        });

        Assert.Equal(message, exception.Message);
    }

    [Fact]
    public void QuandoCanceladoNaoPodeSerAusente()
    {
        var agendamento = new Faker<AgendamentoClassTest>()
            .RuleFor(a => a.Status, f => AgendamentoStatusEnum.Cancelado)
            .RuleFor(a => a.State, f => new AgendamentoCancelado())
            .Generate();

        var message = "O agendamento não pode ser colocado como ausente.";

        var exception = Assert.Throws<DomainException>(() =>
        {
            agendamento.Ausencia();
        });

        Assert.Equal(message, exception.Message);
    }
}