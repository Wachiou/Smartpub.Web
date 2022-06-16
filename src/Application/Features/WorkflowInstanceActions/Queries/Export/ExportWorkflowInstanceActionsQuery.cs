using MVWorkflows.Application.Interfaces.Repositories;
using MVWorkflows.Application.Interfaces.Services;
using MVWorkflows.Application.Models.Workflows;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MVWorkflows.Application.Extensions;
using MVWorkflows.Application.Specifications.Workflows;
using MVWorkflows.Shared.Wrapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace MVWorkflows.Application.Features.WorkflowInstanceActions.Queries
{
    public class ExportWorkflowInstanceActionsQuery : IRequest<Result<string>>
    {
        public string SearchString { get; set; }

        public ExportWorkflowInstanceActionsQuery(string searchString = "")
        {
            SearchString = searchString;
        }
    }

    internal class ExportWorkflowInstanceActionsQueryHandler : IRequestHandler<ExportWorkflowInstanceActionsQuery, Result<string>>
    {
        private readonly IExcelService _excelService;
        private readonly IUnitOfWork<Int64> _unitOfWork;
        private readonly IStringLocalizer<ExportWorkflowInstanceActionsQueryHandler> _localizer;

        public ExportWorkflowInstanceActionsQueryHandler(IExcelService excelService
            , IUnitOfWork<Int64> unitOfWork
            , IStringLocalizer<ExportWorkflowInstanceActionsQueryHandler> localizer)
        {
            _excelService = excelService;
            _unitOfWork = unitOfWork;
            _localizer = localizer;
        }

        public async Task<Result<string>> Handle(ExportWorkflowInstanceActionsQuery request, CancellationToken cancellationToken)
        {
            var workflowInstanceActionsFilterSpec = new WorkflowInstanceActionsFilterSpecification(request.SearchString);
            var WorkflowInstanceActions = await _unitOfWork.Repository<Models.Workflows.WorkflowInstanceActions>().Entities
                .Specify(workflowInstanceActionsFilterSpec)
                .ToListAsync(cancellationToken);
            var data = await _excelService.ExportAsync(WorkflowInstanceActions, mappers: new Dictionary<string, Func<Models.Workflows.WorkflowInstanceActions, object>>
            {
                { _localizer["Id"], item => item.Id },
                { _localizer["Créer par"], item => item.WorkflowInstanceId },
                { _localizer["Date Création"], item => item.ActionExecutedByUserID },
                { _localizer["Date debut"], item => item.ActionExecutedByUser.UserName },
                { _localizer["Date fin"], item => item.WorkflowInstance.DateInitiation },
                { _localizer["Nombre de jours disponibles"], item => item.WorkflowInstance.JoursDisponibles },
                { _localizer["Nombre de jours demandes"], item => item.WorkflowInstance.JoursDemandes },
                { _localizer["Statut"], item => item.WorkflowInstance.DateDebut },
                { _localizer["Date fin"], item => item.WorkflowInstance.DateFin },
                { _localizer["Date fin"], item => item.WorkflowInstance.Statut },
                { _localizer["Date fin"], item => item.StateBefore },
                { _localizer["Date fin"], item => item.StateAfter },
                //{ _localizer["Type de Workflow"], item => item.Workflow.NomWorkflow }
            }, sheetName: _localizer["WorkflowInstanceActions"]);

            return await Result<string>.SuccessAsync(data: data);
        }
    }
}
