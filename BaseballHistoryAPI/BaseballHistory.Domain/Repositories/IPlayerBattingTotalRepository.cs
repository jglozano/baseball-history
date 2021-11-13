using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IPlayerBattingTotalRepository : IDisposable
{
    Task<List<PlayerBattingTotal>> GetAll();
    Task<PlayerBattingTotal?> GetById(string playerId);
}