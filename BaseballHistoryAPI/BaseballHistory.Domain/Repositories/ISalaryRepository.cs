using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface ISalaryRepository : IDisposable
{
    Task<int> GetTotalCount();
    Task<List<Salary>> GetAll(int pageNumber, int pageSize);
    Task<Salary?> GetById(string playerId, string teamId, short yearId, string lgId);
    Task<List<Salary>> GetByPlayerId(string playerId);
}