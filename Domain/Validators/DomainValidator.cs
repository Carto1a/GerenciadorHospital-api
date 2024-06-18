using System.Text.RegularExpressions;

using Hospital.Domain.Exceptions;

namespace Hospital.Domain.Validators;
public class DomainValidator
{
    private readonly string _logMessage;
    private readonly List<string> _errors = [];
    public DomainValidator(string logMessage)
    {
        _logMessage = logMessage;
    }

    public void IsNome(string? target, string fildName)
    {
        if (target == null)
        {
            _errors.Add($"{fildName} is invalid");
            return;
        }

        if (!Regex.IsMatch(target, @"^[A-Za-z]{3,30}$"))
            _errors.Add($"{fildName} is invalid");
    }

    public void NotNull(object? target, string fildName)
    {
        if (target is null)
            _errors.Add($"{fildName} should not be null");
    }

    public void NotNullOrEmpty(string? target, string fildName)
    {
        if (string.IsNullOrWhiteSpace(target))
            _errors.Add($"{fildName} not be null or empty");
    }

    public void MinLength(string? target, int minLenght, string fildName)
    {
        if (target!.Length < minLenght)
            _errors.Add($"{fildName} must be at least {minLenght} characters");
    }

    public void MaxLength(string? target, int maxLenght, string fildName)
    {
        if (target!.Length > maxLenght)
            _errors.Add($"{fildName} must be at most {maxLenght} characters");
    }

    public void MinValue(decimal target, decimal minValue, string fildName)
    {
        if (target < minValue)
            _errors.Add($"{fildName} must be at least {minValue}");
    }

    public void MinDate(DateTime target, DateTime minDate, string fildName)
    {
        if (target < minDate)
            _errors.Add($"{fildName} must be at least {minDate}");
    }

    public void MaxDate(DateTime target, DateTime maxDate, string fildName)
    {
        if (target > maxDate)
            _errors.Add($"{fildName} must be at most {maxDate}");
    }

    public void Cpf(string target, string fildName)
    {
        if (!Regex.IsMatch(target, @"^[0-9]{11}$"))
            _errors.Add($"{fildName} is invalid");

        // TODO: CPF validation algorithm
    }

    public void Cep(string target, string fildName)
    {
        // TODO: arrumar

        if (!Regex.IsMatch(target, @"^[0-9]{8}$"))
            _errors.Add($"{fildName} is invalid");
    }

    public void Telefone(string target, string fildName)
    {
        var regex = @"/\d{9,10}/";
        if (Regex.IsMatch(target, regex))
            _errors.Add($"{fildName} is invalid");
    }

    public void Cnpj(string target, string fildName)
    {
        if (!Regex.IsMatch(target,
            @"^[0-9]{2}\.[0-9]{3}\.[0-9]{3}\/[0-9]{4}-[0-9]{2}$"))
            _errors.Add($"{fildName} is invalid");
    }

    public void Crm(int target, string fildName)
    {
        if (target < 100000 || target > 999999)
            _errors.Add($"{fildName} is invalid");
    }

    public void CrmUf(string target, string fildName)
    {
        // TODO: arrumar
        if (!Regex.IsMatch(target, @"^[A-Z]{2}$"))
            _errors.Add($"{fildName} is invalid");
    }

    public void NumeroCasa(string target, string fildName)
    {
        if (!Regex.IsMatch(target, @"^[0-9]{1,8}([A-Z]{1,10})?$"))
            _errors.Add($"{fildName} is invalid");
    }


    public void isInEnum<T>(T target, Type type, string fildName)
    {
        if (!Enum.IsDefined(type, target!))
            _errors.Add($"{fildName} is invalid");
    }

    public void Query(int limit, int page)
    {
        if (limit < 1 || page < 0)
            _errors.Add("Invalid query parameters");
    }

    public void Check()
    {
        if (_errors.Count > 0)
        {
            throw new DomainException(_logMessage, _errors);
        }
    }
}