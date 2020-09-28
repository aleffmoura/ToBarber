using Microsoft.EntityFrameworkCore;
using Totten.Solutions.ToBarber.Domain.Features.Companies;
using Totten.Solutions.ToBarber.Domain.Features.Employees;
using Totten.Solutions.ToBarber.Domain.Features.ProvidedServices;
using Totten.Solutions.ToBarber.Domain.Features.Schedules;
using Totten.Solutions.ToBarber.Domain.Features.UserAggregation;

namespace Totten.Solutions.ToBarber.Infra.Data.Base
{
    public class ToBarberContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ProvidedService> ProvidedServices { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Scheduling> Schedules { get; set; }


        public ToBarberContext(DbContextOptions<ToBarberContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new AgentEntityConfiguration());
            //modelBuilder.ApplyConfiguration(new ProfilesEntityConfiguration());
            //modelBuilder.ApplyConfiguration(new CompanyEntityConfiguration());

            //modelBuilder.SeedWolf();
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(false);
        }
    }
}
