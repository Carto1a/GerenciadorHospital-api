using System.ComponentModel.DataAnnotations;

namespace Hospital.Domain.Entities;
public interface IEntity
{
    [Key]
    public Guid Id { get; set; }
    public DateTime Criado { get; set; }
    public bool Ativo { get; set; }

    public void Deletar();
}