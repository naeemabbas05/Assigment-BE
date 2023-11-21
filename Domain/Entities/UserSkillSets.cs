using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserSkillSets: BaseEntity
    {
        public int UserId { get; set; }
        public int SkillSetsId { get; set; }
        public SkillSets? SkillSets { get; set; }
    }
}
