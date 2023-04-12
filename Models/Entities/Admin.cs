namespace Car4EgarAPI.Models.Entities
{
    public class Admin
    {
        public string AdminID { get; set; }
        public string AdminName { get; set; }
        public string AdminPassword { get; set; }
        public string AdminEmail { get; set; }
        public virtual ICollection<AdminRequest> AdminRequests { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
