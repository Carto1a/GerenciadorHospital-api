using Hospital.Dtos.Input.Atendimentos;
using Hospital.Enums;
using Hospital.Exceptions;
using Hospital.Models.Atendimento;
using Hospital.Models.Cadastro;
using Hospital.Repository;

namespace Hospital.Services.Atendimentos.Consultas;
public class ConsultaCreateService
{
    private readonly UnitOfWork _uow;
    public ConsultaCreateService(
        UnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Guid> Handler(
        ConsultaCreateDto request)
    {
        var atendimento = new Consulta(request);

        var repo = _uow.ConsultaRepository;
        var agendamentoRepo = _uow.ConsultaAgendamentoRepository;
        var findAgendamento = await _uow.ConsultaAgendamentoRepository
            .GetByIdAsync(request.AgendamentoId);
        if (findAgendamento == null)
            throw new RequestError(
                "Agendamento não encontrado",
                "Agendamento não encontrado");

        if (findAgendamento.Deletado)
            throw new RequestError(
                "Agendamento deletado",
                "Agendamento deletado");

        // juntando todos os status que não são permitidos
        // agrupando eles com a operação de bitwise OR
        // Ex: 1000 | 0010 | 0100 = 1110
        var wrongStatus =
            AgendamentoStatus.Ausencia
            | AgendamentoStatus.Realizado
            | AgendamentoStatus.Cancelado
            | AgendamentoStatus.EmAndamento;

        // se o status do agendamento tiver algum status não permitido
        // ele vai lançar uma exceção
        // Ex: 1010 & 0010 = 0010
        if (wrongStatus.HasFlag(findAgendamento.Status))
            throw new RequestError(
                $"Agendamento {(findAgendamento.Status).ToString()} não permitido");

        Convenio? findConvenio = null;
        if (findAgendamento.ConvenioId != null)
        {
            findConvenio = _uow.ConvenioRepository
                .GetConvenioById((Guid)findAgendamento.ConvenioId);
        }

        var findMedico = _uow.MedicoRepository
            .GetMedicoById(request.MedicoId);
        if (findMedico == null)
            throw new RequestError(
                $"Médico não encontrado: {request.MedicoId}",
                "Médico não encontrado");

        var findPaciente = _uow.PacienteRepository
            .GetPacienteById((Guid)findAgendamento.PacienteId!);
        if (findPaciente == null)
            throw new RequestError(
                $"Paciente não encontrado: {findAgendamento.PacienteId}",
                "Paciente não encontrado");

        atendimento.Custo = findAgendamento.Custo;
        atendimento.CustoFinal = findAgendamento.CustoFinal;
        atendimento.PacienteId = findPaciente.Id;
        atendimento.ConvenioId = findConvenio?.Id;

        findAgendamento.Status = AgendamentoStatus.Realizado;

        var guid = await repo.CreateAsync(atendimento);
        agendamentoRepo.Update(findAgendamento);
        await _uow.Save();

        return guid;
    }
}