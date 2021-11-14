using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IAllstarFullRepository : IDisposable
{
    Task<int> GetTotalCount();
    Task<List<AllstarFull>> GetAll(int pageNumber, int pageSize);
    Task<AllstarFull?> GetById(string playerId, string teamId, string lgId, short yearId, string gameId);
}