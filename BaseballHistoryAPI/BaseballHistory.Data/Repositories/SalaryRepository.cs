using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Data.Repositories;

public class SalaryRepository : ISalaryRepository
{
    private readonly BaseballStatsContext _context;

    public SalaryRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public Task<int> GetTotalCount()
    {
        return Task.FromResult(_context.Salaries.Count());
    }

    public async Task<List<Salary>> GetAll(int pageNumber, int pageSize) => await _context.Salaries
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<Salary?> GetById(string playerId, string teamId, short yearId, string lgId)
    {
        return await _context.Salaries.FindAsync(playerId, teamId, yearId, lgId);
    }
}