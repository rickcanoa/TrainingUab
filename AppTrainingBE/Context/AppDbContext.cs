using AppTrainingBE.Models;
using AppTrainingBETeacher.Models;
using Microsoft.EntityFrameworkCore;

namespace AppTrainingBE.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
                    : base(options) 
        {   

        }

        public DbSet<Person> Persons { get; set; }

        #region Relacion 1 a 1
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        #endregion


    }
}
