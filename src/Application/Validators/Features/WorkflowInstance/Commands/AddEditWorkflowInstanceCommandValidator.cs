using FluentValidation;
using Microsoft.Extensions.Localization;
using MVWorkflows.Application.Features.WorkflowInstance.Commands.AddEdit;

namespace MVWorkflows.Application.Validators.Features.WorkflowInstance.Commands
{
    public class AddEditWorkflowInstanceCommandValidator : AbstractValidator<AddEditWorkflowInstanceCommand>
    {
        public AddEditWorkflowInstanceCommandValidator(IStringLocalizer<AddEditWorkflowInstanceCommandValidator> localizer)
        {
            //RuleFor(request => request.Workflo)
            //    .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage(x => localizer["Le nom est obligatoire!"]);
            //RuleFor(request => request.DescriptionWorkflow)
            //    .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage(x => localizer["La description est obligatoire!"]);
            //RuleFor(request => request.WorkflowOwnerUserID)
            //    .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage(x => localizer["Le personnel responsable du workflows est obligatoire!"]);
        }
    }
}
