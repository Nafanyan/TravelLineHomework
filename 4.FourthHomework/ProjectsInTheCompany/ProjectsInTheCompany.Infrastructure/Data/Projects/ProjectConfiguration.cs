using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsInTheCompany.Domain.Projects;

namespace ProjectsInTheCompany.Infrastructure.Data.Projects
{
    internal class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable( "Projects" );

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title);

            builder.Property(p => p.Description);

            builder.HasMany(p => p.ProjectTasks).WithOne(pt => pt.Project).
                HasForeignKey(pt => pt.ProjectId).HasPrincipalKey(p => p.Id)
                .IsRequired();
        }
    }
}
