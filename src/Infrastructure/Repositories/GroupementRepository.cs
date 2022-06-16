using MVWorkflows.Application.Interfaces.Repositories;
using MVWorkflows.Application.Models.RH;


namespace MVWorkflows.Infrastructure.Repositories
{
    public class GroupementRepository : IGroupementRepository
    {
        private readonly IRepositoryAsync<Groupement, int> _repository;

        public GroupementRepository(IRepositoryAsync<Groupement, int> repository)
        {
            _repository = repository;
        }
    }
}
