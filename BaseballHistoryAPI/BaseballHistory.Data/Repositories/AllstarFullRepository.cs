using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Data.Repositories;

public class AllstarFullRepository : IAllstarFullRepository
{
    private readonly BaseballStatsContext _context;

    public AllstarFullRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();
    
    public Task<int> GetTotalCount()
    {
        return Task.FromResult(_context.AllstarFulls.Count());
    }

    public async Task<List<AllstarFull>> GetAll(int pageNumber, int pageSize) => await _context.AllstarFulls
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<AllstarFull?> GetById(string playerId, string teamId, string lgId, short yearId, string gameId)
    {
        return await _context.AllstarFulls.FindAsync(playerId, teamId, lgId, yearId, gameId);
    }
}