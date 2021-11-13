using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IPlayerFieldingTotalRepository : IDisposable
{
    Task<List<PlayerFieldingTotal>> GetAll();
    Task<PlayerFieldingTotal?> GetById(string playerId);
}