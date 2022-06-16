using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MVWorkflows.Application.Interfaces.Repositories;
using MVWorkflows.Application.Models.RH;
using MVWorkflows.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using MVWorkflows.Shared.Constants.Application;

namespace MVWorkflows.Application.Features.TypeGroupement.Commands.AddEdit
{
    public class AddEditTypeGroupementCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        [Required]
        public string NomTypeGroupement { get; set; }

        [Required]
        public string IntituleTypeGroupement { get; set; }

        [Required]
        public string DescriptionTypeGroupement { get; set; }
    }

    internal class AddEditTypeGroupementCommandHandler : IRequestHandler<AddEditTypeGroupementCommand, Result<int>>
    {
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<AddEditTypeGroupementCommandHandler> _localizer;
        private readonly IUnitOfWork<int> _unitOfWork;

        public AddEditTypeGroupementCommandHandler(IUnitOfWork<int> unitOfWork, IMapper mapper, IStringLocalizer<AddEditTypeGroupementCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _localizer = localizer;
        }

        public async Task<Result<int>> Handle(AddEditTypeGroupementCommand command, CancellationToken cancellationToken)
        {
            if (command.Id == 0)
            {
                var typeGroupement = _mapper.Map<MVWorkflows.Application.Models.RH.TypeGroupement>(command);
                await _unitOfWork.Repository<MVWorkflows.Application.Models.RH.TypeGroupement>().AddAsync(typeGroupement);
                await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllTypeGroupementCacheKey);
                return await Result<int>.SuccessAsync(typeGroupement.Id, _localizer["Type groupement enregistré"]);
            }
            else
            {
                var typeGroupement = await _unitOfWork.Repository<MVWorkflows.Application.Models.RH.TypeGroupement>().GetByIdAsync(command.Id);
                if (typeGroupement != null)
                {
                    typeGroupement.NomTypeGroupement = command.NomTypeGroupement ?? typeGroupement.NomTypeGroupement;
                    typeGroupement.IntituleTypeGroupement = command.IntituleTypeGroupement ?? typeGroupement.IntituleTypeGroupement;
                    typeGroupement.DescriptionTypeGroupement = command.DescriptionTypeGroupement ?? typeGroupement.DescriptionTypeGroupement;

                    await _unitOfWork.Repository<MVWorkflows.Application.Models.RH.TypeGroupement>().UpdateAsync(typeGroupement);
                    await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllTypeGroupementCacheKey);
                    return await Result<int>.SuccessAsync(typeGroupement.Id, _localizer["Type groupement mis à jour"]);
                }
                else
                {
                    return await Result<int>.FailAsync(_localizer["Type Groupement non trouvé!"]);
                }
            }
        }
    }
}
