using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Supervisor;

public interface IBaseballHistorySupervisor
{
    Task<int> GetAllStarCount();
    Task<List<AllstarFull>> GetAllstarFull(int pageNumber, int pageSize);
    Task<AllstarFull?> GetAllstarFullById(string playerId, string teamId, string lgId, short yearId, string gameId);
    Task<List<AllstarFull>> GetAllstarFullByPlayerId(string playerId);

    Task<int> GetAppearanceCount();
    Task<List<Appearance>> GetAppearance(int pageNumber, int pageSize);
    Task<Appearance?> GetAppearanceById(string playerId, short yearId, string lgId, string teamId);
    Task<List<Appearance>> GetAppearanceByPlayerId(string playerId);
    
    Task<int> GetAwardsManagerCount();
    Task<List<AwardsManager>> GetAwardsManager(int pageNumber, int pageSize);
    Task<AwardsManager?> GetAwardsManagerById(string playerId, short yearId, string lgId, string awardId);
    Task<List<AwardsManager>> GetAwardsManagerByPlayerId(string playerId);
    
    Task<int> GetAwardsPlayerCount();
    Task<List<AwardsPlayer>> GetAwardsPlayer(int pageNumber, int pageSize);
    Task<AwardsPlayer?> GetAwardsPlayerById(string playerId, short yearId, string lgId, string awardId);
    Task<List<AwardsPlayer>> GetAwardsPlayerByPlayerId(string playerId);
    
    Task<int> GetAwardsShareManagerCount();
    Task<List<AwardsShareManager>> GetAwardsShareManager(int pageNumber, int pageSize);
    Task<AwardsShareManager?> GetAwardsShareManagerById(string playerId, short yearId, string lgId, string awardId);
    Task<List<AwardsShareManager>> GetAwardsShareManagerByPlayerId(string playerId);
    
    Task<int> GetAwardsSharePlayerCount();
    Task<List<AwardsSharePlayer>> GetAwardsSharePlayer(int pageNumber, int pageSize);
    Task<AwardsSharePlayer?> GetAwardsSharePlayerById(string playerId, short yearId, string lgId, string awardId);
    Task<List<AwardsSharePlayer>> GetAwardsSharePlayerByPlayerId(string playerId);
    
    Task<int> GetBattingCount();
    Task<List<Batting>> GetBatting(int pageNumber, int pageSize);
    Task<Batting?> GetBattingById(string playerId, string teamId, short yearId, string lgId, short stint);
    Task<List<Batting>> GetBattingByPlayerId(string playerId);
    
    Task<int> GetBattingPostCount();
    Task<List<BattingPost>> GetBattingPost(int pageNumber, int pageSize);
    Task<BattingPost?> GetBattingPostById(string playerId, string teamId, short yearId, string lgId, string round);
    Task<List<BattingPost>> GetBattingPostByPlayerId(string playerId);
    
    Task<int> GetCollegePlayingCount();
    Task<List<CollegePlaying>> GetCollegePlaying(int pageNumber, int pageSize);
    Task<CollegePlaying?> GetCollegePlayingById(string playerId, short yearId, string schoolId);
    Task<List<CollegePlaying>> GetCollegePlayingByPlayerId(string playerId);
    
    Task<int> GetFieldingCount();
    Task<List<Fielding>> GetFielding(int pageNumber, int pageSize);
    Task<Fielding?> GetFieldingById(string playerId, string teamId, short yearId, string lgId, short stint, string pos);
    Task<List<Fielding>> GetFieldingByPlayerId(string playerId);
    
    Task<int> GetFieldingOfCount();
    Task<List<FieldingOf>> GetFieldingOf(int pageNumber, int pageSize);
    Task<FieldingOf?> GetFieldingOfById(string playerId, short yearId, short stint);
    Task<List<FieldingOf>> GetFieldingOfByPlayerId(string playerId);
    
    Task<int> GetFieldingOfsplitCount();
    Task<List<FieldingOfsplit>> GetFieldingOfsplit(int pageNumber, int pageSize);
    Task<FieldingOfsplit?> GetFieldingOfsplitById(string playerId, string teamId, short yearId, string lgId, short stint, string pos);
    Task<List<FieldingOfsplit>> GetFieldingOfsplitByPlayerId(string playerId);
    
    Task<int> GetFieldingPostCount();
    Task<List<FieldingPost>> GetFieldingPost(int pageNumber, int pageSize);
    Task<FieldingPost?> GetFieldingPostById(string playerId, string teamId, short yearId, string lgId, string round, string pos);
    Task<List<FieldingPost>> GetFieldingPostByPlayerId(string playerId);
    
    Task<int> GetHallOfFameCount();
    Task<List<HallOfFame>> GetHallOfFame(int pageNumber, int pageSize);
    Task<HallOfFame?> GetHallOfFameById(string playerId, short yearId, string votedBy);
    Task<List<HallOfFame>> GetHallOfFameByPlayerId(string playerId);
    
    Task<int> GetHomeGameCount();
    Task<List<HomeGame>> GetHomeGame(int pageNumber, int pageSize);
    Task<HomeGame?> GetHomeGameById(string teamId, string lgId, short yearId, string parkId);
    Task<List<HomeGame>> GetHomeGameByTeamId(string teamId, string lgId, short yearId);
    
