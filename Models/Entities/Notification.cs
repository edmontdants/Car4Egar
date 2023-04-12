namespace Car4EgarAPI.Models.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
        public bool Readed { get; set; }
    }
}
