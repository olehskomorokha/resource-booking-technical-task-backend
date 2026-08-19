using ResourceBooking.Data.Enums;

namespace ResourceBooking.Services.Models;

public class AddResourceDto
{
    public string Name { get; set; }
    public TypeOfResource Type { get; set; }
    public int Capacity { get; set; }
    public bool IsActive { get; set; }
}