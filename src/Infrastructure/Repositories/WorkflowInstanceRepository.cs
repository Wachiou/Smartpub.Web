using System;
using MVWorkflows.Application.Interfaces.Repositories;
using MVWorkflows.Application.Models.Workflows;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MVWorkflows.Infrastructure.Repositories
{
    public class WorkflowInstanceRepository: IWorkflowInstanceRepository
    {
        private readonly IRepositoryAsync<WorkflowInstance, Int64> _repository;

        public WorkflowInstanceRepository(IRepositoryAsync<WorkflowInstance, Int64> repository)
        {
            _repository = repository;
        }
        public async Task<bool> IsWorkflowInstanceUsed(int workflowsId)
        {
            return await _repository.Entities.AnyAsync(b => b.WorkflowsId == workflowsId);
        }
    }
}
