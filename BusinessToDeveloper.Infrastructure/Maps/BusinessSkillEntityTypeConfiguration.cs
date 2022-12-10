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
    public class BusinessSkillEntityTypeConfiguration : IEntityTypeConfiguration<BusinessSkill>
    {
        public void Configure(EntityTypeBuilder<BusinessSkill> builder)
        {
            builder.ToTable("BusinessSkills");

            builder.HasKey(bs => new { bs.BusinessId, bs.SkillId });

            builder.Property(bs => bs.BusinessId)
                .HasColumnName("BusinessId");

            builder.Property(bs => bs.SkillId)
                .HasColumnName("SkillId");

            builder.HasOne(bs => bs.Business)
                .WithMany(b => b.Skills)
                .HasForeignKey(bs => bs.BusinessId);

            builder.HasOne(bs => bs.Skill)
                .WithMany(s => s.BusinessSkills)
                .HasForeignKey(bs => bs.SkillId);
        }
    }
}
