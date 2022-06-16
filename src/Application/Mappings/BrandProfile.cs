using AutoMapper;
using MVWorkflows.Application.Features.Brands.Commands.AddEdit;
using MVWorkflows.Application.Features.Brands.Queries.GetAll;
using MVWorkflows.Application.Features.Brands.Queries.GetById;
using MVWorkflows.Domain.Entities.Catalog;

namespace MVWorkflows.Application.Mappings
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<AddEditBrandCommand, Brand>().ReverseMap();
            CreateMap<GetBrandByIdResponse, Brand>().ReverseMap();
            CreateMap<GetAllBrandsResponse, Brand>().ReverseMap();
        }
    }
}