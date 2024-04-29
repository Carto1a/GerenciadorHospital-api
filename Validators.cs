using System.Text.RegularExpressions;
using Hospital.Exceptions;

namespace Hospital;
public class Validators
{
    private string _loggerMessage;
    private List<string> _errors = [];
    public Validators(string loggerMessage)
    {
        _loggerMessage = loggerMessage;
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

    public void Telefone(long target, string fildName)
    {
        // TODO: melhorar a validação
        long MovelRangeMax = 99999999999;
        long FixoRangeMin = 9999999999;

        if (target < FixoRangeMin || target > MovelRangeMax)
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

    public void isInEnum<T>(T target, string fildName)
    {
        if (!Enum.IsDefined(typeof(T), target!))
            _errors.Add($"{fildName} is invalid");
    }

    public void Check()
    {
        if (_errors.Count > 0)
        {
            throw new RequestError(_loggerMessage, _errors);
        }
    }
}