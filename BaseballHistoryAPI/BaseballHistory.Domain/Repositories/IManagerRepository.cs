using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IManagerRepository : IDisposable
{
    Task<int> GetTotalCount();
    Task<List<Manager>> GetAll(int pageNumber, int pageSize);
    Task<Manager?> GetById(string playerId, string teamId, short yearId, string lgId, short inseason);
}