namespace BusinessToDeveloper.Core.Entities
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<BusinessSkill> BusinessSkills { get; set; }
        public ICollection<DeveloperSkill> DeveloperSkills { get; set; }
    }
}
