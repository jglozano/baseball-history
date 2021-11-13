using BaseballHistory.Data;
using BaseballHistory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Domain.Repositories;

public class AppearanceRepository : IAppearanceRepository
{
    private readonly BaseballStatsContext _context;

    public AppearanceRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public async Task<List<Appearance>> GetAll() => await _context.Appearances.AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<Appearance?> GetById(string playerId, short yearId, string lgId, string teamId)
    {
        return await _context.Appearances.FindAsync(playerId, yearId, lgId, teamId);
    }
}