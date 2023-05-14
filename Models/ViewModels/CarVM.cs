using Car4EgarAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Car4EgarAPI.Models.ViewModels
{
    public class CarVM
    {
        [Key]
        public string VIN { get; set; } 
        public string Color { get; set; } = "Un Defined";
        [BindNever]
        public double Rate { get; set; }
        [BindNever]
        public int RatedPeople { get; set; }
        public string Mailage { get; set; } = "Un Defined";
        public int Year { get; set; } = 2010;
        [BindNever]
        public bool Available { get; set; } = true;
        public string ModelName { get; set; } = "Un Defined";
        //public string BrandName { get; set; }
        public string LocationOfRent { get; set; } = "Un Defined";
        public double CostPerDay { get; set; } = 100;
        [BindNever]
        public string Image { get; set; } = "DefaultCarLogo.png";
        public bool Insurance { get; set; } = true;
        public string GearBoxType { get; set; } = "Un Defined";
        //public bool IsActivated { get; set; }
        public string OwnerId { get; set; }
        [BindNever]
        public string OwnerPic { get; set; } = "avatar-placeholder.png";
        [BindNever]
        public string OwnerName { get; set; }
        [BindNever]
        public string OwnerPhone { get; set; }

    }
}
