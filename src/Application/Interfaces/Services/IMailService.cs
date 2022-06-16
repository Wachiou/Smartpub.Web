using MVWorkflows.Application.Requests.Mail;
using System.Threading.Tasks;

namespace MVWorkflows.Application.Interfaces.Services
{
    public interface IMailService
    {
        Task SendAsync(MailRequest request);
    }
}