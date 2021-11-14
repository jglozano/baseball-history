using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IPlayerBattingTotalRepository : IDisposable
{
    Task<int> GetTotalCount();
    Task<List<PlayerBattingTotal>> GetAll(int pageNumber, int pageSize);
    Task<PlayerBattingTotal?> GetById(string playerId);
}