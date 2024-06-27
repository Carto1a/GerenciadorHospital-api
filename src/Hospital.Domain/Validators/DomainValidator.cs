using System.Net.Mail;
using System.Text.RegularExpressions;

using Hospital.Domain.Exceptions;

namespace Hospital.Domain.Validators;
public class DomainValidator
{
    private readonly string? _logMessage;
    private readonly List<string> _errors = [];
    private IDictionary<string, List<string>> _fieldErrors = new Dictionary<string, List<string>>();
    private readonly string _fieldNameError;
    public DomainValidator(string logMessage, string fieldNameError)
    {
        _logMessage = logMessage;
        _fieldNameError = fieldNameError;
    }

    public DomainValidator(string fieldNameError)
    {
        _fieldNameError = fieldNameError;
    }

    private void AddError(string message)
    {
        _errors.Add(message);
    }

    public void IsNome(string? target, string fieldName)
    {
        if (target == null)
        {
            AddError($"{fieldName} é inválido");
            return;
        }

        if (!Regex.IsMatch(target, @"^[A-Za-z]{3,30}$"))
            _errors.Add($"{fieldName} é inválido");
    }

    public void NotNull(object? target, string fieldName)
    {
        if (target is null)
            _errors.Add($"{fieldName} não pode ser nulo");
    }

    public void DDD(string? target, string fieldName)
    {
        if (target == null)
        {
            _errors.Add($"{fieldName} é inválido");
            return;
        }

        if (!Regex.IsMatch(target, @"^[0-9]{2}$"))
            _errors.Add($"{fieldName} é inválido");
    }

    public void NotNullOrEmpty(string? target, string fieldName)
    {
        if (string.IsNullOrWhiteSpace(target))
            _errors.Add($"{fieldName} não pode ser nulo ou vazio");
    }

    public void NotEmptyOrWhitespaces(string? target, string fieldName)
    {
        if (target!.Trim().Length == 0)
            _errors.Add($"{fieldName} não pode ser vazio ou conter apenas espaços em branco");
    }

    public void MinLength(string? target, int minLenght, string fieldName)
    {
        if (target!.Length < minLenght)
            _errors.Add($"{fieldName} deve ter pelo menos {minLenght} caracteres");
    }

    public void MaxLength(string? target, int maxLenght, string fieldName)
    {
        if (target!.Length > maxLenght)
            _errors.Add($"{fieldName} deve ter no máximo {maxLenght} caracteres");
    }

    public void MinValue(decimal target, decimal minValue, string fieldName)
    {
        if (target < minValue)
            _errors.Add($"{fieldName} deve ser no mínimo {minValue}");
    }

    public void MaxValue(decimal target, decimal minValue, string fieldName)
    {
        if (target > minValue)
            _errors.Add($"{fieldName} deve ser no máximo {minValue}");
    }

    public void MinDate(DateTime target, DateTime minDate, string fieldName)
    {
        if (target < minDate)
            _errors.Add($"{fieldName} deve ser no mínimo {minDate}");
    }

    public void MaxDate(DateTime target, DateTime maxDate, string fieldName)
    {
        if (target > maxDate)
            _errors.Add($"{fieldName} deve ser no máximo {maxDate}");
    }

    public void Cpf(string target, string fieldName)
    {
        if (!Regex.IsMatch(target, @"^[0-9]{11}$"))
            _errors.Add($"{fieldName} é inválido");

        // TODO: CPF validation algorithm
    }

    public void Cep(string target, string fieldName)
    {
        // TODO: arrumar

        if (!Regex.IsMatch(target, @"^[0-9]{8}$"))
            _errors.Add($"{fieldName} é inválido");
    }

    public void NumeroTelefone(string target, string fieldName)
    {
        var regexTelefone = @"^[2-5]\d{7}$";

        if (!Regex.IsMatch(target, regexTelefone))
            _errors.Add($"{fieldName} é inválido");
    }

    public void NumeroCelular(string target, string fieldName)
    {
        var regexCelular = @"^9\d{8}$";

        if (!Regex.IsMatch(target, regexCelular))
            _errors.Add($"{fieldName} é inválido");
    }

    public void Cnpj(string target, string fieldName)
    {
        if (!Regex.IsMatch(target,
            @"^[0-9]{2}\.[0-9]{3}\.[0-9]{3}\/[0-9]{4}-[0-9]{2}$"))
            _errors.Add($"{fieldName} é inválido");
    }

    public void Crm(string target, string fieldName)
    {
        var regex = @"^[0-9]{6}$";
        if (!Regex.IsMatch(target, regex))
            _errors.Add($"{fieldName} é inválido");
    }

    public void CrmUf(string target, string fieldName)
    {
        // TODO: arrumar
        if (!Regex.IsMatch(target, @"^[A-Z]{2}$"))
            _errors.Add($"{fieldName} é inválido");
    }

    public void NumeroCasa(string target, string fieldName)
    {
        if (!Regex.IsMatch(target, @"^[0-9]{1,8}([A-Z]{1,10})?$"))
            _errors.Add($"{fieldName} é inválido");
    }


    public void isInEnum<T>(T target, Type type, string fieldName)
    {
        if (!Enum.IsDefined(type, target!))
            _errors.Add($"{fieldName} é inválido");
    }

    public void Email(string? target, string fieldName)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(target))
            {
                _errors.Add($"{fieldName} é inválido");
                return;
            }

            var addr = new MailAddress(target);
        }
        catch
        {
            _errors.Add($"{fieldName} é inválido");
        }
    }

    public void Query(int limit, int page)
    {
        if (limit < 1)
            _errors.Add("Parâmetro limit deve ser maior que 0");

        if (page < 0)
            _errors.Add("Parâmetro page deve ser 0 ou maior");
    }

    public virtual void Check()
    {
        InitializeFieldErrors();
        if (_fieldErrors.Count != 0)
        {
            throw new DomainException(_logMessage!, _fieldErrors);
        }
    }

    public void LoadValueObjectValidations(
        DomainValidator validations)
    {
        var errors = validations._errors;

        if (errors.Count == 0)
        {
            return;
        }

        InitializeFieldErrors();
        if (_fieldErrors.Keys.Any(k => k == validations._fieldNameError))
        {
            throw new DomainInternalException("FieldErrors já foi carregado");
        }

        _fieldErrors.Add(validations._fieldNameError, errors);
    }

    private void InitializeFieldErrors()
    {
        if (_fieldErrors.Count != 0)
        {
            return;
        }

        if (_errors.Count == 0)
        {
            return;
        }

        _fieldErrors.Add(_fieldNameError, _errors);
    }
}