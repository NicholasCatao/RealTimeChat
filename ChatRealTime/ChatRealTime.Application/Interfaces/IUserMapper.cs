using ChatRealTime.Application.DTO.DTO;
using ChatRealTime.Domain.Models;

namespace ChatRealTime.Application.Interfaces
{
    public interface IUserMapper
    {
        public UserDTO MapToResponse(AppUser model);
    }
}
