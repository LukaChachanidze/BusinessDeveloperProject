using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessToDeveloper.Core.Entities
{
    public class DeveloperSkill
    {
        public int DeveloperId { get; set; }
        public Developer Developer { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
