using ChatRealTime.Application.DTO.DTO;

namespace ChatRealTime.Application.Interfaces
{
    public interface IUploadAppService
    {
        Task<(MessageDTO, int)> UploadArquivoAsync(UploadDTO uploadDTO, string identityName, string webRootPath);
    }
}
