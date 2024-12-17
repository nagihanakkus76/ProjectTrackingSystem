namespace ProjectTrackingSystem.Application.Features.Projects.Commands.Update
{
    public class UpdateProjectResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}