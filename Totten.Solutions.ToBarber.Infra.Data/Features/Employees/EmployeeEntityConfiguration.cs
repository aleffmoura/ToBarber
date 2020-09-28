using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Totten.Solutions.ToBarber.Domain.Features.Employees;

namespace Totten.Solutions.ToBarber.Infra.Data.Features.Employees
{
    public class EmployeeEntityConfiguration : IEntityTypeConfiguration<Employee>
    {

        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");

            builder.HasKey(employee => employee.Id);
            builder.Property(employee => employee.UpdatedIn);
            builder.Property(employee => employee.CreatedAt).IsRequired();
            builder.Property(employee => employee.Version).IsRequired();


            builder.HasMany(employee => employee.ProvidedServices);
            builder.HasOne(employee => employee.User).WithMany(user => user.Employees).HasForeignKey(employee => employee.UserId);
        }
    }
}
