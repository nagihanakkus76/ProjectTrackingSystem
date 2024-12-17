using AutoMapper;
using MediatR;
using ProjectTrackingSystem.Application.Repositories;
using ProjectTrackingSystem.Domain.Entities;

namespace ProjectTrackingSystem.Application.Features.Projects.Queries.GetById
{
    public class GetByIdProjectQuery : IRequest<GetByIdProjectQueryResponse>
    {
        public int ID { get; set; }
        public class GetByIdProjectQueryHandler : IRequestHandler<GetByIdProjectQuery, GetByIdProjectQueryResponse>
        {
            private readonly IProjectRepository _repository;
            private readonly IMapper _mapper;

            public GetByIdProjectQueryHandler(IProjectRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<GetByIdProjectQueryResponse> Handle(GetByIdProjectQuery request, CancellationToken cancellationToken)
            {
                Project project = await _repository.GetAsync(x => x.ID == request.ID);
                if (project == null)
                    throw new Exception("Aranılan kriterlere uygun veri bulunamadı.");

                GetByIdProjectQueryResponse response = _mapper.Map<GetByIdProjectQueryResponse>(project);
                return response;
            }
        }
    }
}
