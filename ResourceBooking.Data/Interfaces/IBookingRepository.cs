using ResourceBooking.Data.Entities;

namespace ResourceBooking.Data.Interfaces;

public interface IBookingRepository
{
    public Task<Booking> GetByIdAsync(int id);
    public Task<List<Booking>> GetByResourceIdAsync(int resourceId);
    public Task AddAsync(Booking booking);
    public Task CancelAsync(Booking booking);
}