using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Totten.Solutions.ToBarber.Domain.Features.ProvidedServices;

namespace Totten.Solutions.ToBarber.Infra.Data.Features.ProvidedServices
{
    public class ProvidedServiceEntityConfiguration : IEntityTypeConfiguration<ProvidedService>
    {

        public void Configure(EntityTypeBuilder<ProvidedService> builder)
        {
            builder.ToTable("ProvidedServices");

            builder.HasKey(provideService => provideService.Id);
            builder.Property(provideService => provideService.Name).IsRequired();
            builder.Property(provideService => provideService.CreatedAt).IsRequired();
            builder.Property(provideService => provideService.Duration).IsRequired();
            builder.Property(provideService => provideService.Value).IsRequired();
            builder.Property(provideService => provideService.Version).IsRequired();
            builder.Property(provideService => provideService.UpdatedIn);


            builder.HasMany(provideService => provideService.Employees);
        }
    }
}
