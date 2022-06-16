using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MVWorkflows.Application.Interfaces.Repositories;
using MVWorkflows.Shared.Wrapper;
using MediatR;
using System.Threading;
using Microsoft.Extensions.Localization;
namespace MVWorkflows.Application.Features.WorkflowInstanceActions.Commands.AddEdit
{
    public class AddEditWorkflowInstanceActionsCommand : IRequest<Result<Int64>>
    {
        public Int64 Id { get; set; }
        [Required]
        public string ActionExecutedByUserID { get; set; }
        [Required]
        public Int64 WorkflowInstanceId { get; set; }
        [Required]
        public string StateBefore { get; set; }
        [Required]
        public string StateAfter { get; set; }
        public string Commentaire { get; set; }
        //public DateTime DateEffetNouvelEtat { get; set; }
    }

    internal class AddEditWorkflowInstanceActionsCommandHandler : IRequestHandler<AddEditWorkflowInstanceActionsCommand, Result<Int64>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<Int64> _unitOfWork;
        private readonly IStringLocalizer<AddEditWorkflowInstanceActionsCommandHandler> _localizer;

        public AddEditWorkflowInstanceActionsCommandHandler(IUnitOfWork<Int64> unitOfWork, IMapper mapper, IStringLocalizer<AddEditWorkflowInstanceActionsCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            //_uploadService = uploadService;
            _localizer = localizer;
        }

        public async Task<Result<Int64>> Handle(AddEditWorkflowInstanceActionsCommand command, CancellationToken cancellationToken)
        {

            if (command.Id == 0)
            {
                var workflowInstanceActions = _mapper.Map<Models.Workflows.WorkflowInstanceActions>(command);
                await _unitOfWork.Repository<Models.Workflows.WorkflowInstanceActions>().AddAsync(workflowInstanceActions);
                await _unitOfWork.Commit(cancellationToken);
                return await Result<Int64>.SuccessAsync(workflowInstanceActions.Id, _localizer["Etape de validation enregistré"]);
            }
            else
            {
                var workflowInstanceActions = await _unitOfWork.Repository<Models.Workflows.WorkflowInstanceActions>().GetByIdAsync(command.Id);
                if (workflowInstanceActions != null)
                {
                    workflowInstanceActions.ActionExecutedByUserID = command.ActionExecutedByUserID ?? workflowInstanceActions.ActionExecutedByUserID;
                    workflowInstanceActions.WorkflowInstanceId = (command.WorkflowInstanceId == 0) ? workflowInstanceActions.WorkflowInstanceId : command.WorkflowInstanceId;
                    workflowInstanceActions.StateBefore = workflowInstanceActions.StateBefore ?? command.StateBefore;
                    workflowInstanceActions.StateAfter = workflowInstanceActions.StateAfter ?? command.StateAfter;
                    workflowInstanceActions.Commentaire = workflowInstanceActions.Commentaire ?? command.Commentaire;

                    await _unitOfWork.Repository<Models.Workflows.WorkflowInstanceActions>().UpdateAsync(workflowInstanceActions);
                    await _unitOfWork.Commit(cancellationToken);
                    return await Result<Int64>.SuccessAsync(workflowInstanceActions.Id, _localizer["Etape de validation mis à jour"]);
                }
                else
                {
                    return await Result<Int64>.FailAsync(_localizer["Etape de validation non trouvé!"]);
                }
            }
        }
    }
}
