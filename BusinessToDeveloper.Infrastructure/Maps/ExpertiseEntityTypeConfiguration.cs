using BusinessToDeveloper.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessToDeveloper.Infrastructure.Maps
{
    public class ExpertiseEntityTypeConfiguration : IEntityTypeConfiguration<Expertise>
    {
        public void Configure(EntityTypeBuilder<Expertise> builder)
        {
            builder.ToTable("Expertises");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("ExpertiseId")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(e => e.BusinessExpertises)
                .WithOne(be => be.Expertise)
                .HasForeignKey(be => be.ExpertiseId);

            builder.HasMany(e => e.DeveloperExpertises)
                .WithOne(de => de.Expertise)
                .HasForeignKey(de => de.ExpertiseId);
        }
    }
}

