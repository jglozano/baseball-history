using BaseballHistory.Data;
using BaseballHistory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Domain.Repositories;

public class AwardsShareManagerRepository : IAwardsShareManagerRepository
{
    private readonly BaseballStatsContext _context;

    public AwardsShareManagerRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public async Task<List<AwardsShareManager>> GetAll() => await _context.AwardsShareManagers.AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<AwardsShareManager?> GetById(string playerId, short yearId, string lgId, string awardId)
    {
        return await _context.AwardsShareManagers.FindAsync(playerId, yearId, lgId, awardId);
    }
}