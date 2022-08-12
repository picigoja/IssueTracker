using System.ComponentModel.DataAnnotations;

namespace IssueTracker.Models
{
    public class Issue
    {
        public int Id { get; set; }

        [StringLength(100), MinLength(3)]
        [Required]
        public string Title { get; set; } = default!;

        [StringLength(500)]
        public string Description { get; set; } = default!;

        [DataType(DataType.Date)]
        [Display(Name = "Created On")]
        public DateTime Created { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Last Updated")]
        public DateTime LastUpdated { get; set; }

        public Project ParentProject { get; set; } = default!;
        public User CreatedBy { get; set; } = default!;
    }
}
