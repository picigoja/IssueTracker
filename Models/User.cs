using System.ComponentModel.DataAnnotations;

namespace IssueTracker.Models
{
    public class User
    {
        public int Id { get; set; }

        [StringLength(100), MinLength(3)]
        [Required]
        public string Name { get; set; } = default!;

        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; } = default!;

        [DataType(DataType.Password)]
        [Required] 
        public string Password { get; set; } = default!;
    }
}
