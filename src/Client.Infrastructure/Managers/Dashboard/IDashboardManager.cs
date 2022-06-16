using MVWorkflows.Shared.Wrapper;
using System.Threading.Tasks;
using MVWorkflows.Application.Features.Dashboards.Queries.GetData;

namespace MVWorkflows.Client.Infrastructure.Managers.Dashboard
{
    public interface IDashboardManager : IManager
    {
        Task<IResult<DashboardDataResponse>> GetDataAsync();
    }
}