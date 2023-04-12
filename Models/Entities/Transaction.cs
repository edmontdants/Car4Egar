namespace Car4EgarAPI.Models.Entities
{
    public class Transaction
    {
        public int TID { get; set; }
        public int RentID { get; set; }
        public string SenderID { get; set; }
        public string RecieverID { get; set; }
        public string Status { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public string TypeOfTrans { get; set; }
        public string TypeOfPay { get; set; }
    }
}
