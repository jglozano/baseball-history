using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IFieldingOfsplitRepository : IDisposable
{
    Task<List<FieldingOfsplit>> GetAll();
    Task<FieldingOfsplit?> GetById(string playerId, string teamId, short yearId, string lgId, short stint, string pos);
}