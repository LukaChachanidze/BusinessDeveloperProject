using BusinessToDeveloper.Core.Entities;
using BusinessToDeveloper.Infrastructure.Maps;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BusinessToDeveloper.Infrastructure.Data
{
    public class BusinessToDeveloperDbContext : IdentityDbContext<ApplicationUser>
    {
        public BusinessToDeveloperDbContext(DbContextOptions<BusinessToDeveloperDbContext> options) : base(options)
        {

        }

        public DbSet<Business> Businesses { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Expertise> Expertises { get; set; }
        public DbSet<BusinessExpertise> BusinessExpertises { get; set; }
        public DbSet<BusinessSkill> BusinessSkills { get; set; }
        public DbSet<DeveloperExpertise> DeveloperExpertises { get; set; }
        public DbSet<DeveloperSkill> DeveloperSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BusinessEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DeveloperEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SkillEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ExpertiseEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BusinessExpertiseEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BusinessSkillEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DeveloperExpertiseEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DeveloperSkillEntityTypeConfiguration());

            base.OnModelCreating(modelBuilder);

        }
    }
}
