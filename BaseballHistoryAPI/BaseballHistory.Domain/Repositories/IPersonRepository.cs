using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IPersonRepository : IDisposable
{
    Task<int> GetTotalCount();
    Task<List<Person>> GetAll(int pageNumber, int pageSize);
    Task<Person?> GetById(string playerId);
}