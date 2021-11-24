using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Data.Repositories;

public class ParkRepository : IParkRepository
{
    private readonly BaseballStatsContext _context;

    public ParkRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public Task<int> GetTotalCount()
    {
        return Task.FromResult(_context.Parks.Count());
    }

    public async Task<List<Park>> GetAll(int pageNumber, int pageSize) => await _context.Parks
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<Park?> GetById(string parkId)
    {
        return await _context.Parks.FirstOrDefaultAsync(e => e.ParkId == parkId);
    }
}