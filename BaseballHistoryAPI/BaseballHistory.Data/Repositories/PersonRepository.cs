using BaseballHistory.Data;
using BaseballHistory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Domain.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly BaseballStatsContext _context;

    public PersonRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public async Task<List<Person>> GetAll() => await _context.People.AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<Person?> GetById(string playerId)
    {
        return await _context.People.FindAsync(playerId);
    }
}