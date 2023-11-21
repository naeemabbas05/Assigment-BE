

namespace Domain.Entities
{
    public class User: BaseEntity
    {
        public string? UserName { get; set; }
        public string? Mail { get; set; }
        public string? PhoneNumber { get; set; }
        public List<UserSkillSets>? UserSkillSets { get; set; }
        public string? Hobby { get; set; }
    }
}
