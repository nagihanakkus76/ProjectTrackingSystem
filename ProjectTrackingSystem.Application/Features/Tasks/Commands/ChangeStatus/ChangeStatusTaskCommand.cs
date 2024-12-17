using AutoMapper;
using MediatR;
using ProjectTrackingSystem.Application.Repositories;
using ProjectTrackingSystem.Domain.Entities;
using ProjectTrackingSystem.Domain.Enum;

namespace ProjectTrackingSystem.Application.Features.Tasks.Commands.ChangeStatus
{
    public class ChangeStatusTaskCommand : IRequest<ChangeStatusTaskResponse>
    {
        public int ID { get; set; }
        public Status Status { get; set; }

        public class ChangeStatusTaskCommandHandler : IRequestHandler<ChangeStatusTaskCommand, ChangeStatusTaskResponse>
        {
            private readonly ITaskRepository _repository;
            private readonly IMapper _mapper;

            public ChangeStatusTaskCommandHandler(ITaskRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<ChangeStatusTaskResponse> Handle(ChangeStatusTaskCommand request, CancellationToken cancellationToken)
            {
                TaskEntity task = await _repository.GetAsync(x => x.ID == request.ID);
                if (task == null) throw new Exception("Aradığınız kriterlere uygun veri bulunamadı.");
                task.Status = request.Status;
                await _repository.UpdateAsync(task);

                ChangeStatusTaskResponse response = _mapper.Map<ChangeStatusTaskResponse>(task);
                return response;
            }
        }
    }
}
