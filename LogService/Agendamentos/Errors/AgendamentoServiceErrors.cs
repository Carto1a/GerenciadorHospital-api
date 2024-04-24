namespace Hospital.Logs.Agendamentos.Errors;
public class AgendamentoServiceErrors
{
    public static string ConstructError(
        AgendamentoServiceEnumErrors error,
        string type,
        string adicional = "")
    {
        return $"[{type}] {GetAgendamentoError(error)}: {adicional}";
    }
    public static string GetAgendamentoError(
        AgendamentoServiceEnumErrors error)
    {
        return error switch
        {
            AgendamentoServiceEnumErrors.EAGDS000 =>
                $"{nameof(AgendamentoServiceEnumErrors.EAGDS000)}:"
                + "Erro ao criar agendamento",

            AgendamentoServiceEnumErrors.EAGDS001 =>
                $"{nameof(AgendamentoServiceEnumErrors.EAGDS001)}:"
                + "Erro ao atualizar agendamento",

            AgendamentoServiceEnumErrors.EAGDS002 =>
                $"{nameof(AgendamentoServiceEnumErrors.EAGDS002)}:"
                + "Erro ao deletar agendamento",

            AgendamentoServiceEnumErrors.EAGDS003 =>
                $"{nameof(AgendamentoServiceEnumErrors.EAGDS003)}:"
                + "Erro ao encontrar agendamento",

            AgendamentoServiceEnumErrors.EAGDS004 =>
                $"{nameof(AgendamentoServiceEnumErrors.EAGDS004)}:"
                + "Erro ao listar agendamentos",

            AgendamentoServiceEnumErrors.EAGDS005 =>
                $"{nameof(AgendamentoServiceEnumErrors.EAGDS005)}:"
                + "Erro ao listar agendamentos",

            AgendamentoServiceEnumErrors.EAGDS006 =>
                $"{nameof(AgendamentoServiceEnumErrors.EAGDS006)}:"
                + "Erro ao listar agendamentos",

            AgendamentoServiceEnumErrors.EAGDS007 =>
                $"{nameof(AgendamentoServiceEnumErrors.EAGDS007)}:"
                + "Erro ao listar agendamentos",

            AgendamentoServiceEnumErrors.EAGDS008 =>
                $"{nameof(AgendamentoServiceEnumErrors.EAGDS008)}:"
                + "Erro ao listar agendamentos",

            _ => String.Empty
        };
    }
}