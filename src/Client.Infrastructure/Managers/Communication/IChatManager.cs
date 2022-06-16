using MVWorkflows.Application.Models.Chat;
using MVWorkflows.Application.Responses.Identity;
using MVWorkflows.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using MVWorkflows.Application.Interfaces.Chat;

namespace MVWorkflows.Client.Infrastructure.Managers.Communication
{
    public interface IChatManager : IManager
    {
        Task<IResult<IEnumerable<ChatUserResponse>>> GetChatUsersAsync();

        Task<IResult> SaveMessageAsync(ChatHistory<IChatUser> chatHistory);

        Task<IResult<IEnumerable<ChatHistoryResponse>>> GetChatHistoryAsync(string cId);
    }
}