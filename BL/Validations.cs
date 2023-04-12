using System.Numerics;
using System.Text.RegularExpressions;

namespace Car4EgarAPI.BL
{
    public static class Validations
    {
        public static bool IsMobileValid(string phone)
        {
            return Regex.Match(phone, @"^(01)[0125]([0-9]{8})$").Success;
        }

        public static bool IsEmailValid(string email)
        {
            return Regex.Match(email, @"^[a-zA-Z0-9.!#$%&'+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)$").Success;
        }

        public static bool IsUserNameValid(string name)
        {
            return Regex.Match(name, @"^([a-zA-Z0-9]{3,})$").Success;
        }

        public static bool IsNameValid(string name)
        {
            return Regex.Match(name, @"^([a-zA-Z0-9.!#$%&'+/=?^_`{|}~ -]{8,})$").Success;
        }

        public static bool IsPasswordValid(string password)
        {
            return Regex.Match(password, @"^([a-zA-Z0-9]{8,})$").Success;
        }

        public static bool IsBankCardNumberValid(string cardNumber)
        {
            return Regex.Match(cardNumber, @"^([0-9]{16,19})$").Success;
        }
        public static bool IsBankCSCValid(string csc)
        {
            return Regex.Match(csc, @"^([a-zA-Z0-9]{3,4})$").Success;
        }

        public static bool IsNIDalid(string nid)
        {
            return Regex.Match(nid, @"^([0-9]{14})$").Success;
        }
        }
}