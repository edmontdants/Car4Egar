namespace Car4EgarAPI.Models.Entities
{
    public class RentRequest
    {
        public int Id { get; set; }
        public string OwnerId { get; set; }
        public string BorrowerId { get; set; }
        public string BorrowerName { get; set; }
        public string BorrowerAddress { get; set; }
        public string RequestedCarVIN { get; set; }
        public string CarImage { get; set; }
        public string BorrowerImage { get; set; }
        public string CarBrand { get; set; }
        public int CarYear { get; set; }
        public int RentDays { get; set; }

        public bool RequestAcceptance { get; set; }
    }
}
