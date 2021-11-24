using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IBattingPostRepository : IDisposable
{
    Task<int> GetTotalCount();
    Task<List<BattingPost>> GetAll(int pageNumber, int pageSize);
    Task<BattingPost?> GetById(string playerId, string teamId, short yearId, string lgId, string round);
    Task<List<BattingPost>> GetByPlayerId(string playerId);
}