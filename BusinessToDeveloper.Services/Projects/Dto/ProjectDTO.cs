namespace BusinessToDeveloper.Services.Projects.Dto
{
    public class ProjectDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BusinessId { get; set; }
        public int DeveloperId { get; set; }
        public string BusinessName { get; set; }
        public string DeveloperName { get; set; }
    }
}
