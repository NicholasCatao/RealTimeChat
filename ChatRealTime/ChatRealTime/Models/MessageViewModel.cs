﻿using System.ComponentModel.DataAnnotations;

namespace ChatRealTime.Models
{
    public class MessageViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public string FromUserName { get; set; }
        public string FromFullName { get; set; }
        [Required]
        public string Room { get; set; }
        public string Avatar { get; set; }

        public string ToUserId { get; set; }
    }
}
