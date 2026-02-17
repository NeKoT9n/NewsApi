namespace NewsApi.Domain.Common.Validation;

public class Result<TValue, TError>
{
    public TValue Value { get; }
    public TError Error { get; }
    private bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;

    private Result(TValue value)
    {
        IsSuccess = true;
        Value = value;
        Error = default!;
    }

    private Result(TError error)
    {
        IsSuccess = false;
        Value = default!;
        Error = error;
    }

    public static implicit operator Result<TValue, TError>(TValue value) => new(value);
    public static implicit operator Result<TValue, TError>(TError error) => new(error);
}

public record Error
{
    public string Code { get; }
    public string Message { get; }
    
    private Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public static Error Create(string code, string message)
        => new Error(code, message);
    
}

public static class Errors
{
    public static class General
    {
        public static Error ValueIsInvalid(string? name = null)
        {
            var label = name ?? "value";
            return Error.Create("value.is.invalid", $"{label} is invalid");
        }
        
        public static Error NotFound(Guid? id = null)
        {
            var forId = id == null ? "" : $"for id: {id.Value}";
            return Error.Create("record.not.found", $"Record not found {forId}");
        }
        
        public static Error NotFound(long? id = null)
        {
            var forId = id == null ? "" : $"for id: {id.Value}";
            return Error.Create("record.not.found", $"Record not found {forId}");
        }
    }
}