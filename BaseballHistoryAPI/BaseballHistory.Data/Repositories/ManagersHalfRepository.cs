using BaseballHistory.Data;
using BaseballHistory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Domain.Repositories;

public class ManagersHalfRepository : IManagersHalfRepository
{
    private readonly BaseballStatsContext _context;

    public ManagersHalfRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public async Task<List<ManagersHalf>> GetAll() => await _context.ManagersHalves.AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<ManagersHalf?> GetById(string playerId, string teamId, short yearId, string lgId, short inseason, short half)
    {
        return await _context.ManagersHalves.FindAsync(playerId, teamId, yearId, lgId, inseason, half);
    }
}