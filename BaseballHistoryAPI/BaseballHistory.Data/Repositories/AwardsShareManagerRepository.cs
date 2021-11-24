using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Data.Repositories;

public class AwardsShareManagerRepository : IAwardsShareManagerRepository
{
    private readonly BaseballStatsContext _context;

    public AwardsShareManagerRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public Task<int> GetTotalCount()
    {
        return Task.FromResult(_context.AwardsShareManagers.Count());
    }

    public async Task<List<AwardsShareManager>> GetAll(int pageNumber, int pageSize) => await _context.AwardsShareManagers
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<AwardsShareManager?> GetById(string playerId, short yearId, string lgId, string awardId)
    {
        return await _context.AwardsShareManagers.FirstOrDefaultAsync(e => e.PlayerId == playerId && e.YearId == yearId && e.LgId == lgId && e.AwardId == awardId);
    }

    public async Task<List<AwardsShareManager>> GetByPlayerId(string playerId)
    {
        return await _context.AwardsShareManagers.Where(e => e.PlayerId == playerId).ToListAsync();
    }
}