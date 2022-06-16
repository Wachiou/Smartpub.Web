using MVWorkflows.Application.Features.Workflows.Commands.AddEdit;
using MVWorkflows.Application.Features.Workflows.Queries.GetAll;
using MVWorkflows.Client.Infrastructure.Extensions;
using MVWorkflows.Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MVWorkflows.Client.Infrastructure.Managers.Workflows.Workflows
{
    public class WorkflowsManager : IWorkflowsManager
    {
        private readonly HttpClient _httpClient;

        public WorkflowsManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IResult<int>> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{Routes.WorkflowsEndpoints.Delete}/{id}");
            return await response.ToResult<int>();
        }

        public async Task<IResult<string>> ExportToExcelAsync(string searchString)
        {
            var response = await _httpClient.GetAsync(string.IsNullOrWhiteSpace(searchString)
                ? Routes.WorkflowsEndpoints.Export
                : Routes.WorkflowsEndpoints.ExportFiltered(searchString));
            return await response.ToResult<string>();
        }

        public async Task<IResult<List<GetAllWorkflowsResponse>>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync(Routes.WorkflowsEndpoints.GetAll);
            return await response.ToResult<List<GetAllWorkflowsResponse>>();
        }

        public async Task<IResult<string>> GetWorkflowImageAsync(int id)
        {
            var response = await _httpClient.GetAsync(Routes.WorkflowsEndpoints.GetWorkflowImage(id));
            return await response.ToResult<string>();
        }

        public async Task<IResult<int>> SaveAsync(AddEditWorkflowsCommand request)
        {
            var response = await _httpClient.PostAsJsonAsync(Routes.WorkflowsEndpoints.Save, request);
            return await response.ToResult<int>();
        }
    }
}
