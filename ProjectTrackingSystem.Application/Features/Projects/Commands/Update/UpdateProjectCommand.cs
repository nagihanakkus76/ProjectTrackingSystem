using AutoMapper;
using MediatR;
using ProjectTrackingSystem.Application.Repositories;
using ProjectTrackingSystem.Domain.Entities;

namespace ProjectTrackingSystem.Application.Features.Projects.Commands.Update
{
    public class UpdateProjectCommand : IRequest<UpdateProjectResponse>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, UpdateProjectResponse>
        {
            private readonly IProjectRepository _repository;
            private readonly IMapper _mapper;

            public UpdateProjectCommandHandler(IProjectRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<UpdateProjectResponse> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
            {
               Project project = await _repository.GetAsync(x => x.ID == request.ID);
                if (project == null)
                    throw new Exception("Aradığınız kriterlere uygun veri bulunamadı.");

                project.Name = request.Name;
                project.StartDate = request.StartDate;
                project.EndDate = request.EndDate;
                await _repository.UpdateAsync(project);
                UpdateProjectResponse response = _mapper.Map<UpdateProjectResponse>(project);
                return response;
            }
        }
    }
}
