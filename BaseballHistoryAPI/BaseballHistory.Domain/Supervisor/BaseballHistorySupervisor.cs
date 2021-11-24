using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Repositories;

namespace BaseballHistory.Domain.Supervisor;

public class BaseballHistorySupervisor : IBaseballHistorySupervisor
{
    private readonly IAllstarFullRepository _allstarFullRepository;
    private readonly IAppearanceRepository _appearanceRepository;
    private readonly IAwardsManagerRepository _awardsManagerRepository;
    private readonly IAwardsPlayerRepository _awardsPlayerRepository;
    private readonly IAwardsShareManagerRepository _awardsShareManagerRepository;
    private readonly IAwardsSharePlayerRepository _awardsSharePlayerRepository;
    private readonly IBattingRepository _battingRepository;
    private readonly IBattingPostRepository _battingPostRepository;
    private readonly ICollegePlayingRepository _collegePlayingRepository;
    private readonly IFieldingRepository _fieldingRepository;
    private readonly IFieldingOfRepository _fieldingOfRepository;
    private readonly IFieldingOfsplitRepository _fieldingOfsplitRepository;
    private readonly IFieldingPostRepository _fieldingPostRepository;
    private readonly IHallOfFameRepository _hallOfFameRepository;
    private readonly IHomeGameRepository _homeGameRepository;
    private readonly IManagerRepository _managerRepository;
    private readonly IManagersHalfRepository _managersHalfRepository;
    private readonly IParkRepository _parkRepository;
    private readonly IPersonRepository _personRepository;
    private readonly IPitchingRepository _pitchingRepository;
    private readonly IPitchingPostRepository _pitchingPostRepository;
    private readonly IPlayerBattingTotalRepository _playerBattingTotalRepository;
    private readonly IPlayerFieldingTotalRepository _playerFieldingTotalRepository;
    private readonly IPlayerPitchingTotalRepository _playerPitchingTotalRepository;
    private readonly ISalaryRepository _salaryRepository;
    private readonly ISchoolRepository _schoolRepository;
    private readonly ISeriesPostRepository _seriesPostRepository;
    private readonly ITeamRepository _teamRepository;
    private readonly ITeamBattingTotalRepository _teamBattingTotalRepository;
    private readonly ITeamFieldingTotalRepository _teamFieldingTotalRepository;
    private readonly ITeamPitchingTotalRepository _teamPitchingTotalRepository;
    private readonly ITeamsFranchiseRepository _teamsFranchiseRepository;
    private readonly ITeamsHalfRepository _teamsHalfRepository;

