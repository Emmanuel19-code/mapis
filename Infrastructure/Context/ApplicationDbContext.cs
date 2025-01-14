using mapis.Domain;

using Microsoft.EntityFrameworkCore;

namespace mapis.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {

        }
        public DbSet<CILTUser> CiltUser {get;set;}
        public DbSet<CILTUserAuth> CILTUserAuths {get;set;}
        public DbSet<Events> Events {get;set;}
        public DbSet<EventRegistration> RegisterEvents {get;set;}
    }
}



