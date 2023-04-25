using AutoMapper;
using ChatRealTime.Application.DTO.DTO;
using ChatRealTime.Application.Interfaces;
using ChatRealTime.Domain.Models;

namespace ChatRealTime.Application.Mappers
{
    public class UserMapper : IUserMapper
    {
        private readonly IMapper _mapper;

        public UserMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AppUserModel, UserDTO>();
            });

            _mapper = config.CreateMapper();
        }

        public UserDTO MapToResponse(AppUserModel model)
            => _mapper.Map<UserDTO>(model);
    }
}
