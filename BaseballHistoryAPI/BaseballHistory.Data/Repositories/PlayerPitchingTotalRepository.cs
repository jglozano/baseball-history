using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Data.Repositories;

public class PlayerPitchingTotalRepository : IPlayerPitchingTotalRepository
{
    private readonly BaseballStatsContext _context;

    public PlayerPitchingTotalRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public Task<int> GetTotalCount()
    {
        return Task.FromResult(_context.PlayerPitchingTotals.Count());
    }

    public async Task<List<PlayerPitchingTotal>> GetAll(int pageNumber, int pageSize) => await _context.PlayerPitchingTotals
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<PlayerPitchingTotal?> GetById(string playerId)
    {
        return await _context.PlayerPitchingTotals.FindAsync(playerId);
    }
}