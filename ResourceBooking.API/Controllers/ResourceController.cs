using Microsoft.AspNetCore.Mvc;
using ResourceBooking.Services.Interfaces;
using ResourceBooking.Services.Models;

namespace ResourceBookingBackend.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResourceController : ControllerBase
{
    private readonly IResourceService _resourceService;

    public ResourceController(IResourceService resourceService)
    {
        _resourceService = resourceService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _resourceService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        return Ok(await _resourceService.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync(AddResourceDto resourceDto)
    {
        await _resourceService.AddAsync(resourceDto);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, UpdateResourceDto resourceDto)
    {
        await _resourceService.UpdateAsync(id, resourceDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _resourceService.DeleteAsync(id);
        return NoContent();
    }
}