using BaseballHistory.Data;
using BaseballHistory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Domain.Repositories;

public class FieldingPostRepository : IFieldingPostRepository
{
    private readonly BaseballStatsContext _context;

    public FieldingPostRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public async Task<List<FieldingPost>> GetAll() => await _context.FieldingPosts.AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<FieldingPost?> GetById(string playerId, string teamId, short yearId, string lgId, string round, string pos)
    {
        return await _context.FieldingPosts.FindAsync(playerId, teamId, yearId, lgId, round, pos);
    }
}