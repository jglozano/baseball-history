using System.ComponentModel.DataAnnotations;

namespace BaseballHistory.Domain.Entities
{
    public class AwardsPlayer
    {
        [Key]
        public string PlayerId { get; set; } = null!;
        [Key]
        public string LgId { get; set; } = null!;
        [Key]
        public short YearId { get; set; }
        [Key]
        public string AwardId { get; set; } = null!;
        public string? Tie { get; set; }
        public string? Notes { get; set; }

        public virtual Person Player { get; set; } = null!;
    }
}
