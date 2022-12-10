using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessToDeveloper.Core.Entities
{
    public class Expertise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<BusinessExpertise> BusinessExpertises { get; set; }
        public ICollection<DeveloperExpertise> DeveloperExpertises { get; set; }
    }
}
