using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Totten.Solutions.ToBarber.Domain.Features.UserAggregation;

namespace Totten.Solutions.ToBarber.Infra.Data.Features.Users
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(user => user.Id);
            builder.Property(user => user.Login).IsRequired();
            builder.Property(user => user.Password).IsRequired();
            builder.Property(user => user.Email).IsRequired();
            builder.Property(user => user.UpdatedIn);
            builder.Property(user => user.CreatedAt).IsRequired();
            builder.Property(user => user.Version).IsRequired();

            builder.HasOne(user => user.Role).WithMany().HasForeignKey(user => user.RoleId);
            builder.HasOne(user => user.Company).WithMany().HasForeignKey(user => user.CompanyId);
        }
    }
}
