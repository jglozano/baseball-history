using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IAwardsShareManagerRepository : IDisposable
{
    Task<int> GetTotalCount();
    Task<List<AwardsShareManager>> GetAll(int pageNumber, int pageSize);
    Task<AwardsShareManager?> GetById(string playerId, short yearId, string lgId, string awardId);
}