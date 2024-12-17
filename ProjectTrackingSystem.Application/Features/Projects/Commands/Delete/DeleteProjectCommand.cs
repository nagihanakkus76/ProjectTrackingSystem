using MediatR;
using ProjectTrackingSystem.Application.Repositories;
using ProjectTrackingSystem.Domain.Entities;

namespace ProjectTrackingSystem.Application.Features.Projects.Commands.Delete
{
    public class DeleteProjectCommand : IRequest
    {
        public int ID { get; set; }

        public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand>
        {
            private readonly IProjectRepository _repository;

            public DeleteProjectCommandHandler(IProjectRepository repository)
            {
                _repository = repository;
            }

            public async Task Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
            {
                Project project = await _repository.GetAsync(x => x.ID == request.ID);
                if (project == null)
                    throw new Exception("Silmek istediğiniz veri bulunamadı.");
                await _repository.DeleteAsync(project);
            }
        }
    }
}
