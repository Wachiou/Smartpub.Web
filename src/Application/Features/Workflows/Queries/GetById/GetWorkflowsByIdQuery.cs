using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AutoMapper;
using MVWorkflows.Application.Interfaces.Repositories;
using MVWorkflows.Application.Models.Workflows;
using MVWorkflows.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace MVWorkflows.Application.Features.Workflows.Queries.GetById
{
    public class GetWorkflowsByIdQuery : IRequest<Result<GetWorkflowsByIdResponse>>
    {
        public int Id { get; set; }
    }

    internal class GetWorkflowsByIdQueryHandler : IRequestHandler<GetWorkflowsByIdQuery, Result<GetWorkflowsByIdResponse>>
    {
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IMapper _mapper;

        public GetWorkflowsByIdQueryHandler(IUnitOfWork<int> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetWorkflowsByIdResponse>> Handle(GetWorkflowsByIdQuery query, CancellationToken cancellationToken)
        {
            var workflows = await _unitOfWork.Repository<MVWorkflows.Application.Models.Workflows.Workflows>().GetByIdAsync(query.Id);
            var mappedBrand = _mapper.Map<GetWorkflowsByIdResponse>(workflows);
            return await Result<GetWorkflowsByIdResponse>.SuccessAsync(mappedBrand);
        }
    }
}
