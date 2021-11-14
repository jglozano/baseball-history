using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Data.Repositories;

public class TeamBattingTotalRepository : ITeamBattingTotalRepository
{
    private readonly BaseballStatsContext _context;

    public TeamBattingTotalRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public Task<int> GetTotalCount()
    {
        return Task.FromResult(_context.TeamBattingTotals.Count());
    }

    public async Task<List<TeamBattingTotal>> GetAll(int pageNumber, int pageSize) => await _context.TeamBattingTotals
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<TeamBattingTotal?> GetById(string teamId, short yearId, string lgId)
    {
        return await _context.TeamBattingTotals.FindAsync(teamId, yearId, lgId);
    }
}