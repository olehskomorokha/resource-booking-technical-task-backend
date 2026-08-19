using ResourceBooking.Data.Entities;
using ResourceBooking.Services.Models;

namespace ResourceBooking.Services.Interfaces;

public interface IResourceService
{
    public Task<List<ResourceDto>> GetAllAsync();
    public Task<ResourceDto> GetByIdAsync(int id);
    public Task AddAsync(AddResourceDto addResourceDto);
    public Task UpdateAsync(int id, UpdateResourceDto updateResourceDto);
    public Task DeleteAsync(int id);
}