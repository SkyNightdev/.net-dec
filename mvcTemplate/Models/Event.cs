using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcTemplate.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EventDate { get; set; }

        [Required]
        [Range(10, 200)]
        public int MaxParticipants { get; set; }

        [Required]
        [StringLength(100)]
        public string Location { get; set; } = string.Empty;

        public string TeacherId { get; set; } = string.Empty;

        [ForeignKey("TeacherId")]
        public Teacher Teacher { get; set; } = null!;
    }
}
