using System;
using System.Collections.Generic;
using MVWorkflows.Application.Features.Workflows.Queries.GetAll;
using MVWorkflows.Shared.Wrapper; 
using System.Threading.Tasks;
using MVWorkflows.Application.Features.Workflows.Commands.AddEdit;
using MVWorkflows.Client.Infrastructure.Managers;

namespace MVWorkflows.Client.Infrastructure.Managers.Workflows.Workflows
{
    public interface IWorkflowsManager : IManager
    {
        Task<IResult<List<GetAllWorkflowsResponse>>> GetAllAsync();
        Task<IResult<string>> GetWorkflowImageAsync(int id);

        Task<IResult<int>> SaveAsync(AddEditWorkflowsCommand request);

        Task<IResult<int>> DeleteAsync(int id);

        Task<IResult<string>> ExportToExcelAsync(string searchString = "");
    }
}
