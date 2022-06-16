using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MVWorkflows.Application.Extensions;
using MVWorkflows.Application.Interfaces.Repositories;
using MVWorkflows.Application.Interfaces.Services;
using MVWorkflows.Application.Specifications.Workflows;
using MVWorkflows.Application.Models.Workflows;
using MVWorkflows.Shared.Wrapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace MVWorkflows.Application.Features.Workflows.Queries.Export
{
    public class ExportWorkflowsQuery : IRequest<Result<string>>
    {
        public string SearchString { get; set; }

        public ExportWorkflowsQuery(string searchString = "")
        {
            SearchString = searchString;
        }
    }

    internal class ExportWorkflowsQueryHandler : IRequestHandler<ExportWorkflowsQuery, Result<string>>
    {
        private readonly IExcelService _excelService;
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IStringLocalizer<ExportWorkflowsQueryHandler> _localizer;

        public ExportWorkflowsQueryHandler(IExcelService excelService
            , IUnitOfWork<int> unitOfWork
            , IStringLocalizer<ExportWorkflowsQueryHandler> localizer)
        {
            _excelService = excelService;
            _unitOfWork = unitOfWork;
            _localizer = localizer;
        }

        public async Task<Result<string>> Handle(ExportWorkflowsQuery request, CancellationToken cancellationToken)
        {
            var workflowFilterSpec = new WorkflowsFilterSpecification(request.SearchString);
            var workflows = await _unitOfWork.Repository<MVWorkflows.Application.Models.Workflows.Workflows>().Entities
                .Specify(workflowFilterSpec)
                .ToListAsync(cancellationToken);
            var data = await _excelService.ExportAsync(workflows, mappers: new Dictionary<string, Func<MVWorkflows.Application.Models.Workflows.Workflows, object>>
            {
                { _localizer["Id"], item => item.Id },
                { _localizer["Nom du Workflow"], item => item.NomWorkflow },
                { _localizer["responsable du workflow"], item => item.WorkflowOwnerUser },
                { _localizer["Description du Workflow"], item => item.DescriptionWorkflow },
                { _localizer["Url de l'image du Workflow"], item => item.WorkflowImageUrl }
            }, sheetName: _localizer["Workflows"]);

            return await Result<string>.SuccessAsync(data: data);
        }
    }
}
