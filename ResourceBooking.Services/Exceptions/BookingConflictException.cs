namespace ResourceBooking.Services.Exceptions;

public class BookingConflictException : SystemException
{
    public BookingConflictException(string code, string message)
        : base(code, message)
    {
        
    }
}