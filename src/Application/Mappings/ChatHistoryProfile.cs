using AutoMapper;
using MVWorkflows.Application.Interfaces.Chat;
using MVWorkflows.Application.Models.Chat;
using MVWorkflows.Application.Models.Identity;

namespace MVWorkflows.Application.Mappings
{
    public class ChatHistoryProfile : Profile
    {
        public ChatHistoryProfile()
        {
            CreateMap<ChatHistory<IChatUser>, ChatHistory<BlazorHeroUser>>().ReverseMap();
        }
    }
}