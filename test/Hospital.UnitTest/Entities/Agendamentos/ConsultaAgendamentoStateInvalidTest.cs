using Bogus;
using Hospital.Domain.Entities.Agendamentos;
using Hospital.Domain.Entities.Agendamentos.Status;
using Hospital.Domain.Entities.Atendimentos;
using Hospital.Domain.Enums;
using Hospital.Domain.Exceptions;

namespace Hospital.UnitTest.Entities.Agendamentos;
public class ConsultaAgendamentoStateInvalidTest
{
    [Fact]
    public void QuandoRealizadoNaoPodeSerRealizado()
    {
        var agendamento = new Faker<ConsultaAgendamento>()
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

    [Theory]
    [InlineData(typeof(Exame))]
    [InlineData(typeof(Retorno))]
    public void QuandoTipoInvalidoDeAtendimento_LancarDomainException(
        Type tipoAtendimento)
    {
        var agendamento = new Faker<ConsultaAgendamento>()
            .RuleFor(a => a.Status, f => AgendamentoStatusEnum.EmAndamento)
            .RuleFor(a => a.State, f => new AgendamentoEmAndamento())
            .Generate();

        var message = "O atendimento não é uma consulta.";

        var exception = Assert.Throws<DomainException>(() =>
        {
            agendamento.Realizar(Activator.CreateInstance(tipoAtendimento) as Atendimento);
        });

        Assert.Equal(message, exception.Message);
    }
}