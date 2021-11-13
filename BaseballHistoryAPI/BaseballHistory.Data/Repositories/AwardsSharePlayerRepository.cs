using BaseballHistory.Data;
using BaseballHistory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Domain.Repositories;

public class AwardsSharePlayerRepository : IAwardsSharePlayerRepository
{
    private readonly BaseballStatsContext _context;

    public AwardsSharePlayerRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public async Task<List<AwardsSharePlayer>> GetAll() => await _context.AwardsSharePlayers.AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<AwardsSharePlayer?> GetById(string playerId, short yearId, string lgId, string awardId)
    {
        return await _context.AwardsSharePlayers.FindAsync(playerId, yearId, lgId, awardId);
    }
}