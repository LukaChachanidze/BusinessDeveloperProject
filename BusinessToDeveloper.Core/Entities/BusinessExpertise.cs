namespace BusinessToDeveloper.Core.Entities
{
    public class BusinessExpertise
    {
        public int Id { get; set; }
        public int BusinessId { get; set; }
        public Business Business { get; set; }
        public int ExpertiseId { get; set; }
        public Expertise Expertise { get; set; }
    }

}
