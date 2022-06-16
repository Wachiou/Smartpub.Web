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
    public class GetAllWorkflowInstanceActionsQuery : IRequest<PaginatedResult<GetAllPagedWorkflowInstanceActionsResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public string[] OrderBy { get; set; } // of the form fieldname [ascending|descending],fieldname [ascending|descending]...

        public GetAllWorkflowInstanceActionsQuery(int pageNumber, int pageSize, string searchString, string orderBy)
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

    internal class GetAllWorkflowInstanceActionsQueryHandler : IRequestHandler<GetAllWorkflowInstanceActionsQuery, PaginatedResult<GetAllPagedWorkflowInstanceActionsResponse>>
    {
        private readonly IUnitOfWork<Int64> _unitOfWork;

        public GetAllWorkflowInstanceActionsQueryHandler(IUnitOfWork<Int64> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PaginatedResult<GetAllPagedWorkflowInstanceActionsResponse>> Handle(GetAllWorkflowInstanceActionsQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Models.Workflows.WorkflowInstanceActions, GetAllPagedWorkflowInstanceActionsResponse>> expression = e => new GetAllPagedWorkflowInstanceActionsResponse
            {
                Id = e.Id,
                DateAction = e.DateAction,
                Commentaire   = e.Commentaire,
                ActionExecutedByUserID = e.ActionExecutedByUserID,
                ActionExecutedByUserMatricule = e.ActionExecutedByUser.Matricule,
                ActionExecutedByUserName = e.ActionExecutedByUser.UserName,
                WorkflowInstanceDateDebut = e.WorkflowInstance.DateDebut,
                WorkflowInstanceDateFin = e.WorkflowInstance.DateFin,
                StateAfter = e.StateAfter,
                StateBefore = e.StateBefore,
                WorkflowInstanceJoursDemandes = e.WorkflowInstance.JoursDemandes,
                WorkflowInstanceJoursDisponibles = e.WorkflowInstance.JoursDisponibles,
                WorkflowInstanceNomWorkflow = e.WorkflowInstance.Workflow.NomWorkflow,
                WorkflowInstanceId = e.WorkflowInstanceId
            };
            var workflowInstanceFilterSpec = new WorkflowInstanceActionsFilterSpecification(request.SearchString);
            if (request.OrderBy?.Any() != true)
            {
                var data = await _unitOfWork.Repository<Models.Workflows.WorkflowInstanceActions>().Entities
                   .Specify(workflowInstanceFilterSpec)
                   .Select(expression)
                   .ToPaginatedListAsync(request.PageNumber, request.PageSize);
                return data;
            }
            else
            {
                var ordering = string.Join(",", request.OrderBy); // of the form fieldname [ascending|descending], ...
                var data = await _unitOfWork.Repository<Models.Workflows.WorkflowInstanceActions>().Entities
                   .Specify(workflowInstanceFilterSpec)
                   .OrderBy(ordering) // require system.linq.dynamic.core
                   .Select(expression)
                   .ToPaginatedListAsync(request.PageNumber, request.PageSize);
                return data;

            }
        }
    }
}