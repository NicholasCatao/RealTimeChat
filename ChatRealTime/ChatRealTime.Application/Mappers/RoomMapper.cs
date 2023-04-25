using AutoMapper;
using ChatRealTime.Application.DTO.DTO;
using ChatRealTime.Application.Interfaces;
using ChatRealTime.Domain.Models;

namespace ChatRealTime.Application.Mappers
{
    public class RoomMapper : IRoomMapper
    {
        private readonly IMapper _mapper;

        public RoomMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RoomModel, RoomDTO>();
            });

            _mapper = config.CreateMapper();
        }

        public RoomDTO MapToResponse(RoomModel model)
            => _mapper.Map<RoomDTO>(model);
    }
}
