using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IPersonRepository : IDisposable
{
    Task<List<Person>> GetAll();
    Task<Person?> GetById(string playerId);
}