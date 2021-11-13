using BaseballHistory.Data;
using BaseballHistory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Domain.Repositories;

public class ManagerRepository : IManagerRepository
{
    private readonly BaseballStatsContext _context;

    public ManagerRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public async Task<List<Manager>> GetAll() => await _context.Managers.AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<Manager?> GetById(string playerId, string teamId, short yearId, string lgId, short inseason)
    {
        return await _context.Managers.FindAsync(playerId, teamId, yearId, lgId, inseason);
    }
}