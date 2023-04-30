using ChatRealTime.Application.DTO.DTO;
using ChatRealTime.Application.Interfaces;
using ChatRealTime.Domain.Core.Interfaces;
using ChatRealTime.Domain.Models;
using System.Text.RegularExpressions;

namespace ChatRealTime.Application.Services
{
    public class UploadAppService : IUploadAppService
    {
        private readonly IUserService _userService;
        private readonly IRoomService _roomService;
        private readonly IMessageService _messageService;
        private readonly IMessageMapper _messageMapper;

        public UploadAppService(IUserService userService, IRoomService roomService, IMessageService messageService)
        {
            _userService = userService;
            _roomService = roomService;
            _messageService = messageService;
        }

        public async Task<(MessageDTO, int)> UploadArquivoAsync(UploadDTO uploadDTO, string identityName, string webRootPath)
        {
            var user = await _userService.ObterUsuarioIdentityAsync(identityName);
            var room = await _roomService.ObterSalaPorIdAsync(uploadDTO.RoomId);

            var fileName = DateTime.Now.ToString("yyyymmddMMss") + "_" + Path.GetFileName(uploadDTO.File.FileName);
            var folderPath = Path.Combine(webRootPath, "uploads");
            var filePath = Path.Combine(folderPath, fileName);
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await uploadDTO.File.CopyToAsync(fileStream);
            }

            string htmlImage = string.Format(
               "<a href=\"/uploads/{0}\" target=\"_blank\">" +
               "<img src=\"/uploads/{0}\" class=\"post-image\">" +
               "</a>", fileName);

            var message = new Message()
            {
                Content = Regex.Replace(htmlImage, @"(?i)<(?!img|a|/a|/img).*?>", string.Empty),
                Timestamp = DateTime.Now,
                FromUser = user,
                ToRoom = room
            };

            await _messageService.IncluirMessagemAsync(message);

            return  new (_messageMapper.MapToResponse(message), room.Id);
        }
    }
}
