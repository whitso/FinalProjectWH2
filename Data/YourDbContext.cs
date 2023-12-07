using Microsoft.EntityFrameworkCore;
using FinalProjectWH.Models; 

namespace FinalProjectWH.Data
{

    public class YourDbContext : DbContext
    {
        public YourDbContext(DbContextOptions<YourDbContext> options) : base(options) { }

        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.Challenge> Challenges { get; set; }
        public DbSet<Models.ChallengeProgress> ChallengeProgress { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }
}


