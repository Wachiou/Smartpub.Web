using FluentValidation;
using Microsoft.Extensions.Localization;
using MVWorkflows.Application.Features.Workflows.Commands.AddEdit;

namespace MVWorkflows.Application.Validators.Features.Workflows.Commands
{
    public class AddEditWorkflowsCommandValidator : AbstractValidator<AddEditWorkflowsCommand>
    {
        public AddEditWorkflowsCommandValidator(IStringLocalizer<AddEditWorkflowsCommandValidator> localizer)
        {
            RuleFor(request => request.NomWorkflow)
                .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage(x => localizer["Le nom est obligatoire!"]);
            RuleFor(request => request.DescriptionWorkflow)
                .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage(x => localizer["La description est obligatoire!"]);
            RuleFor(request => request.WorkflowOwnerUserID)
                .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage(x => localizer["Le personnel responsable du workflows est obligatoire!"]);           
        }
    }
}
