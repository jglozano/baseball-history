using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Data.Repositories;

public class AwardsManagerRepository : IAwardsManagerRepository
{
    private readonly BaseballStatsContext _context;

    public AwardsManagerRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public Task<int> GetTotalCount()
    {
        return Task.FromResult(_context.AwardsManagers.Count());
    }

    public async Task<List<AwardsManager>> GetAll(int pageNumber, int pageSize) => await _context.AwardsManagers
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<AwardsManager?> GetById(string playerId, short yearId, string lgId, string awardId)
    {
        return await _context.AwardsManagers.FirstOrDefaultAsync(e => e.PlayerId == playerId && e.YearId == yearId && e.LgId == lgId && e.AwardId == awardId);
    }

    public async Task<List<AwardsManager>> GetByPlayerId(string playerId)
    {
        return await _context.AwardsManagers.Where(e => e.PlayerId == playerId).ToListAsync();
    }
}