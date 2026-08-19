using ResourceBooking.Services.Models.Booking;

namespace ResourceBooking.Services.Interfaces;

public interface IBookingService
{
    public Task<List<BookingDto>> GetByResourceIdAsync(int resourceId);
    public Task AddAsync(AddBookingDto booking);
    public Task CancelAsync(int id);
}