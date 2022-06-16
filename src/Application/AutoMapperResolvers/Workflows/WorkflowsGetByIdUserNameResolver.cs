using AutoMapper;
using MVWorkflows.Application.Features.Workflows.Queries.GetById;
using System;

namespace MVWorkflows.Application.AutoMapperResolvers.Workflows
{
    public class WorkflowsGetByIdUserNameResolver : IValueResolver<Models.Workflows.Workflows, GetWorkflowsByIdResponse, String>
    {
        string IValueResolver<Models.Workflows.Workflows, GetWorkflowsByIdResponse, string>.Resolve(Models.Workflows.Workflows source, GetWorkflowsByIdResponse destination, string destMember, ResolutionContext context)
        {            
            return source.WorkflowOwnerUser.UserName;
        }
    }
}
