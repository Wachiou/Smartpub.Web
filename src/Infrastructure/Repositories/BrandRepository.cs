using MVWorkflows.Application.Interfaces.Repositories;
using MVWorkflows.Domain.Entities.Catalog;

namespace MVWorkflows.Infrastructure.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly IRepositoryAsync<Brand, int> _repository;

        public BrandRepository(IRepositoryAsync<Brand, int> repository)
        {
            _repository = repository;
        }
    }
}