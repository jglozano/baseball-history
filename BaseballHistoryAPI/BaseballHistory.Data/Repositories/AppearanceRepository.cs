using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Data.Repositories;

public class AppearanceRepository : IAppearanceRepository
{
    private readonly BaseballStatsContext _context;

    public AppearanceRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public Task<int> GetTotalCount()
    {
        return Task.FromResult(_context.Appearances.Count());
    }

    public async Task<List<Appearance>> GetAll(int pageNumber, int pageSize) => await _context.Appearances
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<Appearance?> GetById(string playerId, short yearId, string lgId, string teamId)
    {
        return await _context.Appearances.FindAsync(playerId, yearId, lgId, teamId);
    }
}