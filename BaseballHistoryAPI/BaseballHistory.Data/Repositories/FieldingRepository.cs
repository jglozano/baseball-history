using BaseballHistory.Data;
using BaseballHistory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Domain.Repositories;

public class FieldingRepository : IFieldingRepository
{
    private readonly BaseballStatsContext _context;

    public FieldingRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public async Task<List<Fielding>> GetAll() => await _context.Fieldings.AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<Fielding?> GetById(string playerId, string teamId, short yearId, string lgId, short stint, string pos)
    {
        return await _context.Fieldings.FindAsync(playerId, teamId, yearId, lgId, stint, pos);
    }
}