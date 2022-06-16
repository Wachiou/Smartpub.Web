
using MVWorkflows.Application.Interfaces.Repositories;
using MVWorkflows.Application.Models.Workflows;
using MVWorkflows.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using MVWorkflows.Shared.Constants.Application;

namespace MVWorkflows.Application.Features.Workflows.Commands.Delete
{
    public class DeleteWorkflowsCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    internal class DeleteWorkflowsCommandHandler : IRequestHandler<DeleteWorkflowsCommand, Result<int>>
    {
        private readonly IWorkflowInstanceRepository _workflowInstanceRepository;
        private readonly IStringLocalizer<DeleteWorkflowsCommandHandler> _localizer;
        private readonly IUnitOfWork<int> _unitOfWork;

        public DeleteWorkflowsCommandHandler(IUnitOfWork<int> unitOfWork, IWorkflowInstanceRepository workflowInstanceRepository, IStringLocalizer<DeleteWorkflowsCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _workflowInstanceRepository = workflowInstanceRepository;
            _localizer = localizer;
        }

        public async Task<Result<int>> Handle(DeleteWorkflowsCommand command, CancellationToken cancellationToken)
        {
            var isBrandUsed = await _workflowInstanceRepository.IsWorkflowInstanceUsed(command.Id);
            if (!isBrandUsed)
            {
                var workflows = await _unitOfWork.Repository<MVWorkflows.Application.Models.Workflows.Workflows>().GetByIdAsync(command.Id);
                if (workflows != null)
                {
                    await _unitOfWork.Repository<MVWorkflows.Application.Models.Workflows.Workflows>().DeleteAsync(workflows);
                    await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllWorkflowsCacheKey);
                    return await Result<int>.SuccessAsync(workflows.Id, _localizer["Workflow Supprimé"]);
                }
                else
                {
                    return await Result<int>.FailAsync(_localizer["Workflow Non Trouvé!"]);
                }
            }
            else
            {
                return await Result<int>.FailAsync(_localizer["Suppression non autorisé"]);
            }
        }
    }
}
