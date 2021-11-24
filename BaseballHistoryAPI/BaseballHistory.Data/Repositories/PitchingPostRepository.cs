using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Data.Repositories;

public class PitchingPostRepository : IPitchingPostRepository
{
    private readonly BaseballStatsContext _context;

    public PitchingPostRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public Task<int> GetTotalCount()
    {
        return Task.FromResult(_context.PitchingPosts.Count());
    }

    public async Task<List<PitchingPost>> GetAll(int pageNumber, int pageSize) => await _context.PitchingPosts
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<PitchingPost?> GetById(string playerId, string teamId, short yearId, string lgId, string round)
    {
        return await _context.PitchingPosts.FirstOrDefaultAsync(e => e.PlayerId == playerId && e.YearId == yearId && e.LgId == lgId && e.TeamId == teamId && e.Round == round);
    }

    public async Task<List<PitchingPost>> GetByPlayerId(string playerId)
    {
        return await _context.PitchingPosts.Where(e => e.PlayerId == playerId).ToListAsync();
    }
}