    Task<int> GetManagerCount();
    Task<List<Manager>> GetManager(int pageNumber, int pageSize);
    Task<Manager?> GetManagerById(string playerId, string teamId, short yearId, string lgId, short inseason);
    Task<List<Manager>> GetManagerByPlayerId(string playerId);
    
    Task<int> GetManagersHalfCount();
    Task<List<ManagersHalf>> GetManagersHalf(int pageNumber, int pageSize);
    Task<ManagersHalf?> GetManagersHalfById(string playerId, string teamId, short yearId, string lgId, short inseason, short half);
    Task<List<ManagersHalf>> GetManagersHalfByPlayerId(string playerId);
    
    Task<int> GetParkCount();
    Task<List<Park>> GetPark(int pageNumber, int pageSize);
    Task<Park?> GetParkById(string parkId);
    
    Task<int> GetPersonCount();
    Task<List<Person>> GetPerson(int pageNumber, int pageSize);
    Task<Person?> GetPersonById(string playerId);
    Task<List<Person>> GetPersonByName(string lastName);
    
    Task<int> GetPitchingCount();
    Task<List<Pitching>> GetPitching(int pageNumber, int pageSize);
    Task<Pitching?> GetPitchingById(string playerId, string teamId, short yearId, string lgId, short stint);
    Task<List<Pitching>> GetPitchingByPlayerId(string playerId);
    
    Task<int> GetPitchingPostCount();
    Task<List<PitchingPost>> GetPitchingPost(int pageNumber, int pageSize);
    Task<PitchingPost?> GetPitchingPostById(string playerId, string teamId, short yearId, string lgId, string round);
    Task<List<PitchingPost>> GetPitchingPostByPlayerId(string playerId);
    
    Task<int> GetPlayerBattingTotalCount();
    Task<List<PlayerBattingTotal>> GetPlayerBattingTotal(int pageNumber, int pageSize);
    Task<PlayerBattingTotal?> GetPlayerBattingTotalById(string playerId);
    
    Task<int> GetPlayerFieldingTotalCount();
    Task<List<PlayerFieldingTotal>> GetPlayerFieldingTotal(int pageNumber, int pageSize);
    Task<PlayerFieldingTotal?> GetPlayerFieldingTotalById(string playerId);
    
    Task<int> GetPlayerPitchingTotalCount();
    Task<List<PlayerPitchingTotal>> GetPlayerPitchingTotal(int pageNumber, int pageSize);
    Task<PlayerPitchingTotal?> GetPlayerPitchingTotalById(string playerId);
    
    Task<int> GetSalaryCount();
    Task<List<Salary>> GetSalary(int pageNumber, int pageSize);
    Task<Salary?> GetSalaryById(string playerId, string teamId, short yearId, string lgId);
    Task<List<Salary>> GetSalaryByPlayerId(string playerId);
    
    Task<int> GetSchoolCount();
    Task<List<School>> GetSchool(int pageNumber, int pageSize);
    Task<School?> GetSchoolById(string schoolId);
    
    Task<int> GetSeriesPostCount();
    Task<List<SeriesPost>> GetSeriesPost(int pageNumber, int pageSize);
    Task<SeriesPost?> GetSeriesPostById(string teamIdwinner, string lgIdwinner, short yearId, string round);
    Task<List<SeriesPost>> GetSeriesPostByTeamId(string teamId);
    
    Task<int> GetTeamCount();
    Task<List<Team>> GetTeam(int pageNumber, int pageSize);
    Task<Team?> GetTeamById(string teamId, short yearId, string lgId);
    Task<List<Team>> GetTeamByFranchId(string franchId);
    
    Task<int> GetTeamBattingTotalCount();
    Task<List<TeamBattingTotal>> GetTeamBattingTotal(int pageNumber, int pageSize);
    Task<TeamBattingTotal?> GetTeamBattingTotalById(string teamId, short yearId, string lgId);
    Task<List<TeamBattingTotal>> GetTeamBattingTotalByTeamId(string teamId);
    
    Task<int> GetTeamFieldingTotalCount();
    Task<List<TeamFieldingTotal>> GetTeamFieldingTotal(int pageNumber, int pageSize);
    Task<TeamFieldingTotal?> GetTeamFieldingTotalById(string teamId, short yearId, string lgId);
    Task<List<TeamFieldingTotal>> GetTeamFieldingTotalByTeamId(string teamId);
    
    Task<int> GetTeamPitchingTotalCount();
    Task<List<TeamPitchingTotal>> GetTeamPitchingTotal(int pageNumber, int pageSize);
    Task<TeamPitchingTotal?> GetTeamPitchingTotalById(string teamId, short yearId, string lgId);
    Task<List<TeamPitchingTotal>> GetTeamPitchingTotalByTeamId(string teamId);
    
    Task<int> GetTeamsFranchiseCount();
    Task<List<TeamsFranchise>> GetTeamsFranchise(int pageNumber, int pageSize);
    Task<TeamsFranchise?> GetTeamsFranchiseById(string franchId);
    
    Task<int> GetTeamsHalfCount();
    Task<List<TeamsHalf>> GetTeamsHalf(int pageNumber, int pageSize);
    Task<TeamsHalf?> GetTeamsHalfById(string teamId, short yearId, string lgId, string half);
    Task<List<TeamsHalf>> GetTeamsHalfByTeamId(string teamId);
}