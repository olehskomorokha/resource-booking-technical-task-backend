using ResourceBooking.Data.Entities;
using ResourceBooking.Services.Models;

namespace ResourceBooking.Services.Mapper;

public static class ResourceMapper
{
    public static ResourceDto MapToResourceDto(Resource resource)
    {
        return new ResourceDto()
        {
            Id = resource.Id,
            Name = resource.Name,
            IsActive =  resource.IsActive,
            Capacity = resource.Capacity,
            Type = resource.Type,
        };
    }

    public static Resource MapToAddResource(AddResourceDto resourceDto)
    {
        return new Resource()
        {
            Name = resourceDto.Name,
            IsActive = resourceDto.IsActive,
            Capacity = resourceDto.Capacity,
            Type = resourceDto.Type
        };
    }
    
}