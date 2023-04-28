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
                cfg.CreateMap<Room, RoomDTO>();
            });

            _mapper = config.CreateMapper();
        }

        public Room MapToRequest(RoomDTO room)
         => _mapper.Map<Room>(room);

        public RoomDTO MapToResponse(Room model)
            => _mapper.Map<RoomDTO>(model);

        public IEnumerable<RoomDTO> MapToResponse(IEnumerable<Room> model)
           => _mapper.Map<IEnumerable<RoomDTO>>(model);


    }
}
