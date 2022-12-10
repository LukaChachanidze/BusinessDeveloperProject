using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessToDeveloper.Core.Entities
{
    public class BusinessSkill
    {
        public int BusinessId { get; set; }
        public Business Business { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }

}
