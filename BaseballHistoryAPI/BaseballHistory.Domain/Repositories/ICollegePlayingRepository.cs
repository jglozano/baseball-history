using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface ICollegePlayingRepository : IDisposable
{
    Task<List<CollegePlaying>> GetAll();
    Task<CollegePlaying?> GetById(string playerId, short yearId, string schoolId);
}