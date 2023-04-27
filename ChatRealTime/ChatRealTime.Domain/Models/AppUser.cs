using Microsoft.AspNetCore.Identity;

namespace ChatRealTime.Domain.Models
{
    public class AppUser : IdentityUser
    {

        public AppUser() 
        {
            Messages = new HashSet<Message>();
        }

        public string FullName { get; set; }
        public string Avatar { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
