using AutoMapper;
using MediatR;
using ProjectTrackingSystem.Application.Repositories;
using ProjectTrackingSystem.Domain.Entities;
using ProjectTrackingSystem.Domain.Enum;

namespace ProjectTrackingSystem.Application.Features.Tasks.Commands.Update
{
    public class UpdateTaskCommand : IRequest<UpdateTaskResponse>
    {
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }

        public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, UpdateTaskResponse>
        {
            private readonly ITaskRepository _repository;
            private readonly IMapper _mapper;

            public UpdateTaskCommandHandler(ITaskRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<UpdateTaskResponse> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
            {
                TaskEntity task = await _repository.GetAsync(x  => x.ID == request.ID);
                if (task == null) throw new Exception("Aradığınız kriterlere uygun veri bulunamadı.");

                task.Title = request.Title;
                task.Description = request.Description;
                task.Status = request.Status;
                task.ProjectID = request.ProjectID;
                await _repository.UpdateAsync(task);

                UpdateTaskResponse response = _mapper.Map<UpdateTaskResponse>(task);
                return response;    
            }
        }
    }
}
