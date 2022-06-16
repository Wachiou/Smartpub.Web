using AutoMapper;
using MVWorkflows.Application.AutoMapperResolvers.Workflows;
using MVWorkflows.Application.Features.Workflows.Commands.AddEdit;
using MVWorkflows.Application.Features.Workflows.Queries.GetAll;
using MVWorkflows.Application.Features.Workflows.Queries.GetById;
using MVWorkflows.Application.Models.Workflows;


namespace MVWorkflows.Application.Mappings
{
    public class WorkflowsProfile: Profile
    {
        public WorkflowsProfile()
        {
            CreateMap<AddEditWorkflowsCommand, Workflows>().ReverseMap();
            CreateMap<GetWorkflowsByIdResponse, Workflows>().ReverseMap()
                .ForMember(dest => dest.WorkflowOwnerUser, opt => opt.MapFrom<WorkflowsGetByIdUserNameResolver>())
                .ForMember(dest => dest.WorkflowOwnerUserImageUrl, opt => opt.MapFrom<WorkflowsGetByIdUserImageUrlResolver>()); ;
            CreateMap<GetAllWorkflowsResponse, Workflows>().ReverseMap()
                .ForMember(dest => dest.WorkflowOwnerUser, opt => opt.MapFrom<WorkflowsGetAllUserNameResolver>())
                .ForMember(dest => dest.WorkflowOwnerUserImageUrl, opt => opt.MapFrom<WorkflowsGetAllUserImageUrlResolver>());
        }
    }
}
