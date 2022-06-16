using MVWorkflows.Application.Interfaces.Common;
using MVWorkflows.Application.Requests.Identity;
using MVWorkflows.Application.Responses.Identity;
using MVWorkflows.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVWorkflows.Application.Interfaces.Services.Identity
{
    public interface IRoleService : IService
    {
        Task<Result<List<RoleResponse>>> GetAllAsync();

        Task<int> GetCountAsync();

        Task<Result<RoleResponse>> GetByIdAsync(string id);

        Task<Result<string>> SaveAsync(RoleRequest request);

        Task<Result<string>> DeleteAsync(string id);

        Task<Result<PermissionResponse>> GetAllPermissionsAsync(string roleId);

        Task<Result<string>> UpdatePermissionsAsync(PermissionRequest request);
    }
}