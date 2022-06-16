using AutoMapper;
using MVWorkflows.Application.Models.Audit;
using MVWorkflows.Application.Responses.Audit;

namespace MVWorkflows.Application.Mappings
{
    public class AuditProfile : Profile
    {
        public AuditProfile()
        {
            CreateMap<AuditResponse, Audit>().ReverseMap();
        }
    }
}