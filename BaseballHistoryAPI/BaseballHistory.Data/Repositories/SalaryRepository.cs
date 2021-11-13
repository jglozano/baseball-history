using BaseballHistory.Data;
using BaseballHistory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Domain.Repositories;

public class SalaryRepository : ISalaryRepository
{
    private readonly BaseballStatsContext _context;

    public SalaryRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public async Task<List<Salary>> GetAll() => await _context.Salaries.AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<Salary?> GetById(string playerId, string teamId, short yearId, string lgId)
    {
        return await _context.Salaries.FindAsync(playerId, teamId, yearId, lgId);
    }
}