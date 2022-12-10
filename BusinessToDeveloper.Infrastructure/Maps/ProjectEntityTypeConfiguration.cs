using BusinessToDeveloper.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessToDeveloper.Infrastructure.Maps
{
    public class ProjectEntityTypeConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projects");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("ProjectId")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Description)
                .HasMaxLength(500);

            builder.HasOne(p => p.Business)
                .WithMany(b => b.Projects)
                .HasForeignKey(p => p.BusinessId);

            builder.HasOne(p => p.Developer)
                .WithMany(d => d.Projects)
                .HasForeignKey(p => p.DeveloperId);
        }
    }
}
