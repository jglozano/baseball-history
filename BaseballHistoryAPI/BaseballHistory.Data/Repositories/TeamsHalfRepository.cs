using BaseballHistory.Data;
using BaseballHistory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Domain.Repositories;

public class TeamsHalfRepository : ITeamsHalfRepository
{
    private readonly BaseballStatsContext _context;

    public TeamsHalfRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public async Task<List<TeamsHalf>> GetAll() => await _context.TeamsHalves.AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<TeamsHalf?> GetById(string teamId, short yearId, string lgId, string half)
    {
        return await _context.TeamsHalves.FindAsync(teamId, yearId, lgId, lgId, half);
    }
}