using MediatR;
using Microsoft.Extensions.Localization;
using MVWorkflows.Application.Interfaces.Repositories;
using MVWorkflows.Shared.Wrapper;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MVWorkflows.Application.Features.WorkflowInstance.Commands.Delete
{
    public class DeleteWorkflowInstanceCommand : IRequest<Result<Int64>>
    {
        public Int64 Id { get; set; }
    }

    internal class DeleteWorkflowInstanceCommandHandler : IRequestHandler<DeleteWorkflowInstanceCommand, Result<Int64>>
    {
        private readonly IUnitOfWork<Int64> _unitOfWork;
        private readonly IStringLocalizer<DeleteWorkflowInstanceCommandHandler> _localizer;

        public DeleteWorkflowInstanceCommandHandler(IUnitOfWork<Int64> unitOfWork, IStringLocalizer<DeleteWorkflowInstanceCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _localizer = localizer;
        }

        public async Task<Result<Int64>> Handle(DeleteWorkflowInstanceCommand command, CancellationToken cancellationToken)
        {
            var workflowInstance = await _unitOfWork.Repository<Models.Workflows.WorkflowInstance>().GetByIdAsync(command.Id);
            if (workflowInstance != null)
            {
                await _unitOfWork.Repository<Models.Workflows.WorkflowInstance>().DeleteAsync(workflowInstance);
                await _unitOfWork.Commit(cancellationToken);
                return await Result<Int64>.SuccessAsync(workflowInstance.Id, _localizer["Flux de travail supprimé"]);
            }
            else
            {
                return await Result<Int64>.FailAsync(_localizer["Flux de travail non trouvé!"]);
            }
        }
    }
}
