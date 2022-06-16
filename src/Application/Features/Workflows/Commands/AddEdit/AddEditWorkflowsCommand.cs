using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MVWorkflows.Application.Interfaces.Repositories;
using MVWorkflows.Application.Models.Workflows;
using MVWorkflows.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using MVWorkflows.Shared.Constants.Application;
using System;
using MVWorkflows.Application.Requests;
using MVWorkflows.Application.Interfaces.Services;

namespace MVWorkflows.Application.Features.Workflows.Commands.AddEdit
{
    public partial class AddEditWorkflowsCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        [Required]
        public string NomWorkflow { get; set; }
        [Required]
        public string DescriptionWorkflow { get; set; }
        [Required]
        public string TitleWorkflow { get; set; }
        [Required]
        public string WorkflowOwnerUserID { get; set; }
        public string WorkflowImageUrl { get; set; }
        public UploadRequest UploadRequest { get; set; }

        //[Required]
        //public int IdTypeWorkflow { get; set; }
        //[Required]
        //public DateTime DateDebut { get; set; }
        //[Required]
        //public DateTime DateFin { get; set; }
        //[Required]
        //public string Statut { get; set; }

    }

    internal class AddEditWorkflowsCommandHandler : IRequestHandler<AddEditWorkflowsCommand, Result<int>>
    {
        private readonly IMapper _mapper;
        private readonly IUploadService _uploadService;
        private readonly IStringLocalizer<AddEditWorkflowsCommandHandler> _localizer;
        private readonly IUnitOfWork<int> _unitOfWork;

        public AddEditWorkflowsCommandHandler(IUnitOfWork<int> unitOfWork, IMapper mapper, IUploadService uploadService, IStringLocalizer<AddEditWorkflowsCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _uploadService = uploadService;
            _localizer = localizer;
        }

        public async Task<Result<int>> Handle(AddEditWorkflowsCommand command, CancellationToken cancellationToken)
        {
            var uploadRequest = command.UploadRequest;
            if (uploadRequest != null)
            {
                uploadRequest.FileName = $"W-{command.UploadRequest.FileName}-{DateTime.Now.ToString("ddMMyyyyHHmmss")}-{uploadRequest.Extension}";
            }

            if (command.Id == 0)
            {
                var workflows = _mapper.Map<MVWorkflows.Application.Models.Workflows.Workflows>(command);
                if (uploadRequest != null)
                {
                    workflows.WorkflowImageUrl = _uploadService.UploadAsync(uploadRequest);
                }
                await _unitOfWork.Repository<MVWorkflows.Application.Models.Workflows.Workflows>().AddAsync(workflows);
                //await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllWorkflowsCacheKey);
                await _unitOfWork.Commit(cancellationToken);
                return await Result<int>.SuccessAsync(workflows.Id, _localizer["Workflow enregistré"]);
            }
            else
            {
                var workflows = await _unitOfWork.Repository<MVWorkflows.Application.Models.Workflows.Workflows>().GetByIdAsync(command.Id);
                if (workflows != null)
                {                    
                    workflows.NomWorkflow = command.NomWorkflow ?? workflows.NomWorkflow;
                    workflows.DescriptionWorkflow = command.DescriptionWorkflow ?? workflows.DescriptionWorkflow;
                    if (uploadRequest != null)
                    {
                        workflows.WorkflowImageUrl = _uploadService.UploadAsync(uploadRequest);
                    }
                    workflows.WorkflowOwnerUserID = command.WorkflowOwnerUserID ?? workflows.WorkflowOwnerUserID;
                    workflows.TitleWorkflow = command.TitleWorkflow ?? workflows.TitleWorkflow;
                    await _unitOfWork.Repository<MVWorkflows.Application.Models.Workflows.Workflows>().UpdateAsync(workflows);
                    await _unitOfWork.Commit(cancellationToken);
                    return await Result<int>.SuccessAsync(workflows.Id, _localizer["Workflow mis à jour"]);
                }
                else
                {
                    return await Result<int>.FailAsync(_localizer["Workflow non trouvé!"]);
                }
            }
        }
    }
}