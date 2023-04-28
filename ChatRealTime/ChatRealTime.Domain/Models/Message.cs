using System.ComponentModel.DataAnnotations;

namespace ChatRealTime.Domain.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public AppUser FromUser { get; set; }
        public string FromUserId { get; set; }
        public AppUser? ToUser { get; set; }
        public string? ToUserId { get; set; }
        public int? ToRoomId { get; set; }
        public Room? ToRoom { get; set; }
    }
}
