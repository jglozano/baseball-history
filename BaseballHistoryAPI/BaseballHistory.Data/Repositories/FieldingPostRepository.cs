using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Data.Repositories;

public class FieldingPostRepository : IFieldingPostRepository
{
    private readonly BaseballStatsContext _context;

    public FieldingPostRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public Task<int> GetTotalCount()
    {
        return Task.FromResult(_context.FieldingPosts.Count());
    }

    public async Task<List<FieldingPost>> GetAll(int pageNumber, int pageSize) => await _context.FieldingPosts
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<FieldingPost?> GetById(string playerId, string teamId, short yearId, string lgId, string round, string pos)
    {
        return await _context.FieldingPosts.FindAsync(playerId, teamId, yearId, lgId, round, pos);
    }
}