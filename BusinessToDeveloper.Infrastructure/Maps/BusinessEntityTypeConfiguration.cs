using BusinessToDeveloper.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessToDeveloper.Infrastructure.Maps
{
    public class BusinessEntityTypeConfiguration : IEntityTypeConfiguration<Business>
    {
        public void Configure(EntityTypeBuilder<Business> builder)
        {
            builder.ToTable("Businesses");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.Description)
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(b => b.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasAlternateKey(b => b.Email)
                .HasName("AlternateKey_Business_Email");

             builder.HasMany(b => b.Skills)
            .WithOne(bs => bs.Business)
            .HasForeignKey(bs => bs.BusinessId);

            builder.HasMany(b => b.Expertise)
                .WithOne(be => be.Business)
                .HasForeignKey(be => be.BusinessId);

            builder.HasMany(b => b.Projects)
                .WithOne(p => p.Business)
                .HasForeignKey(p => p.BusinessId);

        }
    }
}
