using MVWorkflows.Application.Interfaces.Common;
using MVWorkflows.Application.Requests.Identity;
using MVWorkflows.Application.Responses.Identity;
using MVWorkflows.Shared.Wrapper;
using System.Threading.Tasks;

namespace MVWorkflows.Application.Interfaces.Services.Identity
{
    public interface ITokenService : IService
    {
        Task<Result<TokenResponse>> LoginAsync(TokenRequest model);

        Task<Result<TokenResponse>> GetRefreshTokenAsync(RefreshTokenRequest model);
    }
}