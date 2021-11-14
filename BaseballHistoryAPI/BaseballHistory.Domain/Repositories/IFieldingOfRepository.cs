using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IFieldingOfRepository : IDisposable
{
    Task<int> GetTotalCount();
    Task<List<FieldingOf>> GetAll(int pageNumber, int pageSize);
    Task<FieldingOf?> GetById(string playerId, short yearId, short stint);
}