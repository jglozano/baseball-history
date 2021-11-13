using BaseballHistory.Data;
using BaseballHistory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Domain.Repositories;

public class PitchingPostRepository : IPitchingPostRepository
{
    private readonly BaseballStatsContext _context;

    public PitchingPostRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public async Task<List<PitchingPost>> GetAll() => await _context.PitchingPosts.AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<PitchingPost?> GetById(string playerId, string teamId, short yearId, string lgId, string round)
    {
        return await _context.PitchingPosts.FindAsync(playerId, teamId, yearId, lgId, round);
    }
}