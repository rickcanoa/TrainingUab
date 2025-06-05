using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppTrainingBE.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;

        //Relacion 1:1
        public UserProfile Profile { get; set; } = null!;
    }

    public class UserProfile
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int UserId { get; set; }

        public User? User { get; set; } = null!;
    }
}
