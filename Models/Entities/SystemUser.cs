namespace Car4EgarAPI.Models.Entities
{
    public class SystemUser
    {
        public string NID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }   
        public string Phone { get; set; }
        //public string Name { get; set; }
        public string Role { get; set; }
        public bool IsActivated { get; set; }
    }
}
