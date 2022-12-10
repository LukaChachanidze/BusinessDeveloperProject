using BusinessToDeveloper.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessToDeveloper.Infrastructure.Maps
{
    public class BusinessExpertiseEntityTypeConfiguration : IEntityTypeConfiguration<BusinessExpertise>
    {
        public void Configure(EntityTypeBuilder<BusinessExpertise> builder)
        {
            builder.ToTable("BusinessExpertises");

            builder.HasKey(be => be.Id);

            builder.Property(be => be.Id)
                .HasColumnName("BusinessExpertiseId")
                .ValueGeneratedOnAdd();

            builder.Property(be => be.BusinessId)
                .HasColumnName("BusinessId");

            builder.Property(be => be.ExpertiseId)
                .HasColumnName("ExpertiseId");

            builder.HasOne(be => be.Business)
                .WithMany(b => b.Expertise)
                .HasForeignKey(be => be.BusinessId);

            builder.HasOne(be => be.Expertise)
                .WithMany(e => e.BusinessExpertises)
                .HasForeignKey(be => be.ExpertiseId);
            }
    }
}
