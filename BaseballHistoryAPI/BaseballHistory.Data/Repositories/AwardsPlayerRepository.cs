using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Data.Repositories;

public class AwardsPlayerRepository : IAwardsPlayerRepository
{
    private readonly BaseballStatsContext _context;

    public AwardsPlayerRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public Task<int> GetTotalCount()
    {
        return Task.FromResult(_context.AwardsPlayers.Count());
    }

    public async Task<List<AwardsPlayer>> GetAll(int pageNumber, int pageSize) => await _context.AwardsPlayers
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .AsNoTrackingWithIdentityResolution().ToListAsync();

    public async Task<AwardsPlayer?> GetById(string playerId, short yearId, string lgId, string awardId)
    {
        return await _context.AwardsPlayers.FirstOrDefaultAsync(e => e.PlayerId == playerId && e.YearId == yearId && e.LgId == lgId && e.AwardId == awardId);
    }

    public async Task<List<AwardsPlayer>> GetByPlayerId(string playerId)
    {
        return await _context.AwardsPlayers.Where(e => e.PlayerId == playerId).ToListAsync();
    }
}