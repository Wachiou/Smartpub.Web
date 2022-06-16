using MVWorkflows.Application.Requests;

namespace MVWorkflows.Application.Interfaces.Services
{
    public interface IUploadService
    {
        string UploadAsync(UploadRequest request);
    }
}