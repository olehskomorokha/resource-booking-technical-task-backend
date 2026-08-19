using ResourceBooking.Data.Interfaces;
using ResourceBooking.Services.Interfaces;
using ResourceBooking.Services.Mapper;
using ResourceBooking.Services.Models;

namespace ResourceBooking.Services.Services;

public class ResourceService : IResourceService
{
    private readonly IResourceRepository _resourceRepository;

    public ResourceService(IResourceRepository resourceRepository)
    {
        _resourceRepository = resourceRepository;
    }

    public async Task<List<ResourceDto>> GetAllAsync()
    {
        var resources = await _resourceRepository.GetAllAsync();
        return resources.Select(ResourceMapper.MapToResourceDto).ToList();
    }

    public async Task<ResourceDto> GetByIdAsync(int id)
    {
        var resource = await _resourceRepository.GetByIdAsync(id);
        if (resource == null)
        {
            throw new KeyNotFoundException();
        }
        return ResourceMapper.MapToResourceDto(resource);
    }

    public async Task AddAsync(AddResourceDto resourceDto)
    {
        if (resourceDto == null)
        {
            throw new ArgumentNullException(nameof(resourceDto));
        }
        
        await _resourceRepository.AddAsync(ResourceMapper.MapToAddResource(resourceDto));
    }

    public async Task UpdateAsync(int id, UpdateResourceDto resourceDto)
    {
        var resource = await _resourceRepository.GetByIdAsync(id);
        if (resource == null)
        {
            throw new KeyNotFoundException();
        }
        
        if (!string.IsNullOrWhiteSpace(resourceDto.Name))
            resource.Name = resourceDto.Name;

        if (resourceDto.Type != null)
            resource.Type = resourceDto.Type.Value;

        if (resourceDto.IsActive != null)
            resource.IsActive = resourceDto.IsActive.Value;

        if (resourceDto.Capacity != null)
            resource.Capacity = resourceDto.Capacity.Value;

        await _resourceRepository.UpdateAsync(resource);
    }

    public async Task DeleteAsync(int id)
    {
        var resource = await _resourceRepository.GetByIdAsync(id);
        if (resource == null)
        {
            throw new KeyNotFoundException();
        }
        await _resourceRepository.DeleteAsync(resource);
    }
}