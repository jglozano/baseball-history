using System.ComponentModel.DataAnnotations;

namespace BaseballHistory.Domain.Entities
{
    public class FieldingOf
    {
        [Key]
        public string PlayerId { get; set; } = null!;
        [Key]
        public short YearId { get; set; }
        [Key]
        public short Stint { get; set; }
        public short? Glf { get; set; }
        public short? Gcf { get; set; }
        public short? Grf { get; set; }

        public virtual Person Player { get; set; } = null!;
    }
}
