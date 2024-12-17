using AutoMapper;
using MediatR;
using ProjectTrackingSystem.Application.Repositories;
using ProjectTrackingSystem.Domain.Entities;

namespace ProjectTrackingSystem.Application.Features.Projects.Queries.GetList
{
    public class GetListProjectQuery : IRequest<List<GetListProjectQueryResponse>>
    {
        public class GetListProjectQueryHandler : IRequestHandler<GetListProjectQuery, List<GetListProjectQueryResponse>>
        {
            private readonly IProjectRepository _repository;
            private readonly IMapper _mapper;

            public GetListProjectQueryHandler(IProjectRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<List<GetListProjectQueryResponse>> Handle(GetListProjectQuery request, CancellationToken cancellationToken)
            {
                List<Project> projects = await _repository.GetListAsync();
                List<GetListProjectQueryResponse> responses = _mapper.Map<List<GetListProjectQueryResponse>>(projects);
                return responses;
            }
        }
    }
}
