using System.Data;
using Microsoft.EntityFrameworkCore;
using ResourceBooking.Data.Entities;
using ResourceBooking.Data.Enums;
using ResourceBooking.Data.Interfaces;

namespace ResourceBooking.Data.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly AppDbContext _context;

    public BookingRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Booking> GetByIdAsync(int id)
    {
        return await _context.Bookings.FirstOrDefaultAsync(x => x.Id == id);
    }
    
    public async Task<List<Booking>> GetByResourceIdAsync(int resourceId)
    {
        return await _context.Bookings.Include(b => b.Resource).Where(x => x.ResourceId == resourceId && x.Status != Status.Cancelled).ToListAsync();
    }
    
    public async Task<Booking> AddAsync(Booking booking)
    {
        await using var transaction =
            await _context.Database.BeginTransactionAsync(
                IsolationLevel.Serializable);

        var hasOverlap = await _context.Bookings.AnyAsync(b =>
            b.ResourceId == booking.ResourceId &&
            b.Status != Status.Cancelled &&
            b.StartTime < booking.EndTime &&
            b.EndTime > booking.StartTime);

        if (hasOverlap)
        {
            await transaction.RollbackAsync();
            return null;
        }

        _context.Bookings.Add(booking);

        await _context.SaveChangesAsync();

        await transaction.CommitAsync();

        return booking;
    }

    public async Task CancelAsync(Booking booking)
    {
        _context.Bookings.Update(booking);
        await _context.SaveChangesAsync();
    }
}
