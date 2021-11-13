using BaseballHistory.Data;
using BaseballHistory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Domain.Repositories;

public class TeamFieldingTotalRepository : ITeamFieldingTotalRepository
{
    private readonly BaseballStatsContext _context;

    public TeamFieldingTotalRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public async Task<List<TeamFieldingTotal>> GetAll() => await _context.TeamFieldingTotals.AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<TeamFieldingTotal?> GetById(string teamId, short yearId, string lgId)
    {
        return await _context.TeamFieldingTotals.FindAsync(teamId, yearId, lgId);
    }
}