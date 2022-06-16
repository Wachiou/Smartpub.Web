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

namespace MVWorkflows.Application.Features.WorkflowInstance.Commands.AddEdit
{
    public partial class AddEditWorkflowInstanceCommand : IRequest<Result<Int64>>
    {
        public Int64 Id { get; set; }
        [Required]
        public int WorkflowsId { get; set; }
        [Required]
        public string WorkflowInstantiatorUserId { get; set; }
        [Required]
        public DateTime DateInitiation { get; set; }
        [Required]
        public DateTime DateDebut { get; set; }
        [Required]
        public DateTime DateFin { get; set; }
        [Required]
        public int JoursDisponibles { get; set; }
        [Required]
        public int JoursDemandes { get; set; }
        [Required]
        public String Statut { get; set; }
    }

    internal class AddEditWorkflowInstanceCommandHandler : IRequestHandler<AddEditWorkflowInstanceCommand, Result<Int64>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<Int64> _unitOfWork;
        //private readonly IUploadService _uploadService;
        private readonly IStringLocalizer<AddEditWorkflowInstanceCommandHandler> _localizer;

        public AddEditWorkflowInstanceCommandHandler(IUnitOfWork<Int64> unitOfWork, IMapper mapper, IStringLocalizer<AddEditWorkflowInstanceCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            //_uploadService = uploadService;
            _localizer = localizer;
        }

        public async Task<Result<Int64>> Handle(AddEditWorkflowInstanceCommand command, CancellationToken cancellationToken)
        {
            //if (await _unitOfWork.Repository<Models.Workflows.WorkflowInstance>().Entities.Where(p => p.Id != command.Id)
            //    .AnyAsync(p => p.Barcode == command.Barcode, cancellationToken))
            //{
            //    return await Result<int>.FailAsync(_localizer["Barcode already exists."]);
            //}

            //var uploadRequest = command.UploadRequest;
            //if (uploadRequest != null)
            //{
            //    uploadRequest.FileName = $"P-{command.Barcode}{uploadRequest.Extension}";
            //}

            if (command.Id == 0)
            {
                var workflowInstance = _mapper.Map<Models.Workflows.WorkflowInstance>(command);                
                await _unitOfWork.Repository<Models.Workflows.WorkflowInstance>().AddAsync(workflowInstance);
                await _unitOfWork.Commit(cancellationToken);
                return await Result<Int64>.SuccessAsync(workflowInstance.Id, _localizer["Flux de travail enregistré"]);
            }
            else
            {
                var workflowInstance = await _unitOfWork.Repository<Models.Workflows.WorkflowInstance>().GetByIdAsync(command.Id);
                if (workflowInstance != null)
                {
                    workflowInstance.WorkflowInstantiatorUserId = command.WorkflowInstantiatorUserId ?? workflowInstance.WorkflowInstantiatorUserId;
                    workflowInstance.WorkflowsId = (command.WorkflowsId == 0) ? workflowInstance.WorkflowsId : command.WorkflowsId;
                    workflowInstance.DateInitiation = command.DateInitiation;
                    workflowInstance.DateDebut = command.DateDebut;
                    workflowInstance.DateFin = command.DateFin;
                    workflowInstance.JoursDisponibles = command.JoursDisponibles;
                    workflowInstance.JoursDemandes = command.JoursDemandes;
                    workflowInstance.Statut = workflowInstance.Statut ?? command.Statut;
                    await _unitOfWork.Repository<Models.Workflows.WorkflowInstance>().UpdateAsync(workflowInstance);
                    await _unitOfWork.Commit(cancellationToken);
                    return await Result<Int64>.SuccessAsync(workflowInstance.Id, _localizer["Flux de travail mis à jour"]);
                }
                else
                {
                    return await Result<Int64>.FailAsync(_localizer["Flux de travail non trouvé!"]);
                }
            }
        }
    }
}
