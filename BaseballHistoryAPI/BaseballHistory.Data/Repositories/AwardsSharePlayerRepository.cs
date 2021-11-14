using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Data.Repositories;

public class AwardsSharePlayerRepository : IAwardsSharePlayerRepository
{
    private readonly BaseballStatsContext _context;

    public AwardsSharePlayerRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public Task<int> GetTotalCount()
    {
        return Task.FromResult(_context.AwardsSharePlayers.Count());
    }

    public async Task<List<AwardsSharePlayer>> GetAll(int pageNumber, int pageSize) => await _context.AwardsSharePlayers
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<AwardsSharePlayer?> GetById(string playerId, short yearId, string lgId, string awardId)
    {
        return await _context.AwardsSharePlayers.FindAsync(playerId, yearId, lgId, awardId);
    }
}