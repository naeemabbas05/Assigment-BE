using Domain.Enums;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
        public StatusEnum IsActive { get; set; } = StatusEnum.Active;
    }
}
