using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface ISalaryRepository : IDisposable
{
    Task<List<Salary>> GetAll();
    Task<Salary?> GetById(string playerId, string teamId, short yearId, string lgId);
}