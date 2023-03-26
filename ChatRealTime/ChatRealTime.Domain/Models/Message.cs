using System.ComponentModel.DataAnnotations;

namespace ChatRealTime.Domain.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }
        [Required]
        public string Text { get; set; }

        public DateTime dateTime { get; set; }

        public string Userid { get; set; }
        public virtual AppUser Sender { get; set; }
    }
}
