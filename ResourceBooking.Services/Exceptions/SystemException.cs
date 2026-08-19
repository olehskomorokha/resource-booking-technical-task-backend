namespace ResourceBooking.Services.Exceptions;

public class SystemException : Exception
{
    public string Code { get; set; }

    public SystemException(string code, string message = null, Exception inner = null)
        : base(message ?? code, inner)
    {
        Code = code;
    }
}