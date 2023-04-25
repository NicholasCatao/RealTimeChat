namespace ChatRealTime.Domain.Models
{
    public class RoomModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AppUserModel Admin { get; set; }
        public ICollection<MessageModel> Messages { get; set; }
    }
}
