using mapis.Domain;

using Microsoft.EntityFrameworkCore;

namespace mapis.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<CILTUser> CiltUser { get; set; }
        public DbSet<CILTUserAuth> CILTUserAuths { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<EventRegistration> RegisterEvents { get; set; }
        public DbSet<Applicants> Applicants { get; set; }
        public DbSet<Administrators> Admins { get; set; }
        public DbSet<Notifications> Notifications {get;set;}
        public DbSet<Complains> Complains {get;set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CILTUserAuth>()
                .HasKey(c => c.CILTUserId);
            modelBuilder.Entity<CILTUserAuth>()
                .HasOne(c => c.CILTUser)
                .WithOne(u => u.CILTUserAuth)
                .HasForeignKey<CILTUserAuth>(c => c.CILTUserId);
            base.OnModelCreating(modelBuilder);
        }
    }
}



