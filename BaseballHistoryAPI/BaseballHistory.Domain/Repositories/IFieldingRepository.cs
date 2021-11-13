using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IFieldingRepository : IDisposable
{
    Task<List<Fielding>> GetAll();
    Task<Fielding?> GetById(string playerId, string teamId, short yearId, string lgId, short stint, string pos);
}