namespace ProjectTrackingSystem.Application.Features.Projects.Queries.GetList
{
    public class GetListProjectQueryResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}