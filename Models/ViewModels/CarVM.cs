using Car4EgarAPI.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Car4EgarAPI.Models.ViewModels
{
    public class CarVM
    {
        [Key]
        public string VIN { get; set; } 
        public string Color { get; set; }
        public double Rate { get; set; }
        public int RatedPeople { get; set; }
        public double Mailage { get; set; }
        public string CarType { get; set; }
        public int Year { get; set; }
        public bool Available { get; set; }
        public string ModelName { get; set; }
        public string BrandName { get; set; }
        public string LocationOfRent { get; set; }
        public double CostPerDay { get; set; }
        public string Image { get; set; }
        public bool Insurance { get; set; }
        public string GearBoxType { get; set; }
        public bool IsActivated { get; set; }
        public string OwnerId { get; set; }
        public string OwnerPic { get; set; }
        public string OwnerName { get; set; }

    }
}
