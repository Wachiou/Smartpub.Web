using MVWorkflows.Application.Features.Documents.Commands.AddEdit;
using MVWorkflows.Application.Features.Documents.Queries.GetAll;
using MVWorkflows.Application.Requests.Documents;
using MVWorkflows.Shared.Wrapper;
using System.Threading.Tasks;
using MVWorkflows.Application.Features.Documents.Queries.GetById;

namespace MVWorkflows.Client.Infrastructure.Managers.Misc.Document
{
    public interface IDocumentManager : IManager
    {
        Task<PaginatedResult<GetAllDocumentsResponse>> GetAllAsync(GetAllPagedDocumentsRequest request);

        Task<IResult<GetDocumentByIdResponse>> GetByIdAsync(GetDocumentByIdQuery request);

        Task<IResult<int>> SaveAsync(AddEditDocumentCommand request);

        Task<IResult<int>> DeleteAsync(int id);
    }
}