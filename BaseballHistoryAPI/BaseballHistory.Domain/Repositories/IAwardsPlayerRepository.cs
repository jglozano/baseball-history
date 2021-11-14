using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IAwardsPlayerRepository : IDisposable
{
    Task<int> GetTotalCount();
    Task<List<AwardsPlayer>> GetAll(int pageNumber, int pageSize);
    Task<AwardsPlayer?> GetById(string playerId, short yearId, string lgId, string awardId);
}