using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IFieldingRepository : IDisposable
{
    Task<int> GetTotalCount();
    Task<List<Fielding>> GetAll(int pageNumber, int pageSize);
    Task<Fielding?> GetById(string playerId, string teamId, short yearId, string lgId, short stint, string pos);
}