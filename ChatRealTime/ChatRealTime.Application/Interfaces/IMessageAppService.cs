using ChatRealTime.Application.DTO.DTO;
using ChatRealTime.Domain.Models;

namespace ChatRealTime.Application.Interfaces
{
    public interface IMessageAppService
    {
        Task<MessageDTO> CriarMessagemAsync(string usuarioNome, string sala, string conteudoMessagem);
        Task IncluirMessagemAsync(Message message);
        Task<MessageDTO> ObterMensagemAsync(int id);
        Task<IEnumerable<MessageDTO>> ObterMessagensSalaAsync(int idSala);
    }
}
