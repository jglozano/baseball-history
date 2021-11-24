using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Data.Repositories;

public class PlayerBattingTotalRepository : IPlayerBattingTotalRepository
{
    private readonly BaseballStatsContext _context;

    public PlayerBattingTotalRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public Task<int> GetTotalCount()
    {
        return Task.FromResult(_context.PlayerBattingTotals.Count());
    }

    public async Task<List<PlayerBattingTotal>> GetAll(int pageNumber, int pageSize) => await _context.PlayerBattingTotals
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<PlayerBattingTotal?> GetById(string playerId)
    {
        return await _context.PlayerBattingTotals.FirstOrDefaultAsync(p => p.PlayerId == playerId);
    }
}