using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Data.Repositories;

public class BattingPostRepository : IBattingPostRepository
{
    private readonly BaseballStatsContext _context;

    public BattingPostRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public Task<int> GetTotalCount()
    {
        return Task.FromResult(_context.BattingPosts.Count());
    }

    public async Task<List<BattingPost>> GetAll(int pageNumber, int pageSize) => await _context.BattingPosts
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<BattingPost?> GetById(string playerId, string teamId, short yearId, string lgId, string round)
    {
        return await _context.BattingPosts.FirstOrDefaultAsync(e => e.PlayerId == playerId && e.YearId == yearId && e.LgId == lgId && e.TeamId == teamId && e.Round == round);
    }

    public async Task<List<BattingPost>> GetByPlayerId(string playerId)
    {
        return await _context.BattingPosts.Where(e => e.PlayerId == playerId).ToListAsync();
    }
}