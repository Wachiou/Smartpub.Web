using MVWorkflows.Application.Interfaces.Common;
using MVWorkflows.Application.Requests.Identity;
using MVWorkflows.Shared.Wrapper;
using System.Threading.Tasks;

namespace MVWorkflows.Application.Interfaces.Services.Account
{
    public interface IAccountService : IService
    {
        Task<IResult> UpdateProfileAsync(UpdateProfileRequest model, string userId);

        Task<IResult> ChangePasswordAsync(ChangePasswordRequest model, string userId);

        Task<IResult<string>> GetProfilePictureAsync(string userId);

        Task<IResult<string>> UpdateProfilePictureAsync(UpdateProfilePictureRequest request, string userId);
    }
}