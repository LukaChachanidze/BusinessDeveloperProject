using BusinessToDeveloper.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessToDeveloper.Infrastructure.Maps
{
    public class DeveloperSkillEntityTypeConfiguration : IEntityTypeConfiguration<DeveloperSkill>
    {
        public void Configure(EntityTypeBuilder<DeveloperSkill> builder)
        {
            builder.ToTable("DeveloperSkills");

            builder.HasKey(ds => new { ds.DeveloperId, ds.SkillId });

            builder.Property(ds => ds.DeveloperId)
                .HasColumnName("DeveloperId");

            builder.Property(ds => ds.SkillId)
                .HasColumnName("SkillId");

            builder.HasOne(ds => ds.Developer)
                .WithMany(d => d.Skills)
                .HasForeignKey(ds => ds.DeveloperId);

            builder.HasOne(ds => ds.Skill)
                .WithMany(s => s.DeveloperSkills)
                .HasForeignKey(ds => ds.SkillId);
        }
    }
}
