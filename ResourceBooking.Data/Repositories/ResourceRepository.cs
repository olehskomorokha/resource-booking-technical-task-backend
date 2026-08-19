using Microsoft.EntityFrameworkCore;
using ResourceBooking.Data.Entities;
using ResourceBooking.Data.Interfaces;

namespace ResourceBooking.Data.Repositories;

public class ResourceRepository : IResourceRepository
{
    private readonly AppDbContext _context;

    public ResourceRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Resource>> GetAllAsync()
    {
        return await _context.Resources.ToListAsync();
    }
    
    public async Task<Resource> GetByIdAsync(int id)
    {
        return await _context.Resources.FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task AddAsync(Resource model)
    {
        _context.Resources.Add(model);
        return _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Resource model)
    {
        _context.Resources.Update(model);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Resource model)
    {
        _context.Resources.Remove(model);
        await _context.SaveChangesAsync();
    }
}