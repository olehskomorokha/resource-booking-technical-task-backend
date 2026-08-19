using ResourceBooking.Data.Entities;
using ResourceBooking.Data.Enums;

namespace ResourceBooking.Services.Models.Booking;

public class BookingDto
{
    public int Id { get; set; }
    public int ResourceId { get; set; }
    public string UserName { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public Status Status { get; set; }
    public DateTime CreatedAt { get; set; }
}