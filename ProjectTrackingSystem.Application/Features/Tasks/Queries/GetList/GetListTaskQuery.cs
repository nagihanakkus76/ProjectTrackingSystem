using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectTrackingSystem.Application.Repositories;
using ProjectTrackingSystem.Domain.Entities;

namespace ProjectTrackingSystem.Application.Features.Tasks.Queries.GetList
{
    public class GetListTaskQuery : IRequest<List<GetListTaskResponse>>
    {
        public class GetListTaskQueryHandler : IRequestHandler<GetListTaskQuery, List<GetListTaskResponse>>
        {
            private readonly ITaskRepository _repository;
            private readonly IMapper _mapper;

            public GetListTaskQueryHandler(ITaskRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
//TODO: ProjectName null düzenleme yapılacak.
            public async Task<List<GetListTaskResponse>> Handle(GetListTaskQuery request, CancellationToken cancellationToken)
            {
                List<TaskEntity> tasks = await _repository.GetListAsync(include: t => t.Include(t => t.Project));
                List<GetListTaskResponse> responses = _mapper.Map<List<GetListTaskResponse>>(tasks);
                return responses;   
            }
        }
    }
}
