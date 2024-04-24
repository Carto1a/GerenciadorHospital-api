namespace Hospital.Logs.Agendamentos.Success;
public static class AgendamentoServiceServiceSuccess
{
    public static string ConstructSuccess(
        AgendamentoServiceEnumSucess success,
        string type,
        string adicional = "")
    {
        return $"[{type}] {GetSuccessMessage(success)}: {adicional}";
    }
    public static string GetSuccessMessage(
        AgendamentoServiceEnumSucess success)
    {
        return success switch
        {
            AgendamentoServiceEnumSucess.SAGDS000 =>
                $@"{nameof(AgendamentoServiceEnumSucess.SAGDS001)}:"
                + "AgendamentoService criado com sucesso",

            AgendamentoServiceEnumSucess.SAGDS001 =>
                $@"{nameof(AgendamentoServiceEnumSucess.SAGDS001)}:"
                + "AgendamentoService atualizado com sucesso",

            AgendamentoServiceEnumSucess.SAGDS002 =>
                $@"{nameof(AgendamentoServiceEnumSucess.SAGDS002)}:"
                + "AgendamentoService deletado com sucesso",

            AgendamentoServiceEnumSucess.SAGDS003 =>
                $@"{nameof(AgendamentoServiceEnumSucess.SAGDS003)}:"
                + "AgendamentoService encontrado com sucesso",

            AgendamentoServiceEnumSucess.SAGDS004 =>
                $@"{nameof(AgendamentoServiceEnumSucess.SAGDS004)}:"
                + "AgendamentoService listados com sucesso",

            AgendamentoServiceEnumSucess.SAGDS005 =>
                $@"{nameof(AgendamentoServiceEnumSucess.SAGDS005)}:"
                + "AgendamentoService listados com sucesso",

            AgendamentoServiceEnumSucess.SAGDS006 =>
                $@"{nameof(AgendamentoServiceEnumSucess.SAGDS006)}:"
                + "AgendamentoService listados com sucesso",

            AgendamentoServiceEnumSucess.SAGDS007 =>
                $@"{nameof(AgendamentoServiceEnumSucess.SAGDS007)}:"
                + "AgendamentoService listados com sucesso",

            AgendamentoServiceEnumSucess.SAGDS008 =>
                $@"{nameof(AgendamentoServiceEnumSucess.SAGDS008)}:"
                + "AgendamentoService listados com sucesso",

            AgendamentoServiceEnumSucess.SAGDS009 =>
                $@"{nameof(AgendamentoServiceEnumSucess.SAGDS009)}:"
                + "AgendamentoService listados com sucesso",

            AgendamentoServiceEnumSucess.SAGDS010 =>
                $@"{nameof(AgendamentoServiceEnumSucess.SAGDS010)}:"
                + "AgendamentoService por query listados com sucesso",

            AgendamentoServiceEnumSucess.SAGDS011 =>
                $@"{nameof(AgendamentoServiceEnumSucess.SAGDS011)}:"
                + "AgendamentoService listados com sucesso",

            AgendamentoServiceEnumSucess.SAGDS012 =>
                $@"{nameof(AgendamentoServiceEnumSucess.SAGDS012)}:"
                + "AgendamentoService listados com sucesso",

            _ => string.Empty
        };
    }
}