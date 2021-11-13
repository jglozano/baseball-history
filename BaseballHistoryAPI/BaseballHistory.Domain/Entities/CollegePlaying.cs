using System.ComponentModel.DataAnnotations;

namespace BaseballHistory.Domain.Entities
{
    public class CollegePlaying
    {
        [Key]
        public string PlayerId { get; set; } = null!;
        [Key]
        public short YearId { get; set; }
        [Key]
        public string SchoolId { get; set; } = null!;

        public virtual Person Player { get; set; } = null!;
        public virtual School School { get; set; } = null!;
    }
}
