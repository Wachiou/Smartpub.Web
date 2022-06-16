using MVWorkflows.Application.Extensions;
using MVWorkflows.Application.Interfaces.Repositories;
using MVWorkflows.Application.Specifications.Workflows;
using MVWorkflows.Domain.Entities.Catalog;
using MVWorkflows.Shared.Wrapper;
using MediatR;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;

namespace MVWorkflows.Application.Features.WorkflowInstance.Queries.GetAllPaged
{
    public class GetAllWorkflowInstanceQuery : IRequest<PaginatedResult<GetAllPagedWorkflowInstanceResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public string[] OrderBy { get; set; } // of the form fieldname [ascending|descending],fieldname [ascending|descending]...

        public GetAllWorkflowInstanceQuery(int pageNumber, int pageSize, string searchString, string orderBy)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            SearchString = searchString;
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                OrderBy = orderBy.Split(',');
            }
        }
    }

    internal class GetAllWorkflowInstanceQueryHandler : IRequestHandler<GetAllWorkflowInstanceQuery, PaginatedResult<GetAllPagedWorkflowInstanceResponse>>
    {
        private readonly IUnitOfWork<Int64> _unitOfWork;

        public GetAllWorkflowInstanceQueryHandler(IUnitOfWork<Int64> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PaginatedResult<GetAllPagedWorkflowInstanceResponse>> Handle(GetAllWorkflowInstanceQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Models.Workflows.WorkflowInstance, GetAllPagedWorkflowInstanceResponse>> expression = e => new GetAllPagedWorkflowInstanceResponse
            {
                Id = e.Id,
                DateDebut = e.DateDebut,
                DateFin = e.DateFin,
                DateInitiation = e.DateInitiation,
                JoursDemandes = e.JoursDemandes,
                JoursDisponibles = e.JoursDisponibles,
                Statut = e.Statut,
                WorkflowInstantiatorUserId = e.WorkflowInstantiatorUserId,
                WorkflowsId = e.WorkflowsId,
                WorkflowName = e.Workflow.NomWorkflow,
                WorkflowUserName = e.Workflow.NomWorkflow
            };
            var workflowInstanceFilterSpec = new WorkflowInstanceFilterSpecification(request.SearchString);
            if (request.OrderBy?.Any() != true)
            {
                var data = await _unitOfWork.Repository<Models.Workflows.WorkflowInstance>().Entities
                   .Specify(workflowInstanceFilterSpec)
                   .Select(expression)
                   .ToPaginatedListAsync(request.PageNumber, request.PageSize);
                return data;
            }
            else
            {
                var ordering = string.Join(",", request.OrderBy); // of the form fieldname [ascending|descending], ...
                var data = await _unitOfWork.Repository<Models.Workflows.WorkflowInstance>().Entities
                   .Specify(workflowInstanceFilterSpec)
                   .OrderBy(ordering) // require system.linq.dynamic.core
                   .Select(expression)
                   .ToPaginatedListAsync(request.PageNumber, request.PageSize);
                return data;

            }
        }
    }
}