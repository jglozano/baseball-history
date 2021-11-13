using System.ComponentModel.DataAnnotations;

namespace BaseballHistory.Domain.Entities
{
    public class Manager
    {
        [Key]
        public string PlayerId { get; set; } = null!;
        [Key]
        public string TeamId { get; set; } = null!;
        [Key]
        public string LgId { get; set; } = null!;
        [Key]
        public short YearId { get; set; }
        [Key]
        public short Inseason { get; set; }
        public short? G { get; set; }
        public short? W { get; set; }
        public short? L { get; set; }
        public short? Rank { get; set; }
        public string? PlyrMgr { get; set; }

        public virtual Person Player { get; set; } = null!;
        public virtual Team Team { get; set; } = null!;
    }
}
