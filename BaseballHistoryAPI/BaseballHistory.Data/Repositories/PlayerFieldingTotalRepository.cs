using BaseballHistory.Data;
using BaseballHistory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Domain.Repositories;

public class PlayerFieldingTotalRepository : IPlayerFieldingTotalRepository
{
    private readonly BaseballStatsContext _context;

    public PlayerFieldingTotalRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public async Task<List<PlayerFieldingTotal>> GetAll() => await _context.PlayerFieldingTotals.AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<PlayerFieldingTotal?> GetById(string playerId)
    {
        return await _context.PlayerFieldingTotals.FindAsync(playerId);
    }
}