namespace Car4EgarAPI.Models.Entities
{
    public class Borrower
    {
        public string NID { get; set; } //NID
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //public string Type { get; set; }
        public string PhoneNumber { get; set; }
        public string Bank_CardNumber { get; set; }
        public string Bank_ExpireDate { get; set; }
        public string Bank_CSC { get; set; }
        public string Photo { get; set; }
        public double Balance { get; set; }
        public double Fine { get; set; }
        public double Rate { get; set; }
        public int RatedPeople { get; set; }
        public bool IsActivated { get; set; }
        public virtual Rent? Rent { get; set; }
        public virtual ICollection<Notification>? Notifications { get; set; }
    }
}
