using System.ComponentModel.DataAnnotations;
using ResourceBooking.Data.Enums;

namespace ResourceBooking.Data.Entities;

public class Booking
{
    public int Id { get; set; }
    public int ResourceId { get; set; }
    [MaxLength(100)] public string UserName { get; set; } = string.Empty;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public Status Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public Resource Resource { get; set; } = null!;
}