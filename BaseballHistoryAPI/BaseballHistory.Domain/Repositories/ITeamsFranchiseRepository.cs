using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface ITeamsFranchiseRepository : IDisposable
{
    Task<int> GetTotalCount();
    Task<List<TeamsFranchise>> GetAll(int pageNumber, int pageSize);
    Task<TeamsFranchise?> GetById(string franchId);
}