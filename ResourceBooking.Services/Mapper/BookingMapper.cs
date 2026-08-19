using ResourceBooking.Data.Entities;
using ResourceBooking.Data.Enums;
using ResourceBooking.Services.Models.Booking;

namespace ResourceBooking.Services.Mapper;

public static class BookingMapper
{
    public static BookingDto MapToBookingDto(Booking booking)
    {
        return new BookingDto()
        {
            ResourceId = booking.ResourceId,
            UserName =  booking.UserName,
            StartTime = booking.StartTime,
            EndTime = booking.EndTime,
            CreatedAt =  booking.CreatedAt,
            Status =  booking.Status
        };
    }

    public static Booking MapToAddBooking(AddBookingDto booking)
    {
        return new Booking()
        {
            ResourceId = booking.ResourceId,
            UserName = booking.UserName,
            StartTime = booking.StartTime,
            EndTime = booking.EndTime,
            CreatedAt = DateTime.Now,
            Status =  Status.Pending,
        };
    }
}