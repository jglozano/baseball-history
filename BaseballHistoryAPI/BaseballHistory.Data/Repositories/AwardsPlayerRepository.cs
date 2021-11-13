using BaseballHistory.Data;
using BaseballHistory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Domain.Repositories;

public class AwardsPlayerRepository : IAwardsPlayerRepository
{
    private readonly BaseballStatsContext _context;

    public AwardsPlayerRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public async Task<List<AwardsPlayer>> GetAll() => await _context.AwardsPlayers.AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<AwardsPlayer?> GetById(string playerId, short yearId, string lgId, string awardId)
    {
        return await _context.AwardsPlayers.FindAsync(playerId, yearId, lgId, awardId);
    }
}