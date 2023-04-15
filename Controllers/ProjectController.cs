using Car4EgarAPI.Models.Context;
using Car4EgarAPI.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using System.Security.Cryptography;
using static Car4EgarAPI.BL.Validations;
namespace Car4EgarAPI.Controllers
{

    //Token In api


    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly Car4EgarContext db;
        public ProjectController(Car4EgarContext dataContext)
        {
            db = dataContext;
        }


        
        // SystemUser  SystemUser  SystemUser  SystemUser  SystemUser
        [Route("/SystemUser/RegisterNewUser")]
        [HttpPost]
        public IActionResult RegisterNewUser(SystemUser user)
        {

            if (IsNIDalid(user.NID)&&IsEmailValid(user.Email) && IsMobileValid(user.Phone) && IsPasswordValid(user.Password) && IsUserNameValid(user.UserName) && user.Role != null)
            {
                user.IsActivated = false;
                db.SystemUsers.Add(user);
                db.SaveChanges();
            }
            return Ok(user);
        }

        [HttpPost]
        [Route("/SystemUser/SendActivationRequestForUserAccount")]
        public IActionResult SendActivationRequestForUserAccount(int AdminId, int id, string fileSrc)
        {
            Admin admin = db.Admins.Find(AdminId);
            AdminRequest adminRequests = new AdminRequest();
            adminRequests.Id = Convert.ToString(id);
            adminRequests.DocumentSource = fileSrc;
            admin.AdminRequests.Add(adminRequests);
            db.SaveChanges();
            return Ok();
        }

        [HttpPost]
        [Route("/SystemUser/GetAccount")]
        public IActionResult LoginAccount(string userName, string password)
        {
            SystemUser user = db.SystemUsers.Where(a => (a.UserName == userName && a.Password == password)).First();
            return Ok(user);
        }

        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////////////////////////
        /// //////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>


        // Owners  Owners  Owners  Owners  Owners

        [HttpPost]
        [Route("/Owner/Register")]
        public IActionResult RegNewOwner(string NID, string name, string address, string bank_Card_Number, string bank_csc, string bank_EX_date , string photo)
        {
            SystemUser user = db.SystemUsers.Find(NID);
            if ( IsNameValid(name) && IsBankCardNumberValid(bank_Card_Number) && bank_EX_date != null & IsBankCSCValid(bank_csc))
            {
                SystemUser owner = new SystemUser();
                owner.Name = name;
                owner.Address = address;
                owner.NID = user.NID;
                owner.Email = user.Email;
                owner.Password = user.Password;
                owner.PhoneNumber = user.Phone;
                owner.Bank_CardNumber = bank_Card_Number;
                owner.Bank_CSC = bank_csc;
                owner.Bank_ExpireDate = bank_EX_date;
                owner.Photo = photo;
                owner.IsActivated = false;

                db.SystemUsers.Add(owner);
                db.SaveChanges();
                return Ok(owner);
            }
            return BadRequest();
        }


        [HttpPost]
        [Route("/Owner/SendActivationRequestForaCar")]
        public IActionResult SendActivationRequestForACar(int AdminId, string CarVIN, string fileSrc)
        {
            Admin admin = db.Admins.Find(AdminId);
            AdminRequest adminRequests = new AdminRequest();
            adminRequests.Id = CarVIN;
            adminRequests.DocumentSource = fileSrc;
            admin.AdminRequests.Add(adminRequests);
            db.SaveChanges();
            return Ok();
        }


