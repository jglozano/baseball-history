using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IHomeGameRepository : IDisposable
{
    Task<int> GetTotalCount();
    Task<List<HomeGame>> GetAll(int pageNumber, int pageSize);
    Task<HomeGame?> GetById(string teamId, string lgId, short yearId, string parkId);
}