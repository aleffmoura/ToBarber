using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace Totten.Solutions.ToBarber.Infra.Data.Base
{
    public class DesignTimeToBarberContextFactory : IDesignTimeDbContextFactory<ToBarberContext>
    {
        public ToBarberContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ToBarberContext> optionsBuilder = new DbContextOptionsBuilder<ToBarberContext>();

            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WolfMonitorContext;Persist Security Info=True; Integrated Security=True;",
                opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));

            return new ToBarberContext(optionsBuilder.Options);
        }
    }
}