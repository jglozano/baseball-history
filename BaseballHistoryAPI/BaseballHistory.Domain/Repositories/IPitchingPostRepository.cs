using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IPitchingPostRepository : IDisposable
{
    Task<int> GetTotalCount();
    Task<List<PitchingPost>> GetAll(int pageNumber, int pageSize);
    Task<PitchingPost?> GetById(string playerId, string teamId, short yearId, string lgId, string round);
    Task<List<PitchingPost>> GetByPlayerId(string playerId);
}