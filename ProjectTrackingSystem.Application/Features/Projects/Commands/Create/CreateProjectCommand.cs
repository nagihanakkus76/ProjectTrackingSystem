using AutoMapper;
using MediatR;
using ProjectTrackingSystem.Application.Repositories;
using ProjectTrackingSystem.Domain.Entities;

namespace ProjectTrackingSystem.Application.Features.Projects.Commands.Create
{
    public class CreateProjectCommand : IRequest<CreateProjectResponse>
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, CreateProjectResponse>
        {
            private readonly IProjectRepository _repository;
            private readonly IMapper _mapper;

            public CreateProjectCommandHandler(IProjectRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<CreateProjectResponse> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
            {
                Project project = _mapper.Map<Project>(request);
                await _repository.AddAsync(project);
                CreateProjectResponse response = _mapper.Map<CreateProjectResponse>(project);
                return response;    
            }
        }
    }
}
