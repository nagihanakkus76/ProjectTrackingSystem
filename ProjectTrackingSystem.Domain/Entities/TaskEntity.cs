using Core.Base.Entities;
using ProjectTrackingSystem.Domain.Enum;

namespace ProjectTrackingSystem.Domain.Entities
{
    public class TaskEntity : BaseEntity<int>
    {
        public int ProjectID { get; set; }
        public Project Project { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public Status Status { get; set; } = Status.New;
    }
}
