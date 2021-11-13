using BaseballHistory.Data;
using BaseballHistory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Domain.Repositories;

public class PlayerBattingTotalRepository : IPlayerBattingTotalRepository
{
    private readonly BaseballStatsContext _context;

    public PlayerBattingTotalRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public async Task<List<PlayerBattingTotal>> GetAll() => await _context.PlayerBattingTotals.AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<PlayerBattingTotal?> GetById(string playerId)
    {
        return await _context.PlayerBattingTotals.FindAsync(playerId);
    }
}