    public BaseballHistorySupervisor(
        IAllstarFullRepository allstarFullRepository, IAppearanceRepository appearanceRepository,
        IAwardsManagerRepository awardsManagerRepository, IAwardsPlayerRepository awardsPlayerRepository,
        IAwardsSharePlayerRepository awardsSharePlayerRepository,
        IAwardsShareManagerRepository awardsShareManagerRepository, IBattingRepository battingRepository,
        IBattingPostRepository battingPostRepository, ICollegePlayingRepository collegePlayingRepository,
        IFieldingRepository fieldingRepository, IFieldingOfRepository fieldingOfRepository,
        IFieldingOfsplitRepository fieldingOfsplitRepository, IFieldingPostRepository fieldingPostRepository,
        IHallOfFameRepository hallOfFameRepository, IHomeGameRepository homeGameRepository,
        IManagerRepository managerRepository, IManagersHalfRepository managersHalfRepository,
        IParkRepository parkRepository, IPersonRepository personRepository, IPitchingRepository pitchingRepository,
        IPitchingPostRepository pitchingPostRepository, IPlayerBattingTotalRepository playerBattingTotalRepository,
        IPlayerFieldingTotalRepository playerFieldingTotalRepository,
        IPlayerPitchingTotalRepository playerPitchingTotalRepository, ISalaryRepository salaryRepository,
        ISchoolRepository schoolRepository, ISeriesPostRepository seriesPostRepository, ITeamRepository teamRepository,
        ITeamBattingTotalRepository teamBattingTotalRepository,
        ITeamFieldingTotalRepository teamFieldingTotalRepository,
        ITeamPitchingTotalRepository teamPitchingTotalRepository, ITeamsFranchiseRepository teamsFranchiseRepository,
        ITeamsHalfRepository teamsHalfRepository)
    {
        _allstarFullRepository = allstarFullRepository;
        _appearanceRepository = appearanceRepository;
        _awardsManagerRepository = awardsManagerRepository;
        _awardsPlayerRepository = awardsPlayerRepository;
        _awardsSharePlayerRepository = awardsSharePlayerRepository;
        _awardsShareManagerRepository = awardsShareManagerRepository;
        _battingRepository = battingRepository;
        _battingPostRepository = battingPostRepository;
        _collegePlayingRepository = collegePlayingRepository;
        _fieldingRepository = fieldingRepository;
        _fieldingOfRepository = fieldingOfRepository;
        _fieldingOfsplitRepository = fieldingOfsplitRepository;
        _fieldingPostRepository = fieldingPostRepository;
        _hallOfFameRepository = hallOfFameRepository;
        _homeGameRepository = homeGameRepository;
        _managerRepository = managerRepository;
        _managersHalfRepository = managersHalfRepository;
        _parkRepository = parkRepository;
        _personRepository = personRepository;
        _pitchingRepository = pitchingRepository;
        _pitchingPostRepository = pitchingPostRepository;
        _playerBattingTotalRepository = playerBattingTotalRepository;
        _playerFieldingTotalRepository = playerFieldingTotalRepository;
        _playerPitchingTotalRepository = playerPitchingTotalRepository;
        _salaryRepository = salaryRepository;
        _schoolRepository = schoolRepository;
        _seriesPostRepository = seriesPostRepository;
        _teamRepository = teamRepository;
        _teamBattingTotalRepository = teamBattingTotalRepository;
        _teamFieldingTotalRepository = teamFieldingTotalRepository;
        _teamPitchingTotalRepository = teamPitchingTotalRepository;
        _teamsFranchiseRepository = teamsFranchiseRepository;
        _teamsHalfRepository = teamsHalfRepository;
    }

    public Task<int> GetAllStarCount()
    {
        return _allstarFullRepository.GetTotalCount();
    }

    public async Task<List<AllstarFull>> GetAllstarFull(int pageNumber, int pageSize) => await _allstarFullRepository.GetAll(pageNumber, pageSize);

    public async Task<AllstarFull?> GetAllstarFullById(string playerId, string teamId, string lgId, short yearId,
        string gameId)
    {
        return await _allstarFullRepository.GetById(playerId, teamId, lgId, yearId, gameId);
    }

    public async Task<List<AllstarFull>> GetAllstarFullByPlayerId(string playerId)
    {
        return await _allstarFullRepository.GetByPlayerId(playerId);
    }

    public Task<int> GetAppearanceCount()
    {
        return _appearanceRepository.GetTotalCount();
    }

    public async Task<List<Appearance>> GetAppearance(int pageNumber, int pageSize) => await _appearanceRepository.GetAll(pageNumber, pageSize);

    public async Task<Appearance?> GetAppearanceById(string playerId, short yearId, string lgId, string teamId)
    {
        return await _appearanceRepository.GetById(playerId, yearId, lgId, teamId);
    }

    public async Task<List<Appearance>> GetAppearanceByPlayerId(string playerId)
    {
        return await _appearanceRepository.GetByPlayerId(playerId);
    }

    public Task<int> GetAwardsManagerCount()
    {
        return _awardsManagerRepository.GetTotalCount();
    }

    public async Task<List<AwardsManager>> GetAwardsManager(int pageNumber, int pageSize) => await _awardsManagerRepository.GetAll(pageNumber, pageSize);

