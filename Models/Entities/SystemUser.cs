namespace Car4EgarAPI.Models.Entities
{
    public class SystemUser
    {
        public string NID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }   
        public string Role { get; set; }
        public bool IsActivated { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Bank_CardNumber { get; set; }
        public string Bank_ExpireDate { get; set; }
        public string Bank_CSC { get; set; }
        public string Photo { get; set; }
        public double Balance { get; set; }
        public double Fine { get; set; }
        public double Rate { get; set; }
        public int RatedPeople { get; set; }
        public virtual Rent? Rent { get; set; }
        public virtual ICollection<Notification>? Notifications { get; set; }
        public virtual ICollection<Car>? Cars { get; set; } = new HashSet<Car>();
        public virtual ICollection<RentRequest>? OwnerRequests { get; set; }


    }
}
