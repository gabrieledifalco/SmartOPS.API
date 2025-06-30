using Microsoft.EntityFrameworkCore;
using SmartOPS.API.Model;

namespace SmartOPS.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobResult> JobResults { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }
        public DbSet<PasswordResetToken> PasswordResetTokens { get; set; }
        public DbSet<MicroJob> MicroJobs { get; set; }
        public DbSet<MicroJobResult> MicroJobResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<User>().HasOne(u => u.Token).WithOne(t => t.User).HasForeignKey<UserToken>(t => t.UserId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Job>().HasMany(j => j.Results).WithOne(r => r.Job).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Job>().Property(j => j.Status).HasConversion<string>();
            modelBuilder.Entity<JobResult>().Property(jr => jr.Result).HasConversion<string>();
            modelBuilder.Entity<MicroJob>().Property(mj => mj.Status).HasConversion<string>();
            modelBuilder.Entity<MicroJobResult>().Property(mjr => mjr.Status).HasConversion<string>();
        }

    }
}