    public async Task<AwardsManager?> GetAwardsManagerById(string playerId, short yearId, string lgId, string awardId)
    {
        return await _awardsManagerRepository.GetById(playerId, yearId, lgId, awardId);
    }

    public async Task<List<AwardsManager>> GetAwardsManagerByPlayerId(string playerId)
    {
        return await _awardsManagerRepository.GetByPlayerId(playerId);
    }

    public Task<int> GetAwardsPlayerCount()
    {
        return _awardsPlayerRepository.GetTotalCount();
    }

    public async Task<List<AwardsPlayer>> GetAwardsPlayer(int pageNumber, int pageSize) => await _awardsPlayerRepository.GetAll(pageNumber, pageSize);

    public async Task<AwardsPlayer?> GetAwardsPlayerById(string playerId, short yearId, string lgId, string awardId)
    {
        return await _awardsPlayerRepository.GetById(playerId, yearId, lgId, awardId);
    }

    public async Task<List<AwardsPlayer>> GetAwardsPlayerByPlayerId(string playerId)
    {
        return await _awardsPlayerRepository.GetByPlayerId(playerId);
    }

    public Task<int> GetAwardsShareManagerCount()
    {
        return _awardsShareManagerRepository.GetTotalCount();
    }

    public async Task<List<AwardsShareManager>> GetAwardsShareManager(int pageNumber, int pageSize) => await _awardsShareManagerRepository.GetAll(pageNumber, pageSize);

    public async Task<AwardsShareManager?> GetAwardsShareManagerById(string playerId, short yearId, string lgId, string awardId)
    {
        return await _awardsShareManagerRepository.GetById(playerId, yearId, lgId, awardId);
    }

    public async Task<List<AwardsShareManager>> GetAwardsShareManagerByPlayerId(string playerId)
    {
        return await _awardsShareManagerRepository.GetByPlayerId(playerId);
    }

    public Task<int> GetAwardsSharePlayerCount(int pageNumber, int pageSize)
    {
        return _awardsSharePlayerRepository.GetTotalCount();
    }

    public Task<int> GetAwardsSharePlayerCount()
    {
        return _awardsSharePlayerRepository.GetTotalCount();
    }

    public async Task<List<AwardsSharePlayer>> GetAwardsSharePlayer(int pageNumber, int pageSize) => await _awardsSharePlayerRepository.GetAll(pageNumber, pageSize);

    public async Task<AwardsSharePlayer?> GetAwardsSharePlayerById(string playerId, short yearId, string lgId, string awardId)
    {
        return await _awardsSharePlayerRepository.GetById(playerId, yearId, lgId, awardId);
    }

    public async Task<List<AwardsSharePlayer>> GetAwardsSharePlayerByPlayerId(string playerId)
    {
        return await _awardsSharePlayerRepository.GetByPlayerId(playerId);
    }

    public Task<int> GetBattingCount()
    {
        return _battingRepository.GetTotalCount();
    }

    public async Task<List<Batting>> GetBatting(int pageNumber, int pageSize) => await _battingRepository.GetAll(pageNumber, pageSize);

    public async Task<Batting?> GetBattingById(string playerId, string teamId, short yearId, string lgId, short stint)
    {
        return await _battingRepository.GetById(playerId, teamId, yearId, lgId, stint);
    }

    public async Task<List<Batting>> GetBattingByPlayerId(string playerId)
    {
        return await _battingRepository.GetByPlayerId(playerId);
    }

    public Task<int> GetBattingPostCount()
    {
        return _battingPostRepository.GetTotalCount();
    }

    public async Task<List<BattingPost>> GetBattingPost(int pageNumber, int pageSize) => await _battingPostRepository.GetAll(pageNumber, pageSize);

    public async Task<BattingPost?> GetBattingPostById(string playerId, string teamId, short yearId, string lgId, string round)
    {
        return await _battingPostRepository.GetById(playerId, teamId, yearId, lgId, round);
    }

