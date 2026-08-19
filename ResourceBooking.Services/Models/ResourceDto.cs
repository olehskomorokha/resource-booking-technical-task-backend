using ResourceBooking.Data.Enums;

namespace ResourceBooking.Services.Models;

public class ResourceDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public TypeOfResource Type { get; set; }
    public int Capacity { get; set; }
    public bool IsActive { get; set; }
}