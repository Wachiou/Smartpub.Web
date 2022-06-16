using MVWorkflows.Application.Interfaces.Repositories;
using MVWorkflows.Application.Models.RH;


namespace MVWorkflows.Infrastructure.Repositories
{
    public class TypeGroupementRepository : ITypeGroupementRepository
    {
        private readonly IRepositoryAsync<TypeGroupement, int> _repository;

        public TypeGroupementRepository(IRepositoryAsync<TypeGroupement, int> repository)
        {
            _repository = repository;
        }
    }
}