        [HttpPost]
        [Route("/Owner/RegisterNewCar")]
        public IActionResult RegisterNewCar(string NID, string color, string LicenseNumber, int Seats, double Mailage, string CarType, DateTime LicenseEXDate, int Year, bool AvailableForRent, string ModelName, string BrandName, string LocationOfRent, double CostPerDay, string Image, bool Insurance, string GearBoxType)
        {
            SystemUser owner = db.SystemUsers.Find(NID);
            if (owner.IsActivated)
            {
                Car car = new Car();
                car.Color = color;
                car.LicenseNumber = LicenseNumber;
                car.Seats = Seats;
                car.Insurance = Insurance;
                car.CarType = CarType;
                car.LicenseEXDate = LicenseEXDate;
                car.Year = Year;
                car.LocationOfRent = LocationOfRent;
                car.AvailableForRent = AvailableForRent;
                car.ModelName = ModelName;
                car.BrandName = BrandName;
                car.Mailage = Mailage;
                car.GearBoxType = GearBoxType;
                car.CostPerDay = CostPerDay;
                car.Image = Image;
                car.RegistrationDate = DateTime.Now;
                car.IsActivated = false;
                owner.Cars.Add(car);
                db.Cars.Add(car); // ?!?!?!?!?!?!
                db.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("/Owner/RemoveACar")]
        public IActionResult RemoveACar(int vin)
        {
            Car car = db.Cars.Find(vin);
            db.Cars.Remove(car);
            db.SaveChanges();
            return Ok();
        }

        [HttpPost]
        [Route("/Owner/MakeTheCarNotAvailableToRent")]
        public IActionResult MakeTheCarNotAvailableToRent(int id)
        {
            Car car = db.Cars.Find(id);
            car.AvailableForRent = false;
            db.Cars.Update(car);
            db.SaveChanges();
            return Ok();
        }

        [HttpPut]
        [Route("/Owner/EditOwnerInfo")]
        public IActionResult EditOwnerInfo(string NID, string newPassword, string newEmail, string newPhone ,string newAddress, string newPhoto, string bank_Card_Number, string bank_csc, string bank_EX_date)
        {
            if ( IsEmailValid(newEmail) && IsMobileValid(newPhone) && IsPasswordValid(newPassword) && IsBankCardNumberValid(bank_Card_Number) && bank_EX_date != null && IsBankCSCValid(bank_csc) && newAddress!=null)
            {
                SystemUser owner = db.SystemUsers.Find(NID);
                owner.Password = newPassword;
                owner.Email = newEmail;
                owner.Address = newAddress;
                owner.Photo = newPhoto;
                owner.Bank_CardNumber = bank_Card_Number;
                owner.Bank_CSC = bank_csc;
                owner.Bank_ExpireDate = bank_EX_date;
                owner.PhoneNumber = newPhone;
                db.SystemUsers.Update(owner);
                db.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }


        [HttpDelete]
        [Route("/Owner/DeleteOwnerAccount")]
        public IActionResult DeleteOwnerAccount(string NID)
        {
            SystemUser owner = db.SystemUsers.Find(NID);
            db.SystemUsers.Remove(owner);
            db.SaveChanges();
            return Ok();
        }


        [HttpPost]
        [Route("/Owner/AcceptBorrowerRequest")]
        public IActionResult AcceptBorrowerRequest(int id)
        {
            RentRequest ownerRequest = db.RentRequests.Find(id);
            Car car = db.Cars.Where(c => c.VIN == ownerRequest.RequestedCarVIN).FirstOrDefault();
            SystemUser borrower = db.SystemUsers.Where(b => b.NID == ownerRequest.BorrowerId).FirstOrDefault();
            ownerRequest.RequestAcceptance = true;

            Notification notification = new Notification();
            notification.UserId = borrower.NID;
            notification.Content = "Your Request About Car: " + car.BrandName + "Accepted From Owner, Admin Will Contact With You";
            db.Notifications.Add(notification);
            db.Update(ownerRequest);
            db.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route("/Owner/GetAllRequests")]
        public IActionResult GetAllOwnerRequests(string id)
        {
            return Ok(db.RentRequests.Where(o => o.OwnerId == id).ToList());
        }

        [HttpDelete]
        [Route("/Owner/RefuseRequest")]
        public IActionResult RefuseRequest(int id)
        {
            RentRequest rentRequest = db.RentRequests.Find(id);
            db.RentRequests.Remove(rentRequest);
            db.SaveChanges();
            return Ok();
        }

        [HttpPost]
        [Route("/Owner/RatingTheBorrowers")]
        public IActionResult RatingTheBorrowers (string id, double RateDegree)
        {
            SystemUser borrower = db.SystemUsers.Find(id);
            if (RateDegree <= 5)
            {
                borrower.RatedPeople += 1;
                borrower.Rate += RateDegree / borrower.RatedPeople;
                db.Update(borrower); db.SaveChanges();
                return Ok();
            }
            return Ok();
        }

        [HttpGet]
        [Route("/Owner/GetAllOwnerNotifications")]
        public IActionResult GetAllOwnerNotifications(string id)
        {
            return Ok(db.Notifications.Where(o => o.UserId == id).ToList());
        }

        [HttpGet]
        [Route("/Owner/GetAllOwnerFines")]
        public IActionResult GetAllOwnerFines(string id)
        {
            SystemUser owner = db.SystemUsers.Find(id);
            return Ok(owner.Fine);
        }


        [HttpGet]
        [Route("/Owner/GetAllOwnerCars")]
        public IActionResult GetAllOwnerCars(string id)
        {
            SystemUser owner = db.SystemUsers.Find(id);
            return Ok(owner.Cars);
        }

        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////////////////////////
        /// //////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>


        /// Borrower   Borrower   Borrower   Borrower   Borrower

        [HttpPost]
        [Route("/Borrower/Register")]
        public IActionResult RegNewBorrower(string NID, string name, string address, string bank_Card_Number, string bank_csc, string bank_EX_date, string photo)
        {
            SystemUser user = db.SystemUsers.Find(NID);
            if ( IsNameValid(name) && IsBankCardNumberValid(bank_Card_Number) && bank_EX_date != null & IsBankCSCValid(bank_csc))
            {
                SystemUser borrower = new SystemUser();

                borrower.Name = name;
                borrower.Address = address;
                borrower.NID = user.NID;
                borrower.Email = user.Email;
                borrower.Password = user.Password;
                borrower.PhoneNumber = user.Phone;
                borrower.Bank_CardNumber = bank_Card_Number;
                borrower.Bank_CSC = bank_csc;
                borrower.Bank_ExpireDate = bank_EX_date;
                borrower.Photo = photo;
                borrower.IsActivated = false;

                db.SystemUsers.Add(borrower);
                db.SaveChanges();
                return Ok(borrower);
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("/Borrower/EditBorrowerInfo")]
        public IActionResult EditBorrowerInfo(string NID, string newPassword, string newEmail, string newPhone, string newAddress, string newPhoto, string bank_Card_Number, string bank_csc, string bank_EX_date)
        {
            if (IsEmailValid(newEmail) && IsMobileValid(newPhone) && IsPasswordValid(newPassword) && IsBankCardNumberValid(bank_Card_Number) && bank_EX_date != null && IsBankCSCValid(bank_csc) && newAddress != null)
            {
                SystemUser borrower = db.SystemUsers.Find(NID);
                borrower.Password = newPassword;
                borrower.Email = newEmail;
                borrower.Address = newAddress;
                borrower.Photo = newPhoto;
                borrower.Bank_CardNumber = bank_Card_Number;
                borrower.Bank_CSC = bank_csc;
                borrower.Bank_ExpireDate = bank_EX_date;
                borrower.PhoneNumber = newPhone;
                db.SystemUsers.Update(borrower);
                db.SaveChanges();
                return Ok();
            }
            return BadRequest();

        }


        [HttpDelete]
        [Route("/Borrower/DeleteBorrowerAccount")]
        public IActionResult DeleteBorrowerAccount(string NID)
        {
            SystemUser borrower = db.SystemUsers.Find(NID);
            db.SystemUsers.Remove(borrower);
            db.SaveChanges();
            return Ok();
        }

        [HttpPost]
        [Route("/Borrower/CarRentalRequest")]
        public IActionResult CarRentalRequest(string id,string carVin,int Days)
        {
            SystemUser borrower = db.SystemUsers.Find(id);
            if (borrower.IsActivated)
            {
                Car car = db.Cars.Find(carVin);
                SystemUser carOwner = db.SystemUsers.Where(o => o.Cars.Contains(car)).FirstOrDefault();
                RentRequest ownerRequest = new RentRequest();
                ownerRequest.RequestedCarVIN = carVin;
                ownerRequest.BorrowerId = id;
                ownerRequest.BorrowerName = db.SystemUsers.Find(id).Name;
                ownerRequest.BorrowerAddress = db.SystemUsers.Find(id).Address;
                ownerRequest.RentDays = Days;
                Notification notification = new Notification();
                notification.UserId = carOwner.NID;
                notification.Content = "You Have a New car rental request made by " + ownerRequest.BorrowerName+ " on your car";
                db.RentRequests.Add(ownerRequest);
                db.Notifications.Add(notification);
                db.SaveChanges();
                return Ok("Request Sent");
            }
            return BadRequest();

        }


        [HttpGet]
        [Route("/Borrower/GetAllRequests")]
        public IActionResult GetAllBorrowerRequests(string id)
        {
            return Ok(db.RentRequests.Where(o => o.BorrowerId == id).ToList());
        }

        [HttpDelete]
        [Route("/Borrower/DeleteRequest")]
        public IActionResult DeleteRequest(int id)
        {
            RentRequest rentRequest = db.RentRequests.Find(id);
            db.RentRequests.Remove(rentRequest);
            db.SaveChanges();
            return Ok();
        }

        [HttpPost]
        [Route("/Borrower/CarRating")]
        public IActionResult RatingTheBorrowers(int vin, double RateDegree)
        {
            Car car = db.Cars.Find(vin);
            if (RateDegree <= 5)
            {
                car.RatedPeople += 1;
                car.Rate += RateDegree / car.RatedPeople;
                db.Update(car); db.SaveChanges();
                return Ok();
            }
            return Ok();
        }


        [HttpGet]
        [Route("/Borrower/GetAllBorrowerNotifications")]
        public IActionResult GetAllBorrowerNotifications(string id)
        {
            return Ok(db.Notifications.Where(o => o.UserId == id).ToList());
        }


        [HttpGet]
        [Route("/Borrower/GetAllBorroweFines")]
        public IActionResult GetAllBorroweFines(string id)
        {
            SystemUser borrower = db.SystemUsers.Find(id);
            return Ok(borrower.Fine);
        }

        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////////////////////////
        /// //////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>

        //Admin   Admin   Admin   Admin   Admin
        [HttpPost]
        [Route("/Admin/AcceptUserActivationRequest")]
        public IActionResult AcceptUserActivationRequest(int id)
        {
            SystemUser user = db.SystemUsers.Find(id);
            user.IsActivated = true;
            db.SaveChanges();
            return Ok("Activation Success");
        }

        [HttpPost]
        [Route("/Admin/AcceptCarActivationRequest")]
        public IActionResult SendActivationRequestForACar(string CarVIN)
        {
            Car car = db.Cars.Find(CarVIN);
            car.IsActivated = true;
            db.SaveChanges();
            return Ok("Activation Success");
        }

        [HttpGet]
        [Route("/Admin/GetAllRequests")]
        public IActionResult GetAllAdminRequests()
        {
            var adminRequests = db.AdminRequests.ToList();
            return Ok(adminRequests);
        }

        [HttpGet]
        [Route("/Admin/GetAllActivatedUsers")]
        public IActionResult GetAllActivatedUsers()
        {
            var ActivatedUsers = db.SystemUsers.Where(u => u.IsActivated == true).ToList();
            return Ok(ActivatedUsers);
        }

        [HttpGet]
        [Route("/Admin/GetAllActivatedCars")]
        public IActionResult GetAllActivatedCars()
        {
            var ActivatedCars = db.Cars.Where(c => c.IsActivated == true).ToList();
            return Ok(ActivatedCars);
        }

        [HttpGet]
        [Route("/Admin/GetAllRequestsToAccept")]
        public IActionResult GetAllRequestsToAccept() 
        {
            var requests = db.RentRequests.Where(r => r.RequestAcceptance == true).ToList();    
            return Ok(requests);
        }


        [HttpPost]
        [Route("/Admin/AcceptRentRequest")]
        public IActionResult AcceptRentRequest(int id, double MeterStart, DateTime endDate)
        {
            Rent rent = new Rent();
            RentRequest request = db.RentRequests.Find(id);
            Car car = db.Cars.Where(c => c.VIN == request.RequestedCarVIN).FirstOrDefault();
            rent.TotalAmount = request.RentDays * car.CostPerDay;
            rent.MeterStart = MeterStart;
            rent.EndtData = endDate;
            car.AvailableForRent = false;
            db.Update(car);
            db.Rents.Add(rent);
            db.SaveChanges();
            return Ok();
        }

        [HttpPost]
        [Route("/Admin/FineApplication")]
        public IActionResult FineApplication(string id, double fineAmount)
        {
            SystemUser borrower = db.SystemUsers.Find(id);
            if (borrower == null)
            {
                SystemUser owner = db.SystemUsers.Find(id);
                owner.Fine += fineAmount;
                db.SaveChanges();
            }
            else
            {
                borrower.Fine += fineAmount;
                db.SaveChanges();
            }
            return Ok();
        }

        [HttpGet]
        [Route("/Admin/Transactions")]
        public IActionResult AllTransactionsDetails()
        {
            return Ok(db.Transactions.ToList());
        }

        [HttpDelete]
        [Route("/Admin/RemoveUser")]
        public IActionResult RemoveUser(string id )
        {
            SystemUser borrower = db.SystemUsers.Find(id);
            if (borrower == null)
            {
                SystemUser owner = db.SystemUsers.Find(id);
                db.SystemUsers.Remove(owner);
                db.SaveChanges();
            }
            else
            {
                db.Remove(borrower);
                db.SaveChanges();
            }
            return Ok();
        }
    }
}