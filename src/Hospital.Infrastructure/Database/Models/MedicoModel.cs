using System.Diagnostics.CodeAnalysis;

using Hospital.Domain.Entities.ValueObjects;

namespace Hospital.Infrastructure.Database.Models;
public class MedicoModel : CadastroModel
{
    public Crm CRM { get; set; }
    public Guid? DocCRMPath { get; set; }
    public string Especialidade { get; set; }

    [SetsRequiredMembers]
    public MedicoModel() { }
}