using BusinessToDeveloper.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessToDeveloper.Infrastructure.Maps
{
    public class DeveloperEntityTypeConfiguration : IEntityTypeConfiguration<Developer>
    {
        public void Configure(EntityTypeBuilder<Developer> builder)
        {
            builder.ToTable("Developers");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id)
                .HasColumnName("DeveloperId")
                .ValueGeneratedOnAdd();

            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(d => d.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(d => d.Skills)
                .WithOne(ds => ds.Developer)
                .HasForeignKey(ds => ds.DeveloperId);

            builder.HasMany(d => d.Expertise)
                .WithOne(de => de.Developer)
                .HasForeignKey(de => de.DeveloperId);

            builder.HasMany(d => d.Projects)
              .WithOne(p => p.Developer)
              .HasForeignKey(p => p.DeveloperId);
        }
    }
}
