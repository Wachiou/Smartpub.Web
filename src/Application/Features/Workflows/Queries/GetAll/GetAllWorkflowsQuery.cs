using AutoMapper;
using MVWorkflows.Application.Interfaces.Repositories;
using MVWorkflows.Application.Models.Workflows;
using MVWorkflows.Shared.Constants.Application;
using MVWorkflows.Shared.Wrapper;
using LazyCache;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Linq;

namespace MVWorkflows.Application.Features.Workflows.Queries.GetAll
{
    public class GetAllWorkflowsQuery : IRequest<Result<List<GetAllWorkflowsResponse>>>
    {
        public GetAllWorkflowsQuery()
        {
        }
    }

    internal class GetAllWorkflowsCachedQueryHandler : IRequestHandler<GetAllWorkflowsQuery, Result<List<GetAllWorkflowsResponse>>>
    {
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppCache _cache;

        public GetAllWorkflowsCachedQueryHandler(IUnitOfWork<int> unitOfWork, IMapper mapper, IAppCache cache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<Result<List<GetAllWorkflowsResponse>>> Handle(GetAllWorkflowsQuery request, CancellationToken cancellationToken)
        {
            //Expression<Func<Workflows, GetAllWorkflowsResponse>> expression = e => new GetAllWorkflowsResponse
            //{
            //    Id = e.Id,
            //    NomWorkflow = e.NomWorkflow,
            //    DateDebut = e.DateDebut,
            //    DateFin = e.DateFin,
            //    Statut = e.Statut,
            //    DescriptionWorkflow = e.DescriptionWorkflow,
            //    WorkflowOwnerUser = e.WorkflowOwnerUser.ToString(),
            //    TitleWorkflow = e.TitleWorkflow,
            //    WorkflowOwnerUserID = e.WorkflowOwnerUserID
            //};
            Expression<Func<Models.Workflows.Workflows, GetAllWorkflowsResponse>> expression = e => new GetAllWorkflowsResponse
            {
                Id = e.Id,
                NomWorkflow = e.NomWorkflow,
                DescriptionWorkflow = e.DescriptionWorkflow,
                TitleWorkflow = e.TitleWorkflow,
                WorkflowOwnerUser = e.WorkflowOwnerUser.UserName,
                WorkflowImageUrl = e.WorkflowImageUrl,
                WorkflowOwnerUserID = e.WorkflowOwnerUserID,
                WorkflowOwnerUserImageUrl = e.WorkflowOwnerUser.ProfilePictureDataUrl
            };
            //var productFilterSpec = new ProductFilterSpecification(request.SearchString);
            //if (request.OrderBy?.Any() != true)
            //{
            //    var data = await _unitOfWork.Repository<Product>().Entities
            //       .Specify(productFilterSpec)
            //       .Select(expression)
            //       .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            //    return data;
            //}
            //else
            //{
            //    var ordering = string.Join(",", request.OrderBy); // of the form fieldname [ascending|descending], ...
            //    var data = await _unitOfWork.Repository<Product>().Entities
            //       .Specify(productFilterSpec)
            //       .OrderBy(ordering) // require system.linq.dynamic.core
            //       .Select(expression).
            //       .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            //    return data;

            //}

            //await _unitOfWork.Repository<Models.Workflows.Workflows>().Entities.Select(Exceptions)
            Func<Task<List<GetAllWorkflowsResponse>>> getAllWorkflows = () => Task<List<GetAllWorkflowsResponse>>.Factory.StartNew(() =>
             _unitOfWork.Repository<Models.Workflows.Workflows>().Entities.Select(expression).ToList());

            var workflowsList = await _cache.GetOrAddAsync(ApplicationConstants.Cache.GetAllWorkflowsCacheKey, getAllWorkflows);
            var mappedWorkflows = _mapper.Map<List<GetAllWorkflowsResponse>>(workflowsList);
            return await Result<List<GetAllWorkflowsResponse>>.SuccessAsync(mappedWorkflows);
        }
    }
}
