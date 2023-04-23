using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsInTheCompany.Domain.Employees;
using ProjectsInTheCompany.Domain.ProjectTasks;

namespace ProjectsInTheCompany.Infrastructure.Data.ProjectTasks
{
    internal class ProjectTaskConfiguration : IEntityTypeConfiguration<ProjectTask>
    {
        public void Configure(EntityTypeBuilder<ProjectTask> builder)
        {
            builder.ToTable("Project Tasks");

            builder.HasKey(pt => pt.Id);

            builder.Property(pt => pt.Description);

            builder.HasOne(pt => pt.Employee).WithOne(e => e.ProjectTask)
                .HasForeignKey<Employee>(e => e.ProjectTaskId).IsRequired();

        }
    }
}
