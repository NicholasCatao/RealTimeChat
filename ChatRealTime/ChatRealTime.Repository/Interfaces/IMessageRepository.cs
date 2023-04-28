using ChatRealTime.Domain.Models;

namespace ChatRealTime.Repository.Interfaces
{
    public interface IMessageRepository
    {
        Task IncluirMessagemAsync(Message message);
        Task<Message> ObterMensagemAsync(int id);
        Task<IEnumerable<Message>> ObterMessagensSalaAsync(int idSala);
    }
}
