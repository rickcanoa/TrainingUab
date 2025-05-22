using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppTrainingBETeacher.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string UserName { get; set; } = null!;

        //Relacion 1:1
        public UserProfile Profile { get; set; } = null!;
    }

    public class UserProfile
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string FullName { get; set; }
        
        public DateTime DateOfBirth { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; } = null!;
    }

}
