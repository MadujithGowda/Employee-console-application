using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace EmployeeApplication.EmployeeCRUD
{
    public class RegexValidation
    {
        public static string NameFormat = "^[A-Z]{1}[A-Za-z]{3,20}$";
        public static string IDFormat = "^[A]{1}[C]{1}[E]{1}[0-9]{4}$";
        public static string PhoneNumberFormat = "^[6-9]{1}[0-9]{9}$";
        public static string MailFormat = "^[0-9a-zA-Z]+[.+-_]{0,1}[0-9a-zA-Z]+[@][a-zA-z]+[.][a-zA-Z]{2,3}";

        public bool ValidateEmployeeName(string EmployeeName)
        {
            return Regex.IsMatch(EmployeeName, NameFormat);
        }
        public bool ValidateID(string EmployeeID)
        {
            return Regex.IsMatch(EmployeeID, IDFormat);
        }
        public bool ValidatePhoneNumber(string PhoneNumber)
        {
            return Regex.IsMatch(PhoneNumber, PhoneNumberFormat);
        }
        public bool ValidateEmail(string Email)
        {
            return Regex.IsMatch(Email, MailFormat);
        }
    }
}
