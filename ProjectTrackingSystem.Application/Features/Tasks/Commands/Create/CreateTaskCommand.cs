using AutoMapper;
using MediatR;
using ProjectTrackingSystem.Application.Repositories;
using ProjectTrackingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTrackingSystem.Application.Features.Tasks.Commands.Create
{
    public class CreateTaskCommand : IRequest<CreateTaskResponse>
    {
        public int ProjectID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, CreateTaskResponse>
        {
            private readonly ITaskRepository _repository;
            private readonly IMapper _mapper;

            public CreateTaskCommandHandler(ITaskRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<CreateTaskResponse> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
            {
                TaskEntity task = _mapper.Map<TaskEntity>(request);
                await _repository.AddAsync(task);

                CreateTaskResponse response = _mapper.Map<CreateTaskResponse>(task);
                return response;
            }
        }
    }
}
