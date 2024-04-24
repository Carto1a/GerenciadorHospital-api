namespace Hospital.Logs.Agendamentos.Warns;
public class AgendamentoServiceWarns
{
    public static string ConstructWarn(
        AgendamentoServiceEnumWarns warn,
        string type,
        string adicional = "")
    {
        return $"[{type}] {GetWarnMessage(warn)}: {adicional}";
    }
    public static string GetWarnMessage(
        AgendamentoServiceEnumWarns warn)
    {
        return warn switch
        {
            AgendamentoServiceEnumWarns.WAGDS000 =>
                $"{nameof(AgendamentoServiceEnumWarns.WAGDS000)}"
                + "",

            AgendamentoServiceEnumWarns.WAGDS001 =>
                $"{nameof(AgendamentoServiceEnumWarns.WAGDS001)}"
                + "",

            AgendamentoServiceEnumWarns.WAGDS002 =>
                $"{nameof(AgendamentoServiceEnumWarns.WAGDS002)}"
                + "",

            AgendamentoServiceEnumWarns.WAGDS003 =>
                $"{nameof(AgendamentoServiceEnumWarns.WAGDS003)}"
                + "",

            AgendamentoServiceEnumWarns.WAGDS004 =>
                $"{nameof(AgendamentoServiceEnumWarns.WAGDS004)}"
                + "",

            /* AgendamentoServiceEnumWarn.WAGDS005 => */
            /*     $"{nameof(AgendamentoServiceEnumWarn.WAGDS005)}" */
            /*     + "", */

            /* AgendamentoServiceEnumWarn.WAGDS006 => */
            /*     $"{nameof(AgendamentoServiceEnumWarn.WAGDS006)}" */
            /*     + "", */

            /* AgendamentoServiceEnumWarn.WAGDS007 => */
            /*     $"{nameof(AgendamentoServiceEnumWarn.WAGDS007)}" */
            /*     + "", */

            _ => string.Empty
        };
    }
}