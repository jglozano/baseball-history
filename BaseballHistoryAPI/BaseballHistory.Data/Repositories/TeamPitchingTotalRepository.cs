using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Data.Repositories;

public class TeamPitchingTotalRepository : ITeamPitchingTotalRepository
{
    private readonly BaseballStatsContext _context;

    public TeamPitchingTotalRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public Task<int> GetTotalCount()
    {
        return Task.FromResult(_context.TeamPitchingTotals.Count());
    }

    public async Task<List<TeamPitchingTotal>> GetAll(int pageNumber, int pageSize) => await _context.TeamPitchingTotals
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<TeamPitchingTotal?> GetById(string teamId, short yearId, string lgId)
    {
        return await _context.TeamPitchingTotals.FirstOrDefaultAsync(e => e.TeamId == teamId && e.YearId == yearId && e.LgId == lgId);
    }

    public async Task<List<TeamPitchingTotal>> GetByTeamId(string teamId)
    {
        return await _context.TeamPitchingTotals.Where(e => e.TeamId == teamId).ToListAsync();
    }
}