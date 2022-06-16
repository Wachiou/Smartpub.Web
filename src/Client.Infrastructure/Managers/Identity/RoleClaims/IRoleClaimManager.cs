﻿using System.Collections.Generic;
using System.Threading.Tasks;
using MVWorkflows.Application.Requests.Identity;
using MVWorkflows.Application.Responses.Identity;
using MVWorkflows.Shared.Wrapper;

namespace MVWorkflows.Client.Infrastructure.Managers.Identity.RoleClaims
{
    public interface IRoleClaimManager : IManager
    {
        Task<IResult<List<RoleClaimResponse>>> GetRoleClaimsAsync();

        Task<IResult<List<RoleClaimResponse>>> GetRoleClaimsByRoleIdAsync(string roleId);

        Task<IResult<string>> SaveAsync(RoleClaimRequest role);

        Task<IResult<string>> DeleteAsync(string id);
    }
}