using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IFieldingPostRepository : IDisposable
{
    Task<List<FieldingPost>> GetAll();
    Task<FieldingPost?> GetById(string playerId, string teamId, short yearId, string lgId, string round, string pos);
}