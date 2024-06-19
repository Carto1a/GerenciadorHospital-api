namespace Hospital.Domain.Entities;
public abstract class Entity : IEntity
{
    public Guid Id { get; set; }
    public DateTime Criado { get; set; }
    public bool Ativo { get; set; }

    public virtual void Deletar()
    {
        Ativo = false;
    }

    public Entity()
    {
        Id = Guid.NewGuid();
        Criado = DateTime.Now;
        Ativo = true;
    }

    public abstract void Validate();
}