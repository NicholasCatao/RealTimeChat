﻿using AutoMapper;
using ChatRealTime.Application.DTO.DTO;
using ChatRealTime.Application.Interfaces;
using ChatRealTime.Domain.Models;

namespace ChatRealTime.Application.Mappers
{
    public class MessageMapper : IMessageMapper
    {
        private readonly IMapper _mapper;

        public MessageMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MessageModel, MessageDTO>();
            });

            _mapper = config.CreateMapper();
        }

        public MessageDTO MapToResponse(MessageModel model)
            => _mapper.Map<MessageDTO>(model);
    }
}
