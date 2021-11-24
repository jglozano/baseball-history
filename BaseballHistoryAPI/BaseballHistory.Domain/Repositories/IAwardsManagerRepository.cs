using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IAwardsManagerRepository : IDisposable
{
    Task<int> GetTotalCount();
    Task<List<AwardsManager>> GetAll(int pageNumber, int pageSize);
    Task<AwardsManager?> GetById(string playerId, short yearId, string lgId, string awardId);
    Task<List<AwardsManager>> GetByPlayerId(string playerId);
}