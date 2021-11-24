using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IFieldingOfsplitRepository : IDisposable
{
    Task<int> GetTotalCount();
    Task<List<FieldingOfsplit>> GetAll(int pageNumber, int pageSize);
    Task<FieldingOfsplit?> GetById(string playerId, string teamId, short yearId, string lgId, short stint, string pos);
    Task<List<FieldingOfsplit>> GetByPlayerId(string playerId);
}