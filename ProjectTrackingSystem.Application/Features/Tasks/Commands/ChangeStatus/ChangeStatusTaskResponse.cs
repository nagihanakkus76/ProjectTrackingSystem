using ProjectTrackingSystem.Domain.Enum;

namespace ProjectTrackingSystem.Application.Features.Tasks.Commands.ChangeStatus
{
    public class ChangeStatusTaskResponse
    {
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; } 
        public Status Status { get; set; } 
    }
}