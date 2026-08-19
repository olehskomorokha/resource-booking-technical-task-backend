using Microsoft.EntityFrameworkCore;
using ResourceBooking.Data.Entities;

namespace ResourceBooking.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Resource> Resources { get; set; }
    public DbSet<Booking> Bookings { get; set; }
}