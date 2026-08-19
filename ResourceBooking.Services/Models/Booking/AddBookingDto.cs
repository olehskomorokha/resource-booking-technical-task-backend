using ResourceBooking.Data.Entities;
using ResourceBooking.Data.Enums;

namespace ResourceBooking.Services.Models.Booking;

public class AddBookingDto
{
    public int ResourceId { get; set; }
    public string UserName { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}