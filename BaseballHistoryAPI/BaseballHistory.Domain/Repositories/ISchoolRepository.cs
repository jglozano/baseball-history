using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface ISchoolRepository : IDisposable
{
    Task<List<School>> GetAll();
    Task<School?> GetById(string schoolId);
}