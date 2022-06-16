using MediatR;
using Microsoft.Extensions.Localization;
using MVWorkflows.Application.Features.WorkflowInstance.Commands.Delete;
using MVWorkflows.Application.Interfaces.Repositories;
using MVWorkflows.Shared.Wrapper;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MVWorkflows.Application.Features.WorkflowInstanceActions.Commands.Delete
{
    internal class DeleteWorkflowInstanceActionsCommand : IRequest<Result<Int64>>
    {
        public Int64 Id { get; set; }
    }

    internal class DeleteWorkflowInstanceActionsCommandHandler : IRequestHandler<DeleteWorkflowInstanceActionsCommand, Result<Int64>>
    {
        private readonly IUnitOfWork<Int64> _unitOfWork;
        private readonly IStringLocalizer<DeleteWorkflowInstanceActionsCommandHandler> _localizer;

        public DeleteWorkflowInstanceActionsCommandHandler(IUnitOfWork<Int64> unitOfWork, IStringLocalizer<DeleteWorkflowInstanceActionsCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _localizer = localizer;
        }

        public async Task<Result<Int64>> Handle(DeleteWorkflowInstanceActionsCommand command, CancellationToken cancellationToken)
        {
            var workflowInstanceActions = await _unitOfWork.Repository<Models.Workflows.WorkflowInstanceActions>().GetByIdAsync(command.Id);
            if (workflowInstanceActions != null)
            {
                await _unitOfWork.Repository<Models.Workflows.WorkflowInstanceActions>().DeleteAsync(workflowInstanceActions);
                await _unitOfWork.Commit(cancellationToken);
                return await Result<Int64>.SuccessAsync(workflowInstanceActions.Id, _localizer["Etape de validation supprimé"]);
            }
            else
            {
                return await Result<Int64>.FailAsync(_localizer["Etape de validation non trouvé!"]);
            }
        }
    }
}
