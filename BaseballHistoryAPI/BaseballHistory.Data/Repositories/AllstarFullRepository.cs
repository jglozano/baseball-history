using BaseballHistory.Data;
using BaseballHistory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Domain.Repositories;

public class AllstarFullRepository : IAllstarFullRepository
{
    private readonly BaseballStatsContext _context;

    public AllstarFullRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public async Task<List<AllstarFull>> GetAll() => await _context.AllstarFulls.AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<AllstarFull?> GetById(string playerId, string teamId, string lgId, short yearId, string gameId)
    {
        return await _context.AllstarFulls.FindAsync(playerId, teamId, lgId, yearId, gameId);
    }
}