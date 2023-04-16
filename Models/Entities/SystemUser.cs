using System.Text.Json.Serialization;

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
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }          //
        public string BirthDate { get; set; }
        public string Photo { get; set; } 
        public string IdentityPhoto { get; set; }    //
        public string DriverLicencePhoto { get; set; } //
        public string DriverLicenceNumber { get; set; } //
        public string DriverLicenceEXDate { get; set; }  //
        public string Bank_AccountNumber { get; set; }  //
        public string Bank_NID { get; set; }            //
        public string Bank_Name { get; set; }           //
        public string Bank_Branch { get; set; }         //
        public string Card_EXDate { get; set; }         //
        public string Card_Number { get; set; }         //
        public string Card_CVC{ get; set; }             //
        public string Card_HolderName { get; set; }     //
        public double? Balance { get; set; }
        public double? Fine { get; set; }
        public double? Rate { get; set; }
        public int RatedPeople { get; set; }
        [JsonIgnore]
        public virtual Rent? Rent { get; set; }
        [JsonIgnore]
        public virtual ICollection<Notification>? Notifications { get; set; }
        [JsonIgnore]
        public virtual ICollection<Car>? Cars { get; set; } = new HashSet<Car>();
        [JsonIgnore]
        public virtual ICollection<RentRequest>? OwnerRequests { get; set; }


    }
}
