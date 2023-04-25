using ChatRealTime.Domain.Core.Interfaces;
using ChatRealTime.Domain.Models;
using ChatRealTime.Repository.Interfaces;

namespace ChatRealTime.Domain.Services.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository) => _messageRepository = messageRepository;

      public async  Task IncluirMessagemAsync(MessageModel message)
        =>  await  _messageRepository.IncluirMessagemAsync(message);
    }
}
