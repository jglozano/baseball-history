using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Data.Repositories;

public class FieldingOfsplitRepository : IFieldingOfsplitRepository
{
    private readonly BaseballStatsContext _context;

    public FieldingOfsplitRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public Task<int> GetTotalCount()
    {
        return Task.FromResult(_context.FieldingOfsplits.Count());
    }

    public async Task<List<FieldingOfsplit>> GetAll(int pageNumber, int pageSize) => await _context.FieldingOfsplits
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<FieldingOfsplit?> GetById(string playerId, string teamId, short yearId, string lgId, short stint, string pos)
    {
        return await _context.FieldingOfsplits.FirstOrDefaultAsync(e => e.PlayerId == playerId && e.YearId == yearId && e.LgId == lgId && e.TeamId == teamId && e.Stint ==  stint && e.Pos == pos);
    }

    public async Task<List<FieldingOfsplit>> GetByPlayerId(string playerId)
    {
        return await _context.FieldingOfsplits.Where(e => e.PlayerId == playerId).ToListAsync();
    }
}