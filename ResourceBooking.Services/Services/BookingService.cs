using ResourceBooking.Data.Enums;
using ResourceBooking.Data.Interfaces;
using ResourceBooking.Services.Exceptions;
using ResourceBooking.Services.Interfaces;
using ResourceBooking.Services.Mapper;
using ResourceBooking.Services.Models.Booking;

namespace ResourceBooking.Services.Services;

public class BookingService : IBookingService
{
    private readonly IBookingRepository _bookingRepository;

    public BookingService(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }

    public async Task<List<BookingDto>> GetByResourceIdAsync(int resourceId)
    {
        var bookings = await _bookingRepository.GetByResourceIdAsync(resourceId);
        return bookings.Select(BookingMapper.MapToBookingDto).ToList();
    }

    public async Task AddAsync(AddBookingDto booking)
    {
        if (booking.StartTime >= booking.EndTime)
        {
            throw new BookingConflictException(
                "Booking Conflict", "Start time must be earlier than end time.");
        }
        if (booking == null)
        {
            throw new ArgumentNullException(nameof(booking));
        }

        var bookingToAdd = BookingMapper.MapToAddBooking(booking);
        
        var created = await _bookingRepository.AddAsync(bookingToAdd);
        if (created == null)
        {
            throw new BookingConflictException(
                "Booking Conflict", "Resource is already booked for this time.");
        }
        
        
    }

    public async Task CancelAsync(int id)
    {
        var booking = await _bookingRepository.GetByIdAsync(id);

        if (booking == null)
        {
            throw new ArgumentNullException(nameof(booking));
        }

        booking.Status = Status.Cancelled;
        
        await _bookingRepository.CancelAsync(booking);
    }
}