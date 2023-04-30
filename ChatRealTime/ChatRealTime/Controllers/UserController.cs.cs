using ChatRealTime.Application.Interfaces;
using ChatRealTime.Domain.Models;
using ChatRealTime.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ChatRealTime.Controllers
{
    public class UserController: Controller
    {
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly IUserAppService _userAppService;

        public UserController(IHubContext<ChatHub> hubContext, IUserAppService userAppService)
        {
            _hubContext = hubContext;
            _userAppService = userAppService;
        }

        [HttpGet]
        public async Task<IEnumerable<AppUser>> ObterUsuariosAsync()
            => await _userAppService.ObterUsuariosAsync();
    }
}
