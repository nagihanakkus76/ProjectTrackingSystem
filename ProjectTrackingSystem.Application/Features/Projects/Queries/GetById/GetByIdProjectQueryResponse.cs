namespace ProjectTrackingSystem.Application.Features.Projects.Queries.GetById
{
    public class GetByIdProjectQueryResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}