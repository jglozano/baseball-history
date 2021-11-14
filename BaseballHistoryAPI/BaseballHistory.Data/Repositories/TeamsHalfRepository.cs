using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Data.Repositories;

public class TeamsHalfRepository : ITeamsHalfRepository
{
    private readonly BaseballStatsContext _context;

    public TeamsHalfRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public Task<int> GetTotalCount()
    {
        return Task.FromResult(_context.TeamsHalves.Count());
    }

    public async Task<List<TeamsHalf>> GetAll(int pageNumber, int pageSize) => await _context.TeamsHalves
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<TeamsHalf?> GetById(string teamId, short yearId, string lgId, string half)
    {
        return await _context.TeamsHalves.FindAsync(teamId, yearId, lgId, lgId, half);
    }
}