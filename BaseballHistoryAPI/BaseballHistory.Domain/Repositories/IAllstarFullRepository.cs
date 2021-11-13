using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IAllstarFullRepository : IDisposable
{
    Task<List<AllstarFull>> GetAll();
    Task<AllstarFull?> GetById(string playerId, string teamId, string lgId, short yearId, string gameId);
}