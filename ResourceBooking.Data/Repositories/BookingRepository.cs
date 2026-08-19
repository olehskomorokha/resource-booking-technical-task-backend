using Microsoft.EntityFrameworkCore;
using ResourceBooking.Data.Entities;
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
        return await _context.Bookings.Include(b => b.Resource).Where(b => b.ResourceId == resourceId).ToListAsync();
    }

    public async Task AddAsync(Booking booking)
    {
        await _context.Bookings.AddAsync(booking);
        await _context.SaveChangesAsync();
    }

    public async Task CancelAsync(Booking booking)
    {
        _context.Bookings.Update(booking);
        await _context.SaveChangesAsync();
    }
    
}