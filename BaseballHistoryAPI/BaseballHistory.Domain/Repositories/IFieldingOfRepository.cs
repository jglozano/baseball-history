using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IFieldingOfRepository : IDisposable
{
    Task<List<FieldingOf>> GetAll();
    Task<FieldingOf?> GetById(string playerId, short yearId, short stint);
}