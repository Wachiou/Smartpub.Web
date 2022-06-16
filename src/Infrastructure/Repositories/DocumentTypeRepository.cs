using MVWorkflows.Application.Interfaces.Repositories;
using MVWorkflows.Domain.Entities.Misc;

namespace MVWorkflows.Infrastructure.Repositories
{
    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        private readonly IRepositoryAsync<DocumentType, int> _repository;

        public DocumentTypeRepository(IRepositoryAsync<DocumentType, int> repository)
        {
            _repository = repository;
        }
    }
}