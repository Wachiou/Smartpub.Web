using System;
using AutoMapper;
using MVWorkflows.Application.Features.Workflows.Queries.GetAll;


namespace MVWorkflows.Application.AutoMapperResolvers.Workflows
{  
    public class WorkflowsGetAllUserImageUrlResolver : IValueResolver<Models.Workflows.Workflows, GetAllWorkflowsResponse, String>
    {
        string IValueResolver<Models.Workflows.Workflows, GetAllWorkflowsResponse, string>.Resolve(Models.Workflows.Workflows source, GetAllWorkflowsResponse destination, string destMember, ResolutionContext context)
        {
            return source.WorkflowOwnerUser.ProfilePictureDataUrl;
        }
    } 
}
