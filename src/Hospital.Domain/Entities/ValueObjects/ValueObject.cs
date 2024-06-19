using Hospital.Domain.Validators;

namespace Hospital.Domain.Entities.ValueObjects;
public abstract class ValueObject
{
    public abstract DomainValidator Validations();
}