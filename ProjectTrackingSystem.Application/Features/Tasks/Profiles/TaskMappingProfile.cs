using AutoMapper;
using ProjectTrackingSystem.Application.Features.Tasks.Commands.ChangeStatus;
using ProjectTrackingSystem.Application.Features.Tasks.Commands.Create;
using ProjectTrackingSystem.Application.Features.Tasks.Commands.Update;
using ProjectTrackingSystem.Application.Features.Tasks.Queries.GetList;
using ProjectTrackingSystem.Domain.Entities;

namespace ProjectTrackingSystem.Application.Features.Tasks.Profiles
{
    public class TaskMappingProfile : Profile
    {

        public TaskMappingProfile()
        {
            CreateMap<TaskEntity, CreateTaskCommand>().ReverseMap();
            CreateMap<TaskEntity, CreateTaskResponse>().ReverseMap();
            CreateMap<TaskEntity, UpdateTaskCommand>().ReverseMap();
            CreateMap<TaskEntity, UpdateTaskResponse>().ReverseMap();
            CreateMap<TaskEntity, ChangeStatusTaskResponse>().ReverseMap();
            CreateMap<TaskEntity, GetListTaskResponse>()
                .ForMember(dest => dest.ProjectID, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.Project.Name));
        }
    }
}
