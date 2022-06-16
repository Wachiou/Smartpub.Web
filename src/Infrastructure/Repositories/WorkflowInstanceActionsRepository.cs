using MVWorkflows.Application.Interfaces.Repositories;
using MVWorkflows.Application.Models.Workflows;
using System;


namespace MVWorkflows.Infrastructure.Repositories
{
    public class WorkflowInstanceActionsRepository : IWorkflowInstanceActionsRepository
    {
        private readonly IRepositoryAsync<WorkflowInstanceActions, Int64> _repository;

        public WorkflowInstanceActionsRepository(IRepositoryAsync<WorkflowInstanceActions, Int64> repository)
        {
            _repository = repository;
        }
    }
}
