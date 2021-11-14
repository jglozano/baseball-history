using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IPlayerFieldingTotalRepository : IDisposable
{
    Task<int> GetTotalCount();
    Task<List<PlayerFieldingTotal>> GetAll(int pageNumber, int pageSize);
    Task<PlayerFieldingTotal?> GetById(string playerId);
}