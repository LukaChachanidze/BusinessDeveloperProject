namespace BusinessToDeveloper.Core.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Navigation properties
        public int BusinessId { get; set; }
        public Business Business { get; set; }
        public int DeveloperId { get; set; }
        public Developer Developer { get; set; }

        // Methods for adding and removing a business or developer from the project
        public void AssignBusiness(Business business)
        {
            BusinessId = business.Id;
            Business = business;
        }
        public void RemoveBusiness()
        {
            BusinessId = 0;
            Business = null;
        }
        public void AssignDeveloper(Developer developer)
        {
            DeveloperId = developer.Id;
            Developer = developer;
        }
        public void RemoveDeveloper()
        {
            DeveloperId = 0;
            Developer = null;
        }
    }
}

