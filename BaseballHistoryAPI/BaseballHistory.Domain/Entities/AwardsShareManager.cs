using System.ComponentModel.DataAnnotations;

namespace BaseballHistory.Domain.Entities
{
    public class AwardsShareManager
    {
        [Key]
        public string PlayerId { get; set; } = null!;
        [Key]
        public string LgId { get; set; } = null!;
        [Key]
        public short YearId { get; set; }
        [Key]
        public string AwardId { get; set; } = null!;
        public short? PointsWon { get; set; }
        public short? PointsMax { get; set; }
        public short? VotesFirst { get; set; }

        public virtual Person Player { get; set; } = null!;
    }
}
