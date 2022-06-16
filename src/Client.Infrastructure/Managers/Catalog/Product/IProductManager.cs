using MVWorkflows.Application.Features.Products.Commands.AddEdit;
using MVWorkflows.Application.Features.Products.Queries.GetAllPaged;
using MVWorkflows.Application.Requests.Catalog;
using MVWorkflows.Shared.Wrapper;
using System.Threading.Tasks;

namespace MVWorkflows.Client.Infrastructure.Managers.Catalog.Product
{
    public interface IProductManager : IManager
    {
        Task<PaginatedResult<GetAllPagedProductsResponse>> GetProductsAsync(GetAllPagedProductsRequest request);

        Task<IResult<string>> GetProductImageAsync(int id);

        Task<IResult<int>> SaveAsync(AddEditProductCommand request);

        Task<IResult<int>> DeleteAsync(int id);

        Task<IResult<string>> ExportToExcelAsync(string searchString = "");
    }
}