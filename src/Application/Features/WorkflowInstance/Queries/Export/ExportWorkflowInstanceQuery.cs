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

namespace MVWorkflows.Application.Features.WorkflowInstance.Queries
{
    public class ExportWorkflowInstanceActionsQuery : IRequest<Result<string>>
    {
        public string SearchString { get; set; }

        public ExportWorkflowInstanceActionsQuery(string searchString = "")
        {
            SearchString = searchString;
        }
    }

    internal class ExportWorkflowInstanceQueryHandler : IRequestHandler<ExportWorkflowInstanceActionsQuery, Result<string>>
    {
        private readonly IExcelService _excelService;
        private readonly IUnitOfWork<Int64> _unitOfWork;
        private readonly IStringLocalizer<ExportWorkflowInstanceQueryHandler> _localizer;

        public ExportWorkflowInstanceQueryHandler(IExcelService excelService
            , IUnitOfWork<Int64> unitOfWork
            , IStringLocalizer<ExportWorkflowInstanceQueryHandler> localizer)
        {
            _excelService = excelService;
            _unitOfWork = unitOfWork;
            _localizer = localizer;
        }

        public async Task<Result<string>> Handle(ExportWorkflowInstanceActionsQuery request, CancellationToken cancellationToken)
        {
            var workflowInstanceFilterSpec = new WorkflowInstanceFilterSpecification(request.SearchString);
            var WorkflowInstance = await _unitOfWork.Repository<Models.Workflows.WorkflowInstance>().Entities
                .Specify(workflowInstanceFilterSpec)
                .ToListAsync(cancellationToken);
            var data = await _excelService.ExportAsync(WorkflowInstance, mappers: new Dictionary<string, Func<Models.Workflows.WorkflowInstance, object>>
            {
                { _localizer["Id"], item => item.Id },
                { _localizer["Créer par"], item => item.WorkflowInstantiatorUserId },
                { _localizer["Date Création"], item => item.DateInitiation },
                { _localizer["Date debut"], item => item.DateDebut },
                { _localizer["Date fin"], item => item.DateFin },
                { _localizer["Nombre de jours disponibles"], item => item.JoursDisponibles },
                { _localizer["Nombre de jours demandes"], item => item.JoursDemandes },
                { _localizer["Statut"], item => item.Statut },
                { _localizer["Date fin"], item => item.DateFin },
                { _localizer["Type de Workflow"], item => item.Workflow.NomWorkflow }
            }, sheetName: _localizer["WorkflowInstance"]);

            return await Result<string>.SuccessAsync(data: data);
        }
    }
}
