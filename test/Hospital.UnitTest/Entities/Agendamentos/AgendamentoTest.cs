using Bogus;
using Bogus.Extensions.Brazil;

using Hospital.Domain.Entities;
using Hospital.Domain.Entities.Cadastros;
using Hospital.Domain.Entities.ValueObjects;

namespace Hospital.UnitTest.Entities.Agendamentos;
public class AgendmaentoTest
{
    /* [Fact] */
    /* public void QuandoConvenioNaoForOMesmoDoPaciente_LancarDomainException() */
    /* { */
    /*     var desconto = 0.1m; */
    /*     var convenio = new Faker<Convenio>() */
    /*         .RuleFor(c => c.Desconto, f => desconto); */

    /*     var paciente = new Faker<Paciente>(); */

    /*     var agendamento = new C */
    /* } */

    [Fact]
    public void QuandoAtrasadoComConvenio_CalcularMulta()
    {
        var custo = 100;
        var desconto = 0.1m;
        var custoFinal = custo * desconto;
        var custoAtraso = custoFinal * 1.01m;
        var convenio = new Faker<Convenio>()
            .RuleFor(c => c.Desconto, f => desconto)
            .Generate();

        var agendamento = new Faker<AgendamentoClassTest>()
            .RuleFor(a => a.Custo, f => custo)
            .RuleFor(a => a.CustoFinal, f => custoFinal)
            .RuleFor(a => a.Convenio, f => convenio)
            .Generate();

        var multa = agendamento.CalcularMultaAtraso();

        Assert.Equal(custoAtraso, multa);
    }

    [Fact]
    public void QuandoAtrasadoSemConvenio_CalcularMulta()
    {
        var custo = 100;
        var custoAtraso = custo * 1.05m;
        var agendamento = new Faker<AgendamentoClassTest>()
            .RuleFor(a => a.Custo, f => custo)
            .RuleFor(a => a.CustoFinal, f => custo)
            .RuleFor(a => a.Convenio, f => null)
            .Generate();

        var multa = agendamento.CalcularMultaAtraso();

        Assert.Equal(custoAtraso, multa);
    }

    [Fact]
    public void QuandoNaoAtrasado_NaoCalcularMulta()
    {

    }
}