    public async Task<List<BattingPost>> GetBattingPostByPlayerId(string playerId)
    {
        return await _battingPostRepository.GetByPlayerId(playerId);
    }

    public Task<int> GetCollegePlayingCount()
    {
        return _collegePlayingRepository.GetTotalCount();
    }

    public async Task<List<CollegePlaying>> GetCollegePlaying(int pageNumber, int pageSize) => await _collegePlayingRepository.GetAll(pageNumber, pageSize);

    public async Task<CollegePlaying?> GetCollegePlayingById(string playerId, short yearId, string schoolId)
    {
        return await _collegePlayingRepository.GetById(playerId, yearId, schoolId);
    }

    public async Task<List<CollegePlaying>> GetCollegePlayingByPlayerId(string playerId)
    {
        return await _collegePlayingRepository.GetByPlayerId(playerId);
    }

    public Task<int> GetFieldingCount()
    {
        return _fieldingRepository.GetTotalCount();
    }

    public async Task<List<Fielding>> GetFielding(int pageNumber, int pageSize) => await _fieldingRepository.GetAll(pageNumber, pageSize);

    public async Task<Fielding?> GetFieldingById(string playerId, string teamId, short yearId, string lgId, short stint, string pos)
    {
        return await _fieldingRepository.GetById(playerId, teamId, yearId, lgId, stint, pos);
    }

    public async Task<List<Fielding>> GetFieldingByPlayerId(string playerId)
    {
        return await _fieldingRepository.GetByPlayerId(playerId);
    }

    public Task<int> GetFieldingOfCount()
    {
        return _fieldingOfRepository.GetTotalCount();
    }

    public async Task<List<FieldingOf>> GetFieldingOf(int pageNumber, int pageSize) => await _fieldingOfRepository.GetAll(pageNumber, pageSize);

    public async Task<FieldingOf?> GetFieldingOfById(string playerId, short yearId, short stint)
    {
        return await _fieldingOfRepository.GetById(playerId, yearId, stint);
    }

    public async Task<List<FieldingOf>> GetFieldingOfByPlayerId(string playerId)
    {
        return await _fieldingOfRepository.GetByPlayerId(playerId);
    }

    public Task<int> GetFieldingOfsplitCount()
    {
        return _fieldingOfsplitRepository.GetTotalCount();
    }

    public async Task<List<FieldingOfsplit>> GetFieldingOfsplit(int pageNumber, int pageSize) => await _fieldingOfsplitRepository.GetAll(pageNumber, pageSize);

    public async Task<FieldingOfsplit?> GetFieldingOfsplitById(string playerId, string teamId, short yearId, string lgId, short stint, string pos)
    {
        return await _fieldingOfsplitRepository.GetById(playerId, teamId, yearId, lgId, stint, pos);
    }

    public async Task<List<FieldingOfsplit>> GetFieldingOfsplitByPlayerId(string playerId)
    {
        return await _fieldingOfsplitRepository.GetByPlayerId(playerId);
    }

    public Task<int> GetFieldingPostCount()
    {
        return _fieldingPostRepository.GetTotalCount();
    }

    public async Task<List<FieldingPost>> GetFieldingPost(int pageNumber, int pageSize) => await _fieldingPostRepository.GetAll(pageNumber, pageSize);

    public async Task<FieldingPost?> GetFieldingPostById(string playerId, string teamId, short yearId, string lgId, string round, string pos)
    {
        return await _fieldingPostRepository.GetById(playerId, teamId, yearId, lgId, round, pos);
    }

    public async Task<List<FieldingPost>> GetFieldingPostByPlayerId(string playerId)
    {
        return await _fieldingPostRepository.GetByPlayerId(playerId);
    }

    public Task<int> GetHallOfFameCount()
    {
        return _hallOfFameRepository.GetTotalCount();
    }

    public async Task<List<HallOfFame>> GetHallOfFame(int pageNumber, int pageSize) => await _hallOfFameRepository.GetAll(pageNumber, pageSize);

