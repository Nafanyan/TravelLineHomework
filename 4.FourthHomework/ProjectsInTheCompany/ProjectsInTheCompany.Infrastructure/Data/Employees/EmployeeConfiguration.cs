using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsInTheCompany.Domain.Employees;

namespace ProjectsInTheCompany.Infrastructure.Data.Employees
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable( "Employees" );

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name).HasMaxLength(100);

            builder.Property(e => e.Surname).HasMaxLength(100);

        }
    }
}
