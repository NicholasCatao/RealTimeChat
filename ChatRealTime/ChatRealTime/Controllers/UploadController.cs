using AutoMapper;
using ChatRealTime.Application.DTO.DTO;
using ChatRealTime.Application.Interfaces;
using ChatRealTime.Domain.Models;
using ChatRealTime.Helpers;
using ChatRealTime.Hubs;
using ChatRealTime.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace ChatRealTime.Controllers
{
    public class UploadController : ControllerBase
    {
        private readonly int FileSizeLimit;
        private readonly string[] AllowedExtensions;
        private readonly IWebHostEnvironment _environment;
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly IFileValidator _fileValidator;
        private readonly IUploadAppService _uploadAppService;

  

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload([FromForm] UploadDTO upload)
        {
            if (ModelState.IsValid)
            {
                if (!_fileValidator.IsValid(upload.File))
                    return BadRequest("Validation failed!");

                var message = await _uploadAppService.UploadArquivoAsync(upload, User.Identity.Name, _environment.WebRootPath);

                await _hubContext.Clients.Group(message.Item2.ToString()).SendAsync("newMessage", message.Item1);

                return Ok();
            }

            return BadRequest();
        }

    }
}
