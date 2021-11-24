using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IFieldingPostRepository : IDisposable
{
    Task<int> GetTotalCount();
    Task<List<FieldingPost>> GetAll(int pageNumber, int pageSize);
    Task<FieldingPost?> GetById(string playerId, string teamId, short yearId, string lgId, string round, string pos);
    Task<List<FieldingPost>> GetByPlayerId(string playerId);
}