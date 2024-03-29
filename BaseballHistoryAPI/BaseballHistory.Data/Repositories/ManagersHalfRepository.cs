using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Data.Repositories;

public class ManagersHalfRepository : IManagersHalfRepository
{
    private readonly BaseballStatsContext _context;

    public ManagersHalfRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public Task<int> GetTotalCount()
    {
        return Task.FromResult(_context.ManagersHalves.Count());
    }

    public async Task<List<ManagersHalf>> GetAll(int pageNumber, int pageSize) => await _context.ManagersHalves
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<ManagersHalf?> GetById(string playerId, string teamId, short yearId, string lgId, short inseason, short half)
    {
        return await _context.ManagersHalves.FirstOrDefaultAsync(e => e.PlayerId == playerId && e.YearId == yearId && e.LgId == lgId && e.TeamId == teamId && e.Inseason == inseason && e.Half == half);
    }

    public async Task<List<ManagersHalf>> GetByPlayerId(string playerId)
    {
        return await _context.ManagersHalves.Where(e => e.PlayerId == playerId).ToListAsync();
    }
}