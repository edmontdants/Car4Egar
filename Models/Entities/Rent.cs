namespace Car4EgarAPI.Models.Entities
{
    public class Rent
    {
        public int RentID { get; set; }
        public string Status { get; set; }
        //public double RentAmount { get; set; }
        //public double AdditionalAmount { get; set; }
        public int RentTotalDays { get; set; }
        public double TotalAmount { get; set; }
        //public double Fine { get; set; }
        //public DateTime StartData { get; set; }
        public DateTime? EndtData { get; set; }
        public DateTime? ActualEndData { get; set; }
        //public string Afforded { get; set; }
        public double MeterStart { get; set; }
        public double MeterEnd { get; set; }
        //public double PromoDiscount { get; set; }
        public virtual ICollection<Car> Cars { get; set; } = new HashSet<Car>();
        public virtual ICollection<SystemUser> Users { get; set; } = new HashSet<SystemUser>();

    }
}
