using AppTrainingBE.Models;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region 1 a 1
            modelBuilder.Entity<User>()
                .HasOne(u => u.Profile)
                .WithOne(u => u.User)
                .HasForeignKey<UserProfile>(p => p.UserId);

            //Propiedades de opciones
            modelBuilder.Entity<User>()
                .Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(50);
            #endregion
        }

    }
}
