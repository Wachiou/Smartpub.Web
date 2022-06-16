using AutoMapper;
using MVWorkflows.Application.Requests.Identity;
using MVWorkflows.Application.Responses.Identity;

namespace MVWorkflows.Client.Infrastructure.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<PermissionResponse, PermissionRequest>().ReverseMap();
            CreateMap<RoleClaimResponse, RoleClaimRequest>().ReverseMap();
        }
    }
}