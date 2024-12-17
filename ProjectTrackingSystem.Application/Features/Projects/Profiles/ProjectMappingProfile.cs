using AutoMapper;
using ProjectTrackingSystem.Application.Features.Projects.Commands.Create;
using ProjectTrackingSystem.Application.Features.Projects.Commands.Update;
using ProjectTrackingSystem.Application.Features.Projects.Queries.GetById;
using ProjectTrackingSystem.Application.Features.Projects.Queries.GetList;
using ProjectTrackingSystem.Domain.Entities;

namespace ProjectTrackingSystem.Application.Features.Projects.Profiles
{
    public class ProjectMappingProfile : Profile
    {
        public ProjectMappingProfile()
        {
            CreateMap<Project, CreateProjectCommand>().ReverseMap();
            CreateMap<Project, CreateProjectResponse>().ReverseMap();
            CreateMap<Project, UpdateProjectCommand>().ReverseMap();
            CreateMap<Project, UpdateProjectResponse>().ReverseMap();
            CreateMap<Project, GetByIdProjectQuery>().ReverseMap();
            CreateMap<Project, GetByIdProjectQueryResponse>().ReverseMap();
            CreateMap<Project, GetListProjectQuery>().ReverseMap();
            CreateMap<Project, GetListProjectQueryResponse>().ReverseMap();
        }
    }
}