    public async Task<HallOfFame?> GetHallOfFameById(string playerId, short yearId, string votedBy)
    {
        return await _hallOfFameRepository.GetById(playerId, yearId, votedBy);
    }

    public async Task<List<HallOfFame>> GetHallOfFameByPlayerId(string playerId)
    {
        return await _hallOfFameRepository.GetByPlayerId(playerId);
    }

    public Task<int> GetHomeGameCount()
    {
        return _homeGameRepository.GetTotalCount();
    }

    public async Task<List<HomeGame>> GetHomeGame(int pageNumber, int pageSize) => await _homeGameRepository.GetAll(pageNumber, pageSize);

    public async Task<HomeGame?> GetHomeGameById(string teamId, string lgId, short yearId, string parkId)
    {
        return await _homeGameRepository.GetById(teamId, lgId, yearId, parkId);
    }

    public async Task<List<HomeGame>> GetHomeGameByTeamId(string teamId, string lgId, short yearId)
    {
        return await _homeGameRepository.GetByTeamId(teamId, lgId, yearId);
    }

    public Task<int> GetManagerCount()
    {
        return _managerRepository.GetTotalCount();
    }

    public async Task<List<Manager>> GetManager(int pageNumber, int pageSize) => await _managerRepository.GetAll(pageNumber, pageSize);

    public async Task<Manager?> GetManagerById(string playerId, string teamId, short yearId, string lgId, short inseason)
    {
        return await _managerRepository.GetById(playerId, teamId, yearId, lgId, inseason);
    }

    public async Task<List<Manager>> GetManagerByPlayerId(string playerId)
    {
        return await _managerRepository.GetByPlayerId(playerId);
    }

    public Task<int> GetManagersHalfCount()
    {
        return _managersHalfRepository.GetTotalCount();
    }

    public async Task<List<ManagersHalf>> GetManagersHalf(int pageNumber, int pageSize) => await _managersHalfRepository.GetAll(pageNumber, pageSize);

    public async Task<ManagersHalf?> GetManagersHalfById(string playerId, string teamId, short yearId, string lgId, short inseason, short half)
    {
        return await _managersHalfRepository.GetById(playerId, teamId, yearId, lgId, inseason, half);
    }

    public async Task<List<ManagersHalf>> GetManagersHalfByPlayerId(string playerId)
    {
        return await _managersHalfRepository.GetByPlayerId(playerId);
    }

    public Task<int> GetParkCount()
    {
        return _parkRepository.GetTotalCount();
    }

    public async Task<List<Park>> GetPark(int pageNumber, int pageSize) => await _parkRepository.GetAll(pageNumber, pageSize);

    public async Task<Park?> GetParkById(string parkId)
    {
        return await _parkRepository.GetById(parkId);
    }

    public Task<int> GetPersonCount()
    {
        return _personRepository.GetTotalCount();
    }

    public async Task<List<Person>> GetPerson(int pageNumber, int pageSize) => await _personRepository.GetAll(pageNumber, pageSize);

    public async Task<Person?> GetPersonById(string playerId)
    {
        return await _personRepository.GetById(playerId);
    }

    public async Task<List<Person>> GetPersonByLastName(string lastName)
    {
        return await _personRepository.GetPlayerByLastName(lastName);
    }

    public Task<int> GetPitchingCount()
    {
        return _pitchingRepository.GetTotalCount();
    }

    public async Task<List<Pitching>> GetPitching(int pageNumber, int pageSize) => await _pitchingRepository.GetAll(pageNumber, pageSize);

    public async Task<Pitching?> GetPitchingById(string playerId, string teamId, short yearId, string lgId, short stint)
    {
        return await _pitchingRepository.GetById(playerId, teamId, yearId, lgId, stint);
    }

    public async Task<List<Pitching>> GetPitchingByPlayerId(string playerId)
    {
        return await _pitchingRepository.GetByPlayerId(playerId);
    }

