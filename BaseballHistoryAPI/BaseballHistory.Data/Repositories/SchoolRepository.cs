using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Data.Repositories;

public class SchoolRepository : ISchoolRepository
{
    private readonly BaseballStatsContext _context;

    public SchoolRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public Task<int> GetTotalCount()
    {
        return Task.FromResult(_context.Schools.Count());
    }

    public async Task<List<School>> GetAll(int pageNumber, int pageSize) => await _context.Schools
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<School?> GetById(string schoolId)
    {
        return await _context.Schools.FirstOrDefaultAsync(e => e.SchoolId == schoolId);
    }
}