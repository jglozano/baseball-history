using BaseballHistory.Data;
using BaseballHistory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Domain.Repositories;

public class TeamBattingTotalRepository : ITeamBattingTotalRepository
{
    private readonly BaseballStatsContext _context;

    public TeamBattingTotalRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public async Task<List<TeamBattingTotal>> GetAll() => await _context.TeamBattingTotals.AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<TeamBattingTotal?> GetById(string teamId, short yearId, string lgId)
    {
        return await _context.TeamBattingTotals.FindAsync(teamId, yearId, lgId);
    }
}