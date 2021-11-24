using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IAwardsSharePlayerRepository : IDisposable
{
    Task<int> GetTotalCount();
    Task<List<AwardsSharePlayer>> GetAll(int pageNumber, int pageSize);
    Task<AwardsSharePlayer?> GetById(string playerId, short yearId, string lgId, string awardId);
    Task<List<AwardsSharePlayer>> GetByPlayerId(string playerId);
}