using MVWorkflows.Application.Interfaces.Repositories;
using MVWorkflows.Application.Models.Workflows;
using MVWorkflows.Shared.Wrapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MVWorkflows.Application.Features.Workflows.Queries.GetWorkflowImage
{
    public class GetWorkflowsImageQuery : IRequest<Result<string>>
    {
        public int Id { get; set; }

        public GetWorkflowsImageQuery(int workflowId)
        {
            Id = workflowId;
        }
    }

    internal class GetWorkflowsImageQueryHandler : IRequestHandler<GetWorkflowsImageQuery, Result<string>>
    {
        private readonly IUnitOfWork<int> _unitOfWork;

        public GetWorkflowsImageQueryHandler(IUnitOfWork<int> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<string>> Handle(GetWorkflowsImageQuery request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.Repository<MVWorkflows.Application.Models.Workflows.Workflows>().Entities.Where(p => p.Id == request.Id).Select(a => a.WorkflowImageUrl).FirstOrDefaultAsync(cancellationToken);
            return await Result<string>.SuccessAsync(data: data);
        }
    }
}
