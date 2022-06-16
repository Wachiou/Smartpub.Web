using AutoMapper;
using MVWorkflows.Application.Features.Documents.Commands.AddEdit;
using MVWorkflows.Application.Features.Documents.Queries.GetById;
using MVWorkflows.Domain.Entities.Misc;

namespace MVWorkflows.Application.Mappings
{
    public class DocumentProfile : Profile
    {
        public DocumentProfile()
        {
            CreateMap<AddEditDocumentCommand, Document>().ReverseMap();
            CreateMap<GetDocumentByIdResponse, Document>().ReverseMap();
        }
    }
}