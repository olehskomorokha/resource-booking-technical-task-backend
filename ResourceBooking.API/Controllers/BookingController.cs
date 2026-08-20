using Microsoft.AspNetCore.Mvc;
using ResourceBooking.Services.Exceptions;
using ResourceBooking.Services.Interfaces;
using ResourceBooking.Services.Models.Booking;

namespace ResourceBookingBackend.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingController : ControllerBase
{
    private readonly IBookingService _bookingService;

    public BookingController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [HttpGet("{resourceId}")]
    public async Task<IActionResult> GetByResourceIdAsync(int resourceId)
    {
        return Ok(await _bookingService.GetByResourceIdAsync(resourceId));
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync(AddBookingDto booking)
    {
        try
        {
            await _bookingService.AddAsync(booking);
            return StatusCode(StatusCodes.Status201Created);
        }
        catch (BookingConflictException ex)
        {
            return Conflict(new { message = ex.Message, code = ex.Code });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> CancelAsync(int id)
    {
        await _bookingService.CancelAsync(id);
        return Ok();
    }
}