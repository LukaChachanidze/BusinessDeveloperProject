namespace BusinessToDeveloper.Core.Entities
{
    public class Developer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public ICollection<DeveloperSkill> Skills { get; set; }
        public ICollection<DeveloperExpertise> Expertise { get; set; }

        public ICollection<Project> Projects { get; set; }

        public void AddProject(Project project)
        {
            Projects.Add(project);
        }

        public void RemoveProject(Project project)
        {
            Projects.Remove(project);
        }

    }
}
