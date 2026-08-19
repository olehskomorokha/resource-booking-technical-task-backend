using System.ComponentModel.DataAnnotations;
using ResourceBooking.Data.Enums;

namespace ResourceBooking.Data.Entities;

public class Resource
{
    public int Id { get; set; }
    [MaxLength(100)] 
    public string Name { get; set; } = string.Empty;
    public TypeOfResource Type { get; set; }
    public int Capacity { get; set; }
    public bool IsActive { get; set; }

    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}