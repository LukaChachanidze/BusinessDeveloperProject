using BusinessToDeveloper.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
    
namespace BusinessToDeveloper.Infrastructure.Maps
{
    public class SkillEntityTypeConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.ToTable("Skills");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .HasColumnName("SkillId")
                .ValueGeneratedOnAdd();

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(s => s.BusinessSkills)
                .WithOne(bs => bs.Skill)
                .HasForeignKey(bs => bs.SkillId);

            builder.HasMany(s => s.DeveloperSkills)
                .WithOne(ds => ds.Skill)
                .HasForeignKey(ds => ds.SkillId);
        }    
    }
}
