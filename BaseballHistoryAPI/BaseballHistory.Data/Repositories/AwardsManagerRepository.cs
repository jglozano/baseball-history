using BaseballHistory.Data;
using BaseballHistory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Domain.Repositories;

public class AwardsManagerRepository : IAwardsManagerRepository
{
    private readonly BaseballStatsContext _context;

    public AwardsManagerRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public async Task<List<AwardsManager>> GetAll() => await _context.AwardsManagers.AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<AwardsManager?> GetById(string playerId, short yearId, string lgId, string awardId)
    {
        return await _context.AwardsManagers.FindAsync(playerId, yearId, lgId, awardId);
    }
}