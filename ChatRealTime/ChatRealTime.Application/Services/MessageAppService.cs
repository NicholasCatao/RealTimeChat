using ChatRealTime.Application.Interfaces;
using ChatRealTime.Domain.Core.Interfaces;
using ChatRealTime.Domain.Models;

namespace ChatRealTime.Application.Services
{
    public class MessageAppService : IMessageAppService
    {
        private readonly IMessageService _messageService;

        public MessageAppService(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task IncluirMessagemAsync(Message message)
       => await _messageService.IncluirMessagemAsync(message);
    }
}
