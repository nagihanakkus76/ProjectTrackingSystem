using MediatR;
using ProjectTrackingSystem.Application.Repositories;
using ProjectTrackingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTrackingSystem.Application.Features.Tasks.Commands.Delete
{
    public class DeleteTaskCommand : IRequest
    {
        public int ID { get; set; }
        public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand>
        {
            private readonly ITaskRepository _repository;

            public DeleteTaskCommandHandler(ITaskRepository repository)
            {
                _repository = repository;
            }

            public async Task Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
            {
               TaskEntity task = await _repository.GetAsync(x => x.ID == request.ID);
                if (task == null) throw new Exception("Silmek istediğiniz veri bulunamadı.");
                await _repository.DeleteAsync(task);

            }
        }
    }
}
