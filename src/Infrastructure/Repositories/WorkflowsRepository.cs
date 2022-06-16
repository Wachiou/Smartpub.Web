using MVWorkflows.Application.Interfaces.Repositories;
using MVWorkflows.Application.Models.Workflows;


namespace MVWorkflows.Infrastructure.Repositories
{
    public class WorkflowsRepository : IWorkflowsRepository
    {
        private readonly IRepositoryAsync<Workflows, int> _repository;

        public WorkflowsRepository(IRepositoryAsync<Workflows, int> repository)
        {
            _repository = repository;
        }
    }
}
