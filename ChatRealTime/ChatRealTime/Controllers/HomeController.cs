using ChatRealTime.Application.Services;
using ChatRealTime.Domain.Models;
using ChatRealTime.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ChatRealTime.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly UserAppService _userAppService;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

       

      //public async Task<IActionResult> Create(Message message)
      //  {
      //      if(ModelState.IsValid)
      //      {
      //          message.UserName = User.Identity.Name;
      //          var sender = await _userManager.GetUserAsync(User);
      //          message.Userid = sender.Id;
      //          await _userAppService.CreateMessageAsync(message);
      //          return Ok();
      //      }
      
      //      return BadRequest();
      //  }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}