using BusinessToDeveloper.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessToDeveloper.Infrastructure.Maps
{
    internal class DeveloperExpertiseEntityTypeConfiguration : IEntityTypeConfiguration<DeveloperExpertise>
    {
        public void Configure(EntityTypeBuilder<DeveloperExpertise> builder)
        {
            builder.ToTable("DeveloperExpertises");

            builder.HasKey(de => new { de.DeveloperId, de.ExpertiseId });

            builder.Property(de => de.DeveloperId)
                .HasColumnName("DeveloperId");

            builder.Property(de => de.ExpertiseId)
                .HasColumnName("ExpertiseId");

            builder.HasOne(de => de.Developer)
                .WithMany(d => d.Expertise)
                .HasForeignKey(de => de.DeveloperId);

            builder.HasOne(de => de.Expertise)
                .WithMany(e => e.DeveloperExpertises)
                .HasForeignKey(de => de.ExpertiseId);
        }
    } 
}
