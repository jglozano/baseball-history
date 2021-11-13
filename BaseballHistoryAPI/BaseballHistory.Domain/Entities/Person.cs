using System.ComponentModel.DataAnnotations;

namespace BaseballHistory.Domain.Entities
{
    public class Person
    {
        public Person()
        {
            AllstarFulls = new HashSet<AllstarFull>();
            Appearances = new HashSet<Appearance>();
            AwardsManagers = new HashSet<AwardsManager>();
            AwardsPlayers = new HashSet<AwardsPlayer>();
            AwardsShareManagers = new HashSet<AwardsShareManager>();
            AwardsSharePlayers = new HashSet<AwardsSharePlayer>();
            BattingPosts = new HashSet<BattingPost>();
            Battings = new HashSet<Batting>();
            CollegePlayings = new HashSet<CollegePlaying>();
            FieldingOfs = new HashSet<FieldingOf>();
            FieldingOfsplits = new HashSet<FieldingOfsplit>();
            FieldingPosts = new HashSet<FieldingPost>();
            Fieldings = new HashSet<Fielding>();
            HallOfFames = new HashSet<HallOfFame>();
            Managers = new HashSet<Manager>();
            ManagersHalves = new HashSet<ManagersHalf>();
            PitchingPosts = new HashSet<PitchingPost>();
            Pitchings = new HashSet<Pitching>();
            Salaries = new HashSet<Salary>();
        }

        [Key]
        public string PlayerId { get; set; } = null!;
        public short? BirthYear { get; set; }
        public short? BirthMonth { get; set; }
        public short? BirthDay { get; set; }
        public string? BirthCountry { get; set; }
        public string? BirthState { get; set; }
        public string? BirthCity { get; set; }
        public short? DeathYear { get; set; }
        public short? DeathMonth { get; set; }
        public short? DeathDay { get; set; }
        public string? DeathCountry { get; set; }
        public string? DeathState { get; set; }
        public string? DeathCity { get; set; }
        public string? NameFirst { get; set; }
        public string? NameLast { get; set; }
        public string? NameGiven { get; set; }
        public short? Weight { get; set; }
        public short? Height { get; set; }
        public string? Bats { get; set; }
        public string? Throws { get; set; }
        public DateTime? Debut { get; set; }
        public DateTime? FinalGame { get; set; }

        public virtual ICollection<AllstarFull> AllstarFulls { get; set; }
        public virtual ICollection<Appearance> Appearances { get; set; }
        public virtual ICollection<AwardsManager> AwardsManagers { get; set; }
        public virtual ICollection<AwardsPlayer> AwardsPlayers { get; set; }
        public virtual ICollection<AwardsShareManager> AwardsShareManagers { get; set; }
        public virtual ICollection<AwardsSharePlayer> AwardsSharePlayers { get; set; }
        public virtual ICollection<BattingPost> BattingPosts { get; set; }
        public virtual ICollection<Batting> Battings { get; set; }
        public virtual ICollection<CollegePlaying> CollegePlayings { get; set; }
        public virtual ICollection<FieldingOf> FieldingOfs { get; set; }
        public virtual ICollection<FieldingOfsplit> FieldingOfsplits { get; set; }
        public virtual ICollection<FieldingPost> FieldingPosts { get; set; }
        public virtual ICollection<Fielding> Fieldings { get; set; }
        public virtual ICollection<HallOfFame> HallOfFames { get; set; }
        public virtual ICollection<Manager> Managers { get; set; }
        public virtual ICollection<ManagersHalf> ManagersHalves { get; set; }
        public virtual ICollection<PitchingPost> PitchingPosts { get; set; }
        public virtual ICollection<Pitching> Pitchings { get; set; }
        public virtual ICollection<Salary> Salaries { get; set; }
    }
}
