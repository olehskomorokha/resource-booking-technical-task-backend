using ResourceBooking.Data.Entities;

namespace ResourceBooking.Data.Interfaces;

public interface IResourceRepository
{
    public Task<List<Resource>> GetAllAsync();
    public Task<Resource> GetByIdAsync(int id);
    public Task AddAsync(Resource model);
    public Task UpdateAsync(Resource model);
    public Task DeleteAsync(Resource model);
}