using BaseballHistory.Data;
using BaseballHistory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Domain.Repositories;

public class SchoolRepository : ISchoolRepository
{
    private readonly BaseballStatsContext _context;

    public SchoolRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public async Task<List<School>> GetAll() => await _context.Schools.AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<School?> GetById(string schoolId)
    {
        return await _context.Schools.FindAsync(schoolId);
    }
}