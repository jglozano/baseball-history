using BaseballHistory.Data;
using BaseballHistory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Domain.Repositories;

public class PlayerPitchingTotalRepository : IPlayerPitchingTotalRepository
{
    private readonly BaseballStatsContext _context;

    public PlayerPitchingTotalRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public async Task<List<PlayerPitchingTotal>> GetAll() => await _context.PlayerPitchingTotals.AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<PlayerPitchingTotal?> GetById(string playerId)
    {
        return await _context.PlayerPitchingTotals.FindAsync(playerId);
    }
}