using ProjectTrackingSystem.Domain.Enum;

namespace ProjectTrackingSystem.Application.Features.Tasks.Queries.GetList
{
    public class GetListTaskResponse
    {
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public Status Status { get; set; }
    }
}