    public Task<int> GetPitchingPostCount()
    {
        return _pitchingPostRepository.GetTotalCount();
    }

    public async Task<List<PitchingPost>> GetPitchingPost(int pageNumber, int pageSize) => await _pitchingPostRepository.GetAll(pageNumber, pageSize);

    public async Task<PitchingPost?> GetPitchingPostById(string playerId, string teamId, short yearId, string lgId, string round)
    {
        return await _pitchingPostRepository.GetById(playerId, teamId, yearId, lgId, round);
    }

    public async Task<List<PitchingPost>> GetPitchingPostByPlayerId(string playerId)
    {
        return await _pitchingPostRepository.GetByPlayerId(playerId);
    }

    public Task<int> GetPlayerBattingTotalCount()
    {
        return _playerBattingTotalRepository.GetTotalCount();
    }

    public async Task<List<PlayerBattingTotal>> GetPlayerBattingTotal(int pageNumber, int pageSize) => await _playerBattingTotalRepository.GetAll(pageNumber, pageSize);

    public async Task<PlayerBattingTotal?> GetPlayerBattingTotalById(string playerId)
    {
        return await _playerBattingTotalRepository.GetById(playerId);
    }

    public Task<int> GetPlayerFieldingTotalCount()
    {
        return _playerFieldingTotalRepository.GetTotalCount();
    }

    public async Task<List<PlayerFieldingTotal>> GetPlayerFieldingTotal(int pageNumber, int pageSize) => await _playerFieldingTotalRepository.GetAll(pageNumber, pageSize);

    public async Task<PlayerFieldingTotal?> GetPlayerFieldingTotalById(string playerId)
    {
        return await _playerFieldingTotalRepository.GetById(playerId);
    }

    public Task<int> GetPlayerPitchingTotalCount()
    {
        return _playerPitchingTotalRepository.GetTotalCount();
    }

    public async Task<List<PlayerPitchingTotal>> GetPlayerPitchingTotal(int pageNumber, int pageSize) => await _playerPitchingTotalRepository.GetAll(pageNumber, pageSize);

    public async Task<PlayerPitchingTotal?> GetPlayerPitchingTotalById(string playerId)
    {
        return await _playerPitchingTotalRepository.GetById(playerId);
    }

    public Task<int> GetSalaryCount()
    {
        return _salaryRepository.GetTotalCount();
    }

    public async Task<List<Salary>> GetSalary(int pageNumber, int pageSize) => await _salaryRepository.GetAll(pageNumber, pageSize);

    public async Task<Salary?> GetSalaryById(string playerId, string teamId, short yearId, string lgId)
    {
        return await _salaryRepository.GetById(playerId, teamId, yearId, lgId);
    }

    public async Task<List<Salary>> GetSalaryByPlayerId(string playerId)
    {
        return await _salaryRepository.GetByPlayerId(playerId);
    }

    public Task<int> GetSchoolCount()
    {
        return _schoolRepository.GetTotalCount();
    }

    public async Task<List<School>> GetSchool(int pageNumber, int pageSize) => await _schoolRepository.GetAll(pageNumber, pageSize);

    public async Task<School?> GetSchoolById(string schoolId)
    {
        return await _schoolRepository.GetById(schoolId);
    }

    public Task<int> GetSeriesPostCount()
    {
        return _seriesPostRepository.GetTotalCount();
    }

    public async Task<List<SeriesPost>> GetSeriesPost(int pageNumber, int pageSize) => await _seriesPostRepository.GetAll(pageNumber, pageSize);

    public async Task<SeriesPost?> GetSeriesPostById(string teamIdwinner, string lgIdwinner, short yearId, string round)
    {
        return await _seriesPostRepository.GetById(teamIdwinner, lgIdwinner, yearId, round);
    }

    public async Task<List<SeriesPost>> GetSeriesPostByTeamId(string teamId)
    {
        return await _seriesPostRepository.GetByTeamId(teamId);
    }

