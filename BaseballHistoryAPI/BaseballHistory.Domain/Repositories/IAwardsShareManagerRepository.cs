using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IAwardsShareManagerRepository : IDisposable
{
    Task<List<AwardsShareManager>> GetAll();
    Task<AwardsShareManager?> GetById(string playerId, short yearId, string lgId, string awardId);
}