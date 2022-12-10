namespace BusinessToDeveloper.Core.Entities
{
    public class DeveloperExpertise
    {
        public int DeveloperId { get; set; }
        public Developer Developer { get; set; }
        public int ExpertiseId { get; set; }
        public Expertise Expertise { get; set; }
    }
}
