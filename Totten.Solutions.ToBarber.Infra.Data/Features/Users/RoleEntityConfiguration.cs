using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Totten.Solutions.ToBarber.Domain.Features.UserAggregation;

namespace Totten.Solutions.ToBarber.Infra.Data.Features.Users
{
    public class RoleEntityConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");

            builder.HasKey(role => role.Id);
            builder.Property(role => role.Level).IsRequired();
            builder.Property(role => role.Name).IsRequired();
            builder.Property(role => role.UpdatedIn);
            builder.Property(role => role.CreatedAt).IsRequired();
            builder.Property(role => role.Version).IsRequired();
        }
    }
}
