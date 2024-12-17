using ProjectTrackingSystem.Domain.Entities;
using ProjectTrackingSystem.Domain.Enum;

namespace ProjectTrackingSystem.Application.Features.Tasks.Commands.Update
{
    public class UpdateTaskResponse
    {
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; } 
    }
}