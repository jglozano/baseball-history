using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface ISchoolRepository : IDisposable
{
    Task<int> GetTotalCount();
    Task<List<School>> GetAll(int pageNumber, int pageSize);
    Task<School?> GetById(string schoolId);
}