using System.ComponentModel.DataAnnotations;

namespace BaseballHistory.Domain.Entities
{
    public class Salary
    {
        [Key]
        public string PlayerId { get; set; } = null!;
        [Key]
        public string TeamId { get; set; } = null!;
        [Key]
        public string LgId { get; set; } = null!;
        [Key]
        public short YearId { get; set; }
        public int? Salary1 { get; set; }

        public virtual Person Player { get; set; } = null!;
        public virtual Team Team { get; set; } = null!;
    }
}
