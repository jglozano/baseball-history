using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IBattingPostRepository : IDisposable
{
    Task<List<BattingPost>> GetAll();
    Task<BattingPost?> GetById(string playerId, string teamId, short yearId, string lgId, string round);
}