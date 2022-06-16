using AutoMapper;
using MVWorkflows.Application.Features.Products.Commands.AddEdit;
using MVWorkflows.Domain.Entities.Catalog;

namespace MVWorkflows.Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<AddEditProductCommand, Product>().ReverseMap();
        }
    }
}