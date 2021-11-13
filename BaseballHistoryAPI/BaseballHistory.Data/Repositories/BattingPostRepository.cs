using BaseballHistory.Data;
using BaseballHistory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Domain.Repositories;

public class BattingPostRepository : IBattingPostRepository
{
    private readonly BaseballStatsContext _context;

    public BattingPostRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public async Task<List<BattingPost>> GetAll() => await _context.BattingPosts.AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<BattingPost?> GetById(string playerId, string teamId, short yearId, string lgId, string round)
    {
        return await _context.BattingPosts.FindAsync(playerId, teamId, yearId, lgId, round);
    }
}