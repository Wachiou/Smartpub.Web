using AutoMapper;
using MVWorkflows.Application.Features.DocumentTypes.Commands.AddEdit;
using MVWorkflows.Application.Features.DocumentTypes.Queries.GetAll;
using MVWorkflows.Application.Features.DocumentTypes.Queries.GetById;
using MVWorkflows.Domain.Entities.Misc;

namespace MVWorkflows.Application.Mappings
{
    public class DocumentTypeProfile : Profile
    {
        public DocumentTypeProfile()
        {
            CreateMap<AddEditDocumentTypeCommand, DocumentType>().ReverseMap();
            CreateMap<GetDocumentTypeByIdResponse, DocumentType>().ReverseMap();
            CreateMap<GetAllDocumentTypesResponse, DocumentType>().ReverseMap();
        }
    }
}