    public Task<int> GetTeamCount()
    {
        return _teamRepository.GetTotalCount();
    }

    public async Task<List<Team>> GetTeam(int pageNumber, int pageSize) => await _teamRepository.GetAll(pageNumber, pageSize);

    public async Task<Team?> GetTeamById(string teamId, short yearId, string lgId)
    {
        return await _teamRepository.GetById(teamId, yearId, lgId);
    }

    public async Task<List<Team>> GetTeamByFranchId(string franchId)
    {
        return await _teamRepository.GetTeamByFranchId(franchId);
    }

    public Task<int> GetTeamBattingTotalCount()
    {
        return _teamBattingTotalRepository.GetTotalCount();
    }

    public async Task<List<TeamBattingTotal>> GetTeamBattingTotal(int pageNumber, int pageSize) => await _teamBattingTotalRepository.GetAll(pageNumber, pageSize);

    public async Task<TeamBattingTotal?> GetTeamBattingTotalById(string teamId, short yearId, string lgId)
    {
        return await _teamBattingTotalRepository.GetById(teamId, yearId, lgId);
    }

    public async Task<List<TeamBattingTotal>> GetTeamBattingTotalByTeamId(string teamId)
    {
        return await _teamBattingTotalRepository.GetByTeamId(teamId);
    }

    public Task<int> GetTeamFieldingTotalCount()
    {
        return _teamFieldingTotalRepository.GetTotalCount();
    }

    public async Task<List<TeamFieldingTotal>> GetTeamFieldingTotal(int pageNumber, int pageSize) => await _teamFieldingTotalRepository.GetAll(pageNumber, pageSize);

    public async Task<TeamFieldingTotal?> GetTeamFieldingTotalById(string teamId, short yearId, string lgId)
    {
        return await _teamFieldingTotalRepository.GetById(teamId, yearId, lgId);
    }

    public async Task<List<TeamFieldingTotal>> GetTeamFieldingTotalByTeamId(string teamId)
    {
        return await _teamFieldingTotalRepository.GetByTeamId(teamId);
    }

    public Task<int> GetTeamPitchingTotalCount()
    {
        return _teamPitchingTotalRepository.GetTotalCount();
    }

    public async Task<List<TeamPitchingTotal>> GetTeamPitchingTotal(int pageNumber, int pageSize) => await _teamPitchingTotalRepository.GetAll(pageNumber, pageSize);

    public async Task<TeamPitchingTotal?> GetTeamPitchingTotalById(string teamId, short yearId, string lgId)
    {
        return await _teamPitchingTotalRepository.GetById(teamId, yearId, lgId);
    }

    public async Task<List<TeamPitchingTotal>> GetTeamPitchingTotalByTeamId(string teamId)
    {
        return await _teamPitchingTotalRepository.GetByTeamId(teamId);
    }

    public Task<int> GetTeamsFranchiseCount()
    {
        return _teamsFranchiseRepository.GetTotalCount();
    }
    
    public async Task<List<TeamsFranchise>> GetTeamsFranchise(int pageNumber, int pageSize) => await _teamsFranchiseRepository.GetAll(pageNumber, pageSize);

    public async Task<TeamsFranchise?> GetTeamsFranchiseById(string franchId)
    {
        return await _teamsFranchiseRepository.GetById(franchId);
    }

    public Task<int> GetTeamsHalfCount()
    {
        return _teamsHalfRepository.GetTotalCount();
    }

    public async Task<List<TeamsHalf>> GetTeamsHalf(int pageNumber, int pageSize) => await _teamsHalfRepository.GetAll(pageNumber, pageSize);

    public async Task<TeamsHalf?> GetTeamsHalfById(string teamId, short yearId, string lgId, string half)
    {
        return await _teamsHalfRepository.GetById(teamId, yearId, lgId, half);
    }

    public async Task<List<TeamsHalf>> GetTeamsHalfByTeamId(string teamId)
    {
        return await _teamsHalfRepository.GetByTeamId(teamId);
    }
}