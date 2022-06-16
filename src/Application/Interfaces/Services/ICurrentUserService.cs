using MVWorkflows.Application.Interfaces.Common;

namespace MVWorkflows.Application.Interfaces.Services
{
    public interface ICurrentUserService : IService
    {
        string UserId { get; }
    }
}