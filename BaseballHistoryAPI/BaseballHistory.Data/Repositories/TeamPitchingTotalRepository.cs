using BaseballHistory.Data;
using BaseballHistory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Domain.Repositories;

public class TeamPitchingTotalRepository : ITeamPitchingTotalRepository
{
    private readonly BaseballStatsContext _context;

    public TeamPitchingTotalRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public async Task<List<TeamPitchingTotal>> GetAll() => await _context.TeamPitchingTotals.AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<TeamPitchingTotal?> GetById(string teamId, short yearId, string lgId)
    {
        return await _context.TeamPitchingTotals.FindAsync(teamId, yearId, lgId);
    }
}