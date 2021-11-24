using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface ICollegePlayingRepository : IDisposable
{
    Task<int> GetTotalCount();
    Task<List<CollegePlaying>> GetAll(int pageNumber, int pageSize);
    Task<CollegePlaying?> GetById(string playerId, short yearId, string schoolId);
    Task<List<CollegePlaying>> GetByPlayerId(string playerId);
}