using Car4EgarAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Car4EgarAPI.Models.ViewModels
{
    public class CarVM
    {
        [Key]
        public string VIN { get; set; } 
        public string Color { get; set; }
        [BindNever]
        public double Rate { get; set; }
        [BindNever]
        public int RatedPeople { get; set; }
        public string Mailage { get; set; }
        public int Year { get; set; }
        [BindNever]
        public bool Available { get; set; }
        public string ModelName { get; set; }
        //public string BrandName { get; set; }
        public string LocationOfRent { get; set; }
        public double CostPerDay { get; set; }
        [BindNever]
        public string Image { get; set; }
        public bool Insurance { get; set; }
        public string GearBoxType { get; set; }
        //public bool IsActivated { get; set; }
        public string OwnerId { get; set; }
        [BindNever]
        public string OwnerPic { get; set; }
        [BindNever]
        public string OwnerName { get; set; }
        [BindNever]
        public string OwnerPhone { get; set; }

    }
}
