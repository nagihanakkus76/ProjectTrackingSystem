using ProjectTrackingSystem.Domain.Entities;
using ProjectTrackingSystem.Domain.Enum;

namespace ProjectTrackingSystem.Application.Features.Tasks.Commands.Create
{
    public class CreateTaskResponse
    {
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        
    }
}