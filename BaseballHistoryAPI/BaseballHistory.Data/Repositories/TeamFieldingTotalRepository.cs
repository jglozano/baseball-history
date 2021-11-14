using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Data.Repositories;

public class TeamFieldingTotalRepository : ITeamFieldingTotalRepository
{
    private readonly BaseballStatsContext _context;

    public TeamFieldingTotalRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public Task<int> GetTotalCount()
    {
        return Task.FromResult(_context.TeamFieldingTotals.Count());
    }

    public async Task<List<TeamFieldingTotal>> GetAll(int pageNumber, int pageSize) => await _context.TeamFieldingTotals
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<TeamFieldingTotal?> GetById(string teamId, short yearId, string lgId)
    {
        return await _context.TeamFieldingTotals.FindAsync(teamId, yearId, lgId);
    }
}