using BaseballHistory.Data;
using BaseballHistory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Domain.Repositories;

public class FieldingOfsplitRepository : IFieldingOfsplitRepository
{
    private readonly BaseballStatsContext _context;

    public FieldingOfsplitRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public async Task<List<FieldingOfsplit>> GetAll() => await _context.FieldingOfsplits.AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<FieldingOfsplit?> GetById(string playerId, string teamId, short yearId, string lgId, short stint, string pos)
    {
        return await _context.FieldingOfsplits.FindAsync(playerId, teamId, yearId, lgId, stint, pos);
    }
}