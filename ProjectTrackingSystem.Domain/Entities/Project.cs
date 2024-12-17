using Core.Base.Entities;

namespace ProjectTrackingSystem.Domain.Entities
{
    public class Project : BaseEntity<int>
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<TaskEntity> Tasks { get; set; }
    }
}
