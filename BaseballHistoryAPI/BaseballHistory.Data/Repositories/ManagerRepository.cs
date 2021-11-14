using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Data.Repositories;

public class ManagerRepository : IManagerRepository
{
    private readonly BaseballStatsContext _context;

    public ManagerRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public Task<int> GetTotalCount()
    {
        return Task.FromResult(_context.Managers.Count());
    }

    public async Task<List<Manager>> GetAll(int pageNumber, int pageSize) => await _context.Managers
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<Manager?> GetById(string playerId, string teamId, short yearId, string lgId, short inseason)
    {
        return await _context.Managers.FindAsync(playerId, teamId, yearId, lgId, inseason);
    }
}