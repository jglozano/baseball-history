using System.ComponentModel.DataAnnotations;

namespace BaseballHistory.Domain.Entities
{
    public class School
    {
        public School()
        {
            CollegePlayings = new HashSet<CollegePlaying>();
        }

        [Key]
        public string SchoolId { get; set; } = null!;
        public string? NameFull { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }

        public virtual ICollection<CollegePlaying> CollegePlayings { get; set; }
    }
}
