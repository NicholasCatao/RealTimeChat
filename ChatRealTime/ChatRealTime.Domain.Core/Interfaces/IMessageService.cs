using ChatRealTime.Domain.Models;

namespace ChatRealTime.Domain.Core.Interfaces
{
    public interface IMessageService
    {
        Task<IEnumerable<Message>> ObterMessagensSalaAsync(int idSala);
        Task IncluirMessagemAsync(Message message);
        Task<Message> ObterMensagemAsync(int id);
    }
}
