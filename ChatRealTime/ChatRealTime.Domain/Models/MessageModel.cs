using System.ComponentModel.DataAnnotations;

namespace ChatRealTime.Domain.Models
{
    public class MessageModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public AppUserModel FromUser { get; set; }
        public string FromUserId { get; set; }
        public AppUserModel? ToUser { get; set; }
        public string? ToUserId { get; set; }
        public int? ToRoomId { get; set; }
        public RoomModel? ToRoom { get; set; }
    }
}
