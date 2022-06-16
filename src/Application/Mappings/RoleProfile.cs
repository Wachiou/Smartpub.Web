using AutoMapper;
using MVWorkflows.Application.Models.Identity;
using MVWorkflows.Application.Responses.Identity;

namespace MVWorkflows.Application.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleResponse, BlazorHeroRole>().ReverseMap();
        }
    }
}