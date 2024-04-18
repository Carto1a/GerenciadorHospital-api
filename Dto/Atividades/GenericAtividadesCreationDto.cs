using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Dto.Atividades;
public class GenericAtividadesCreationDto
{
    public int AgendamentoId { get; set; }
    public DateTime DataHora { get; set; }
    public int PacienteId { get; set; }
    public int MedicoId { get; set; }
}
