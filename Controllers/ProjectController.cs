using Car4EgarAPI.Models.Context;
using Car4EgarAPI.Models.Entities;
using Car4EgarAPI.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Numerics;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using static Car4EgarAPI.BL.Validations;
using static Car4EgarAPI.BL.JWTFunction;//JWT -------------
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using ServiceStack.Text;
using Microsoft.Net.Http.Headers;
using System.Net.Http.Headers;

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

        //--------------------Masssssssssssssssssssssssssssssssoud--------------------

        //sys user sys user sys user sys user sys user sys user sys user sys user [Registration]
        [HttpPost]
        [Route("/SystemUser/Register")]
        public IActionResult RegNewOwner(SystemUser user)
        {
            SystemUser users = db.SystemUsers.Where(a => a.NID == user.NID || a.Email == user.Email).FirstOrDefault();
            if (IsUserNameValid(user.UserName) && IsEmailValid(user.Email) && IsPasswordValid(user.Password) && IsNIDalid(user.NID) && users == null)
            {
                SystemUser NewUser = new SystemUser();
                NewUser.NID = user.NID;
                NewUser.UserName = user.UserName;
                NewUser.Password = user.Password;
                NewUser.Email = user.Email;
                NewUser.Role = user.Role;

                db.SystemUsers.Add(NewUser);
                db.SaveChanges();
                return Ok(NewUser);
            }
            else if (users != null) return BadRequest("This User Already Exist");
            return BadRequest("Bad Data Entered");
        }

        //sys user sys user sys user sys user sys user sys user sys user sys user [Login]

        [HttpGet]
        [Route("/SystemUser/AllUsers")]
        public IActionResult GetAllSystemUsers()
        {
            return Ok(db.SystemUsers.ToList());
        }

        [HttpPost]
        [Route("/SystemUser/UsersEmail")]
        public IActionResult GetSystemUserByEmail([FromBody] string EmailInput)
        {
            SystemUser Sysuser = db.SystemUsers.FirstOrDefault(a => a.Email == EmailInput);
            if (Sysuser != null)
            {
                return Ok(Sysuser);
            }
            else return BadRequest("Not Register User");
        }

        [HttpGet]
        [Route("/SystemUser/UsersNID/{nid}")]
        public IActionResult GetSystemUserByNID(string nid)
        {
            SystemUser Sysuser = db.SystemUsers.Find(nid);
            if (Sysuser != null)
            {
                return Ok(Sysuser);
            }
            else return BadRequest("Not Register User");
        }


        [HttpPost]
        [Route("/SystemUser/AccountInfo")]
        public IActionResult EditUser(SystemUser user)
        {
            SystemUser users = db.SystemUsers.Where(a => a.NID == user.NID).FirstOrDefault();
            if (users != null)
            {
                users.NID = user.NID;
                users.UserName = user.UserName;
                users.Password = user.Password;
                users.Email = user.Email;
                users.Role = user.Role;
                users.IsActivated = user.IsActivated;
                users.Address = user.Address;
                users.PhoneNumber = user.PhoneNumber;
                users.Gender = user.Gender;
                users.BirthDate = user.BirthDate;
                users.Photo = user.Photo;
                users.IdentityPhoto = user.IdentityPhoto;
                users.DriverLicencePhoto = user.DriverLicencePhoto;
                users.DriverLicenceNumber = user.DriverLicenceNumber;
                users.DriverLicenceEXDate = user.DriverLicenceEXDate;
                users.Bank_AccountNumber = user.Bank_AccountNumber;
                users.Bank_NID = user.Bank_NID;
                users.Bank_Name = user.Bank_Name;
                users.Bank_Branch = user.Bank_Branch;
                users.Card_EXDate = user.Card_EXDate;
                users.Card_Number = user.Card_Number;
                users.Card_CVC = user.Card_CVC;
                users.Card_HolderName = user.Card_HolderName;
                users.Balance = user.Balance;
                users.Fine = user.Fine;
                users.Rate = user.Rate;
                users.RatedPeople = user.RatedPeople;

                db.SaveChanges();
                return Ok(users);
            }
            else if (users == null)
                return BadRequest("This User Is Not Exist");
            else return BadRequest("Bad Data Entered");

        }




































        //------------------------------------------------








        // SystemUser  SystemUser  SystemUser  SystemUser  SystemUser
        [Route("/SystemUser/RegisterNewUser")]
        [HttpPost]
        public IActionResult RegisterNewUser(SystemUser user)
        {

            if (IsNIDalid(user.NID) && IsEmailValid(user.Email) && IsMobileValid(user.PhoneNumber) && IsPasswordValid(user.Password) && IsUserNameValid(user.UserName) && user.Role != null)
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

        //[HttpPost]
        //[Route("/Owner/Register")]
        //public IActionResult RegNewOwner(string NID, string userName, string Password, string Email, string Role, string bank_EX_date, string photo)
        //{
        //    SystemUser user = db.SystemUsers.Find(NID);
        //    if (IsNameValid(userName) && IsBankCardNumberValid(bank_Card_Number) && bank_EX_date != null & IsBankCSCValid(bank_csc))
        //    {
        //        SystemUser owner = new SystemUser();
        //        owner.UserName = userName;
        //        owner.Address = address;
        //        owner.NID = user.NID;
        //        owner.Email = user.Email;
        //        owner.Password = user.Password;
        //        owner.PhoneNumber = user.PhoneNumber;
        //        owner.Bank_CardNumber = bank_Card_Number;
        //        owner.Bank_CSC = bank_csc;
        //        owner.Bank_ExpireDate = bank_EX_date;
        //        owner.Photo = photo;
        //        owner.IsActivated = false;

        //        db.SystemUsers.Add(owner);
        //        db.SaveChanges();
        //        return Ok(owner);
        //    }
        //    return BadRequest();
        //}


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
        public IActionResult RegisterNewCar(string NID, string color, double Mailage, string EXYear, int Year, bool AvailableForRent, string ModelName, string LocationOfRent, double CostPerDay, string Image, bool Insurance, string GearBoxType)
        {
            SystemUser owner = db.SystemUsers.Find(NID);

            Car car = new Car();
            car.Color = color;
            //car.LicenseNumber = LicenseNumber;
            //car.Seats = Seats;
            car.Insurance = Insurance;
            //car.CarType = CarType;
            car.LicenseEXDate = EXYear;
            car.Year = Year;
            car.LocationOfRent = LocationOfRent;
            car.AvailableForRent = AvailableForRent;
            car.ModelName = ModelName;
            //car.BrandName = BrandName;
            car.Mailage = Mailage;
            car.GearBoxType = GearBoxType;
            car.CostPerDay = CostPerDay;
            car.Image = Image;
            //car.RegistrationDate = DateTime.Now;
            //car.IsActivated = false;

            car.OwnerId = owner.NID;
            car.OwnerName = owner.UserName;
            car.OwnerPhoto = owner.Photo;
            car.OwnerPhone = owner.PhoneNumber;

            db.Cars.Add(car); // ?!?!?!?!?!?!
            db.SaveChanges();
            return Ok();


        }

        [HttpDelete]
        [Route("/Owner/RemoveACar/{vin}")]
        public IActionResult RemoveACar(string vin)
        {
            CarVM car = db.CarVM.Find(vin);
            db.CarVM.Remove(car);
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

        //[HttpPut]
        //[Route("/Owner/EditOwnerInfo")]
        //public IActionResult EditOwnerInfo(string NID, string newPassword, string newEmail, string newPhone ,string newAddress, string newPhoto, string bank_Card_Number, string bank_csc, string bank_EX_date)
        //{
        //    if ( IsEmailValid(newEmail) && IsMobileValid(newPhone) && IsPasswordValid(newPassword) && IsBankCardNumberValid(bank_Card_Number) && bank_EX_date != null && IsBankCSCValid(bank_csc) && newAddress!=null)
        //    {
        //        SystemUser owner = db.SystemUsers.Find(NID);
        //        owner.Password = newPassword;
        //        owner.Email = newEmail;
        //        owner.Address = newAddress;
        //        owner.Photo = newPhoto;
        //        owner.Bank_CardNumber = bank_Card_Number;
        //        owner.Bank_CSC = bank_csc;
        //        owner.Bank_ExpireDate = bank_EX_date;
        //        owner.PhoneNumber = newPhone;
        //        db.SystemUsers.Update(owner);
        //        db.SaveChanges();
        //        return Ok();
        //    }
        //    return BadRequest();
        //}


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
            //notification.Content = "Your Request About Car: " + car.BrandName + "Accepted From Owner, Admin Will Contact With You";
            db.Notifications.Add(notification);
            db.Update(ownerRequest);
            db.SaveChanges();
            return Ok();
        }

        //=======================================Moazzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz====

        [HttpPost]
        [Route("/Owner/RegisterMCar")]
        public IActionResult RegisterNewCarMOaaz(MCar newCar)
        {
            //NID = "123456789123456";
            SystemUser owner = db.SystemUsers.FirstOrDefault(x => x.NID == newCar.OwnerId);
            if (owner != null)
            {
                if (owner.IsActivated)
                {
                    MCar car = new MCar();
                    car.VIN = newCar.VIN;
                    car.Color = newCar.Color;
                    car.LicenseNumber = newCar.LicenseNumber;
                    car.Seats = newCar.Seats;
                    car.Insurance = newCar.Insurance;
                    car.CarType = newCar.CarType;
                    car.LicenseEXDate = newCar.LicenseEXDate;
                    car.Year = newCar.Year;
                    car.LocationOfRent = newCar.LocationOfRent;
                    car.AvailableForRent = newCar.AvailableForRent;
                    car.ModelName = newCar.ModelName;
                    car.BrandName = newCar.BrandName;
                    car.Mailage = newCar.Mailage;
                    car.GearBoxType = newCar.GearBoxType;
                    car.CostPerDay = newCar.CostPerDay;
                    car.Image = newCar.Image;
                    car.RegistrationDate = DateTime.Now;
                    car.IsActivated = false;

                    car.OwnerId = newCar.OwnerId;
                    car.OwnerName = newCar.OwnerName;
                    car.OwnerPhone = newCar.OwnerPhone;
                    car.OwnerPhoto = newCar.OwnerPhoto;
                    //owner.Cars.Add(car);
                    db.MCars.Add(car); // ?!?!?!?!?!?!
                    db.SaveChanges();
                    return Ok();
                }
                else if (!owner.IsActivated) return BadRequest("Not Active User");
            }
            return BadRequest("Not Registered User");
        }



        //GET All Car
        //[HttpGet]
        //[Route("/Admin/GetAllMCars")]
        //public IActionResult GetAllCars()
        //{
        //    List<MCar> cars = new List<MCar>();
        //    if (cars.Count == 0)
        //        return BadRequest("No Cars In Data Base");
        //    else return Ok(cars);
        //}


        //Get By ID//////
        //[HttpGet]
        //[Route("/Admin/GetAllMCars")]
        //public IActionResult GetAllCars(string Vin)

        //MCar car = db.MCars.Find(Vin);

        //{
        //    List<MCar> cars = new List<MCar>();
        //    if (cars.Count == 0)
        //        return BadRequest("No Cars In Data Base");
        //    else return Ok(cars);
        //}







        //=========================================

        [HttpGet]
        [Route("/Owner/GetAllRequests")]
        public IActionResult GetAllOwnerRequests()
        {
            var list = db.RentRequests.ToList();
            return Ok(list);
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
        public IActionResult RatingTheBorrowers(string id, double RateDegree)
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

        //[HttpPost]
        //[Route("/Borrower/Register")]
        //public IActionResult RegNewBorrower(string NID, string userName, string address, string bank_Card_Number, string bank_csc, string bank_EX_date, string photo)
        //{
        //    SystemUser user = db.SystemUsers.Find(NID);
        //    if ( IsNameValid(userName) && IsBankCardNumberValid(bank_Card_Number) && bank_EX_date != null & IsBankCSCValid(bank_csc))
        //    {
        //        SystemUser borrower = new SystemUser();

        //        borrower.UserName = userName;
        //        borrower.Address = address;
        //        borrower.NID = user.NID;
        //        borrower.Email = user.Email;
        //        borrower.Password = user.Password;
        //        borrower.PhoneNumber = user.PhoneNumber;
        //        borrower.Bank_CardNumber = bank_Card_Number;
        //        borrower.Bank_CSC = bank_csc;
        //        borrower.Bank_ExpireDate = bank_EX_date;
        //        borrower.Photo = photo;
        //        borrower.IsActivated = false;

        //        db.SystemUsers.Add(borrower);
        //        db.SaveChanges();
        //        return Ok(borrower);
        //    }
        //    return BadRequest();
        //}

        //[HttpPut]
        //[Route("/Borrower/EditBorrowerInfo")]
        //public IActionResult EditBorrowerInfo(string NID, string newPassword, string newEmail, string newPhone, string newAddress, string newPhoto, string bank_Card_Number, string bank_csc, string bank_EX_date)
        //{
        //    if (IsEmailValid(newEmail) && IsMobileValid(newPhone) && IsPasswordValid(newPassword) && IsBankCardNumberValid(bank_Card_Number) && bank_EX_date != null && IsBankCSCValid(bank_csc) && newAddress != null)
        //    {
        //        SystemUser borrower = db.SystemUsers.Find(NID);
        //        borrower.Password = newPassword;
        //        borrower.Email = newEmail;
        //        borrower.Address = newAddress;
        //        borrower.Photo = newPhoto;
        //        borrower.Bank_CardNumber = bank_Card_Number;
        //        borrower.Bank_CSC = bank_csc;
        //        borrower.Bank_ExpireDate = bank_EX_date;
        //        borrower.PhoneNumber = newPhone;
        //        db.SystemUsers.Update(borrower);
        //        db.SaveChanges();
        //        return Ok();
        //    }
        //    return BadRequest();

        //}


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
        public IActionResult CarRentalRequest([FromHeader] string id, [FromHeader] string carVin, [FromHeader] int Days)
        {
            SystemUser borrower = db.SystemUsers.Find(id);

            CarVM car = db.CarVM.Find(carVin);
            //SystemUser carOwner = db.SystemUsers.Where(o => o.Cars.Contains(car)).FirstOrDefault();
            RentRequest ownerRequest = new RentRequest();
            ownerRequest.OwnerId = car.OwnerId;
            ownerRequest.RequestedCarVIN = carVin;
            ownerRequest.BorrowerId = id;
            ownerRequest.BorrowerName = db.SystemUsers.Find(id).UserName;
            if (db.SystemUsers.Find(id).Address != null)
            {
                ownerRequest.BorrowerAddress = db.SystemUsers.Find(id).Address;

            }
            else
            {
                ownerRequest.BorrowerAddress = "";
            }
            ownerRequest.RentDays = Days;
            ownerRequest.CarImage = car.Image;
            if (borrower.Photo !=null)
            {
            ownerRequest.BorrowerImage = borrower.Photo;

            }
            else
            {
                ownerRequest.BorrowerImage = "";
            }
            
            ownerRequest.CarBrand = car.ModelName;
            ownerRequest.CarYear = car.Year;
            ownerRequest.Total = car.CostPerDay * Days;
            db.RentRequests.Add(ownerRequest);

            //Notification notification = new Notification();
            //notification.UserId = carOwner.NID;
            //notification.Content = "You Have a New car rental request made by " + ownerRequest.BorrowerName+ " on your car";

            //db.Notifications.Add(notification);
            db.SaveChanges();
            return Ok();


        }

        [HttpGet]
        [Route("/Borrower/CarRentalRequestAcception/{vid}/{accept}")]
        public IActionResult CarRentalRequestAcceptance(string vid, int accept)
        {
            RentRequest rent = db.RentRequests.FirstOrDefault(a => a.RequestedCarVIN == vid);
            CarVM CarR = db.CarVM.FirstOrDefault(a => a.VIN == vid);
            
                    rent.RequestAcceptance = true;
                    CarR.Available = false;
            db.CarVM.Update(CarR);
                    db.SaveChanges();
                    return Ok();
        }

        [HttpDelete]
        [Route("/Borrower/CarRentalRequestDelete/{vid}")]
        public IActionResult CarRentalRequestDelete(string vid)
        {
            RentRequest rent = db.RentRequests.FirstOrDefault(a => a.RequestedCarVIN == vid);
            CarVM CarR = db.CarVM.FirstOrDefault(a => a.VIN == vid);
            if (rent != null)
            {

                db.RentRequests.Remove(rent);
                db.SaveChanges();
                return Ok("Car Has Been Deleted");

            }
            else
                return BadRequest("Request Not Exist");
        }

        [HttpDelete]
        [Route("/Borrower/CarRentalRequestCancel/{vid}")]
        public IActionResult CarRentalRequestCancel(string vid)
        {
            RentRequest rent = db.RentRequests.FirstOrDefault(a => a.RequestedCarVIN == vid);
            CarVM CarR = db.CarVM.FirstOrDefault(a => a.VIN == vid);
            if (rent != null)
            {

                db.RentRequests.Remove(rent);
                CarR.Available = true;
                db.SaveChanges();
                return Ok("Car Has Been Deleted");

            }
            else
                return BadRequest("Request Not Exist");
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
            //car.IsActivated = true;
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
            var ActivatedUsers = db.SystemUsers.ToList();
            return Ok(ActivatedUsers);
        }

        //[HttpGet]
        //[Route("/Admin/GetAllActivatedCars")]
        //public IActionResult GetAllActivatedCars()
        //{
        //var ActivatedCars = db.Cars.Where(c => c.IsActivated == true).ToList();
        //return Ok(ActivatedCars);
        //}

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
        [Route("/Admin/RemoveUser/{id}")]
        public IActionResult RemoveUser(string id)
        {
            SystemUser user = db.SystemUsers.Find(id);

            foreach (var item in db.CarVM.ToList())
            {
                if (item.OwnerId == id)
                {
                    db.CarVM.Remove(item);
                }
            }
            db.SystemUsers.Remove(user);
            db.SaveChanges();

            return Ok();
        }



        /*********************************************/
        /*********************************************/
        /*View Models*/
        /*********************************************/
        /*********************************************/


        [HttpGet]
        [Route("/Admin/GetAllCars")]
        public IActionResult GetAllCars()
        {
            List<CarVM> cars = new List<CarVM>();
            foreach (var item in db.CarVM.ToList())
            {
                CarVM car = new CarVM();
                car.OwnerId = item.OwnerId;
                car.OwnerName = item.OwnerName;
                car.OwnerPic = item.OwnerPic;
                car.OwnerPhone = item.OwnerPhone;

                car.CostPerDay = item.CostPerDay;
                car.VIN = item.VIN;
                car.Mailage = item.Mailage;
                car.Color = item.Color;
                car.RatedPeople = item.RatedPeople;
                car.Rate = item.Rate;
                car.Available = item.Available;
                car.Image = item.Image;
                car.Year = item.Year;
                car.ModelName = item.ModelName;
                car.GearBoxType = item.GearBoxType;
                car.Insurance = item.Insurance;
                car.LocationOfRent = item.LocationOfRent;
                //car.CarType = item.CarType;
                //car.BrandName = item.BrandName;
                //car.IsActivated = item.IsActivated;
                cars.Add(car);

            }
            return Ok(cars);
        }


        [HttpPost]
        [Route("/Admin/RegisterNewCarVM")]
        public IActionResult RegisterNewCar([FromBody] CarVM item)
        {

            CarVM car = new CarVM();
            SystemUser systemUser = db.SystemUsers.Find(item.OwnerId);
            car.OwnerId = item.OwnerId;
            car.OwnerName = systemUser.UserName;
            if (systemUser.Photo != null)
            {
                car.OwnerPic = systemUser.Photo;

            }
            else
            {
                car.OwnerPic = "Null";
            }
            if (systemUser.PhoneNumber != null)
            {
                car.OwnerPhone = systemUser.PhoneNumber;

            }
            else
            {
                car.OwnerPhone = "01111111111";
            }

            car.CostPerDay = item.CostPerDay;
            car.VIN = "Car"+item.VIN;
            car.Mailage = item.Mailage;
            car.Color = item.Color;
            car.RatedPeople = item.RatedPeople;
            car.Rate = item.Rate;
            car.Available = item.Available;
            car.Image = item.Image;
            car.Year = item.Year;
            car.ModelName = item.ModelName;
            car.GearBoxType = item.GearBoxType;
            car.Insurance = item.Insurance;
            car.LocationOfRent = item.LocationOfRent;
            //car.CarType = item.CarType;
            //car.BrandName = item.BrandName;
            //car.IsActivated = item.IsActivated;
            db.CarVM.Add(car);
            db.SaveChanges();

            return Ok();
        }


        /*********************************************/
        /*********************************************/
        /*upload Pictures*/
        /*********************************************/
        /*********************************************/




        //[HttpGet("Admin/uploadPic")]
        //public IActionResult UploadPicture([FromHeader] string NID ,[FromHeader] string Base64String, [FromHeader] string Filename)
        //{
        //    var bytes = Convert.FromBase64String(Base64String);
        //    var filePath = Path.Combine("wwwroot","Imgs",Filename);
        //    System.IO.File.WriteAllBytes(filePath, bytes);

        //    // Save filename and other relevant information to database
        //    SystemUser user = db.SystemUsers.Find(NID);
        //    user.Photo = Filename;
        //    user.IdentityPhoto = Filename;
        //    db.Update(user);
        //    db.SaveChanges();
        //    return Ok();
        //}

        [HttpPut]
        [Route("/Admin/UploadPicture")]
        public IActionResult UploadPicture([FromHeader] string NID, [FromHeader] string Filename)
        {
            SystemUser user = db.SystemUsers.Find(NID);
            user.Photo = Filename;
            db.Update(user);
            db.SaveChanges();
            return Ok();
        }

        [HttpPut]
        [Route("/Admin/UploadPictureForCar")]
        public IActionResult UploadPictureForCar([FromHeader] string VIN, [FromHeader] string Filename)
        {
            CarVM car = db.CarVM.Find(VIN);
            car.Image = Filename;
            db.Update(car);
            db.SaveChanges();
            return Ok();
        }

        [HttpPost("/Admin/UploadPictureAndSave")]
        public async Task<IActionResult> UploadPictureAndSave()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("E:\\ITI\\_Car4Egar\\FrontSide\\Car4Egar-Angular\\src\\", "assets");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = System.Net.Http.Headers.ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok();

                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPost("/Borrower/RateCar")]
        public async Task<IActionResult> RateCar([FromHeader] int value, [FromHeader] string carVin, [FromHeader] string borrowerNid)
        {
            RatedFrom car = new RatedFrom();
            car.CarVIN = carVin;
            car.BorroweNID = borrowerNid;
            car.RatedOrNot = true;

            CarVM carVM = db.CarVM.Find(carVin);
            if (carVM.RatedPeople == 0)
            {
                carVM.RatedPeople += 1;
                carVM.Rate = value;
            }
            else
            {
                
                for (int i = 0; i < carVM.RatedPeople; i++)
                {
                    carVM.Rate = carVM.Rate + value;
                }
                carVM.Rate = Math.Round((double)(carVM.Rate / (carVM.RatedPeople+1)));
                carVM.RatedPeople += 1;
            }
            
            db.SaveChanges();
            return Ok();
        }


    }


}
