using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Data.Repositories;

public class FieldingRepository : IFieldingRepository
{
    private readonly BaseballStatsContext _context;

    public FieldingRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public Task<int> GetTotalCount()
    {
        return Task.FromResult(_context.Fieldings.Count());
    }

    public async Task<List<Fielding>> GetAll(int pageNumber, int pageSize) => await _context.Fieldings
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<Fielding?> GetById(string playerId, string teamId, short yearId, string lgId, short stint, string pos)
    {
        return await _context.Fieldings.FindAsync(playerId, teamId, yearId, lgId, stint, pos);
    }
}