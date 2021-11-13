using System.ComponentModel.DataAnnotations;

namespace BaseballHistory.Domain.Entities
{
    public class AllstarFull
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
        public string GameId { get; set; } = null!;
        public short? GameNum { get; set; }
        public short? Gp { get; set; }
        public short? StartingPos { get; set; }

        public virtual Person Player { get; set; } = null!;
        public virtual Team Team { get; set; } = null!;
    }
}
