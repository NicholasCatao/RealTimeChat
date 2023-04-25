using Microsoft.AspNetCore.Identity;

namespace ChatRealTime.Domain.Models
{
    public class AppUserModel : IdentityUser
    {

        public AppUserModel() 
        {
            Messages = new HashSet<MessageModel>();
        }

        public string FullName { get; set; }
        public string Avatar { get; set; }
        public ICollection<RoomModel> Rooms { get; set; }
        public virtual ICollection<MessageModel> Messages { get; set; }
    }
}
