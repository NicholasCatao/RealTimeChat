﻿using ChatRealTime.Domain.Models;

namespace ChatRealTime.Application.Interfaces
{
    public interface IMessageAppService
    {
        Task IncluirMessagemAsync(MessageModel message);
    }
}
