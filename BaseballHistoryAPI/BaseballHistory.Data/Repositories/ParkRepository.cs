using BaseballHistory.Data;
using BaseballHistory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Domain.Repositories;

public class ParkRepository : IParkRepository
{
    private readonly BaseballStatsContext _context;

    public ParkRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public async Task<List<Park>> GetAll() => await _context.Parks.AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<Park?> GetById(string parkId)
    {
        return await _context.Parks.FindAsync(parkId);
    }
}